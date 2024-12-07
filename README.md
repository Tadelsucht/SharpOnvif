# SharpOnvif
A C# implementation of the ONVIF interface - client as well as the server. All profiles are supported.

## SharpOnvifServer
ONVIF server provides NET8 CoreWCF bindings generated using svcutil.exe. It makes it easy to implement only parts of the ONVIF specification needed for your project.

Start with creating a new CoreWCF service:
```cs
var builder = WebApplication.CreateBuilder();
builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddSingleton<IServiceBehavior, UseRequestHeadersForMetadataAddressBehavior>();
```
Add Digest authentication for ONVIF:
```cs
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddOnvifDigestAuthentication();
```
Implement `IUserRepository` to provide user verification and configure your user:
```cs
public class UserRepository : IUserRepository
{
    public string UserName { get; set; } = "admin";
    public string Password { get; set; } = "password";

    public Task<UserInfo> GetUser(string userName)
    {
        if (string.Compare(userName, UserName, true) == 0)
        {
            return Task.FromResult(new UserInfo() { UserName = userName, Password = Password });
        }

        return Task.FromResult((UserInfo)null);
    }
}
```
Optionally, add ONVIF discovery to make your service discoverable on the network:
```cs
builder.Services.AddOnvifDiscovery();
```
Simple DeviceImpl just extends `SharpOnvifServer.DeviceMgmt.DeviceBase` and overrides a method you want to implement - for instance `GetDeviceInformation`:
```cs
public class DeviceImpl : DeviceBase
{
    public override GetDeviceInformationResponse GetDeviceInformation(GetDeviceInformationRequest request)
    {
        return new GetDeviceInformationResponse()
        {
            FirmwareVersion = "1.0",
            HardwareId = "1.0",
            Manufacturer = "Manufacturer",
            Model = "1",
            SerialNumber = "1"
        };
    }
}
```
Add authentication:
```cs
var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
```
And make sure to call `app.UseOnvif()` to handle SOAP requests with action in the SOAP message instead of the Content-Type header:
```cs
app.UseOnvif();
```
Add the CoreWCF service endpoint:
```cs
((IApplicationBuilder)app).UseServiceModel(serviceBuilder =>
{
    var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    serviceMetadataBehavior.HttpGetEnabled = true;

    serviceBuilder.AddService<DeviceImpl>();
    serviceBuilder.AddServiceEndpoint<DeviceImpl, SharpOnvifServer.DeviceMgmt.Device>(OnvifBindingFactory.CreateBinding(), "/onvif/device_service");
});
```
Finally call `app.Run()`:
```cs
app.Run();
```
Your ONVIF service should now be discoverable on the network and you should be able to use ONVIF Device Manager or similar tool to call your endpoint.

## SharpOnvifClient
ONVIF client provides netstandard2.0 WCF bindings generated using `dotnet-svcutil`. `SimpleOnvifClient` wraps common API calls to get basic information from the camera and includes both Pull Point as well as Basic event subscriptions. 

To discover ONVIF devices on your network, use:
```cs
string[] onvifDeviceUris = await DiscoveryClient.DiscoverAsync();
```

To create the `SimpleOnvifClient`, use:
```cs
var client = new SimpleOnvifClient(onvifDeviceUri, "admin", "password");
```

Call `GetDeviceInformationAsync` to retrieve information about the device:
```cs
var deviceInfo = await client.GetDeviceInformationAsync();
```

Call `GetServicesAsync` to retrieve a list of all services supported by the device:
```cs
var services = await client.GetServicesAsync();
```

Some operations require the device to support a service. For instance, to retrieve the stream URI the device must support the media service. To check whether the ONVIF service is supported by the device, call:
```cs
if (services.Service.FirstOrDefault(x => x.Namespace == OnvifServices.MEDIA) != null)
{
    // operation only available when the service is supported
}
```
Full list of services that can be supported by the device is available in `SharpOnvifCommon.OnvifServices`.

### Pull Point event subscription
Pull point event subscription does not require any special networking configuration and it should work in most networks. 
To create a new Pull Point subscription, call:
```cs
var subscription = await client.PullPointSubscribeAsync();
```
To retrive the current notifications from the Pull Point subscription, call:
```cs
var notifications = await client.PullPointPullMessagesAsync(subscription);
foreach (var notification in notifications)
{
    // handle the notification message
    bool? isMotion = SharpOnvifClient.OnvifEvents.IsMotionDetected(notification);
}
```

### Basic event subscription
Basic event subscription utilizes a callback from the camera when an event occurs. This requires the camera to be able to reach your machine through a firewall/NAT. To listen for incoming notifications, you must run `SimpleOnvifEventListener`:
```cs
// ID 1 will identify this camera in the callback
const int CAMERA1 = 1;

var eventListener = new SimpleOnvifEventListener();
eventListener.Start((int cameraID, string ev) =>
{
    bool? isTamper = SharpOnvifClient.OnvifEvents.IsTamperDetected(notification);
    if(cameraID == CAMERA1)
    {
        // handle the notification message for CAMERA1
    }
});

var subscriptionResponse = await client.BasicSubscribeAsync(eventListener.GetOnvifEventListenerUri(CAMERA1));
```
### Using the generated WCF clients
First add a reference to the DLL that implements the clients (e.g. `SharpOnvifClient.DeviceMgmt`). Create the authentication behavior:
```cs
var auth = new DigestBehavior("admin", "password");
```
Create the ONVIF client and set the authentication behavior before you use it:
```cs
 using (var deviceClient = new DeviceClient(
     OnvifBindingFactory.CreateBinding(),
     new System.ServiceModel.EndpointAddress("http://192.168.1.10/onvif/device_service")))
 {
     SetAuthentication(deviceClient);
     
     // use the client
 }
```
Where the `SetAuthentication` method might look like:
```cs
[Flags]
public enum AuthenticationMethod
{
    None = 0,
    WsUsernameToken = 1,
    HttpDigest = 2
}

private readonly AuthenticationMethod _authentication;

private void SetAuthentication<TChannel>(ClientBase<TChannel> channel) where TChannel : class
{
    if(_authentication == AuthenticationMethod.None)
    {
        Debug.WriteLine("Authentication is disabled");
        return;
    }

    if (_authentication.HasFlag(AuthenticationMethod.HttpDigest))
    {
        // HTTP Digest authentication is handled by WCF
        channel.ClientCredentials.HttpDigest.ClientCredential = _credentials;
    }

    if (_authentication.HasFlag(AuthenticationMethod.WsUsernameToken))
    {
        // Legacy WsUsernameToken authenticaiton must be handled using a custom behavior
        if (!channel.Endpoint.EndpointBehaviors.Contains(_legacyAuth))
        {
            channel.Endpoint.EndpointBehaviors.Add(_legacyAuth);
        }
    }
}
```
Call any method on the client like:
```cs
var deviceInfo = await deviceClient.GetDeviceInformationAsync(new GetDeviceInformationRequest());
```
## Testing
Only the DeviceMgmt, Media and Events were tested with Hikvision cameras. 
Server implementation was tested using ONVIF Device Manager.

## Credits
Special thanks to Piotr Stapp for figuring out the SOAP security headers in NET8: https://stapp.space/using-soap-security-in-dotnet-core/.