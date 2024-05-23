﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnvifScReceiver
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("CoreWCF", "4.0.0.0")]
    [CoreWCF.ServiceContractAttribute(Namespace="http://www.onvif.org/ver10/receiver/wsdl", ConfigurationName="OnvifScReceiver.ReceiverPort")]
    public interface ReceiverPort
    {
        
        [CoreWCF.OperationContractAttribute(Action="http://www.onvif.org/ver10/receiver/wsdl/GetServiceCapabilities")]
        [CoreWCF.XmlSerializerFormatAttribute()]
        [return: CoreWCF.MessageParameterAttribute(Name="Capabilities")]
        OnvifScReceiver.Capabilities GetServiceCapabilities();
        
        // CODEGEN: Parameter 'Receivers' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [CoreWCF.OperationContractAttribute(Action="http://www.onvif.org/ver10/receiver/wsdl/GetReceivers")]
        [CoreWCF.XmlSerializerFormatAttribute()]
        [return: CoreWCF.MessageParameterAttribute(Name="Receivers")]
        OnvifScReceiver.GetReceiversResponse GetReceivers(OnvifScReceiver.GetReceiversRequest request);
        
        [CoreWCF.OperationContractAttribute(Action="http://www.onvif.org/ver10/receiver/wsdl/GetReceiver")]
        [CoreWCF.XmlSerializerFormatAttribute()]
        [return: CoreWCF.MessageParameterAttribute(Name="Receiver")]
        OnvifScReceiver.Receiver GetReceiver(string ReceiverToken);
        
        [CoreWCF.OperationContractAttribute(Action="http://www.onvif.org/ver10/receiver/wsdl/CreateReceiver")]
        [CoreWCF.XmlSerializerFormatAttribute()]
        [return: CoreWCF.MessageParameterAttribute(Name="Receiver")]
        OnvifScReceiver.Receiver CreateReceiver(OnvifScReceiver.ReceiverConfiguration Configuration);
        
        [CoreWCF.OperationContractAttribute(Action="http://www.onvif.org/ver10/receiver/wsdl/DeleteReceiver")]
        [CoreWCF.XmlSerializerFormatAttribute()]
        void DeleteReceiver(string ReceiverToken);
        
        [CoreWCF.OperationContractAttribute(Action="http://www.onvif.org/ver10/receiver/wsdl/ConfigureReceiver")]
        [CoreWCF.XmlSerializerFormatAttribute()]
        void ConfigureReceiver(string ReceiverToken, OnvifScReceiver.ReceiverConfiguration Configuration);
        
        [CoreWCF.OperationContractAttribute(Action="http://www.onvif.org/ver10/receiver/wsdl/SetReceiverMode")]
        [CoreWCF.XmlSerializerFormatAttribute()]
        void SetReceiverMode(string ReceiverToken, OnvifScReceiver.ReceiverMode Mode);
        
        [CoreWCF.OperationContractAttribute(Action="http://www.onvif.org/ver10/receiver/wsdl/GetReceiverState")]
        [CoreWCF.XmlSerializerFormatAttribute()]
        [return: CoreWCF.MessageParameterAttribute(Name="ReceiverState")]
        OnvifScReceiver.ReceiverStateInformation GetReceiverState(string ReceiverToken);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/receiver/wsdl")]
    public partial class Capabilities
    {
        
        private System.Xml.XmlElement[] anyField;
        
        private bool rTP_MulticastField;
        
        private bool rTP_MulticastFieldSpecified;
        
        private bool rTP_TCPField;
        
        private bool rTP_TCPFieldSpecified;
        
        private bool rTP_RTSP_TCPField;
        
        private bool rTP_RTSP_TCPFieldSpecified;
        
        private int supportedReceiversField;
        
        private int maximumRTSPURILengthField;
        
        private bool maximumRTSPURILengthFieldSpecified;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Order=0)]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool RTP_Multicast
        {
            get
            {
                return this.rTP_MulticastField;
            }
            set
            {
                this.rTP_MulticastField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RTP_MulticastSpecified
        {
            get
            {
                return this.rTP_MulticastFieldSpecified;
            }
            set
            {
                this.rTP_MulticastFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool RTP_TCP
        {
            get
            {
                return this.rTP_TCPField;
            }
            set
            {
                this.rTP_TCPField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RTP_TCPSpecified
        {
            get
            {
                return this.rTP_TCPFieldSpecified;
            }
            set
            {
                this.rTP_TCPFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool RTP_RTSP_TCP
        {
            get
            {
                return this.rTP_RTSP_TCPField;
            }
            set
            {
                this.rTP_RTSP_TCPField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool RTP_RTSP_TCPSpecified
        {
            get
            {
                return this.rTP_RTSP_TCPFieldSpecified;
            }
            set
            {
                this.rTP_RTSP_TCPFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int SupportedReceivers
        {
            get
            {
                return this.supportedReceiversField;
            }
            set
            {
                this.supportedReceiversField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int MaximumRTSPURILength
        {
            get
            {
                return this.maximumRTSPURILengthField;
            }
            set
            {
                this.maximumRTSPURILengthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaximumRTSPURILengthSpecified
        {
            get
            {
                return this.maximumRTSPURILengthFieldSpecified;
            }
            set
            {
                this.maximumRTSPURILengthFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public partial class ReceiverStateInformation
    {
        
        private ReceiverState stateField;
        
        private bool autoCreatedField;
        
        private System.Xml.XmlElement[] anyField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public ReceiverState State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public bool AutoCreated
        {
            get
            {
                return this.autoCreatedField;
            }
            set
            {
                this.autoCreatedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Order=2)]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public enum ReceiverState
    {
        
        /// <remarks/>
        NotConnected,
        
        /// <remarks/>
        Connecting,
        
        /// <remarks/>
        Connected,
        
        /// <remarks/>
        Unknown,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public partial class Transport
    {
        
        private TransportProtocol protocolField;
        
        private Transport tunnelField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public TransportProtocol Protocol
        {
            get
            {
                return this.protocolField;
            }
            set
            {
                this.protocolField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public Transport Tunnel
        {
            get
            {
                return this.tunnelField;
            }
            set
            {
                this.tunnelField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public enum TransportProtocol
    {
        
        /// <remarks/>
        UDP,
        
        /// <remarks/>
        TCP,
        
        /// <remarks/>
        RTSP,
        
        /// <remarks/>
        HTTP,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public partial class StreamSetup
    {
        
        private StreamType streamField;
        
        private Transport transportField;
        
        private System.Xml.XmlElement[] anyField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public StreamType Stream
        {
            get
            {
                return this.streamField;
            }
            set
            {
                this.streamField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public Transport Transport
        {
            get
            {
                return this.transportField;
            }
            set
            {
                this.transportField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Order=2)]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public enum StreamType
    {
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("RTP-Unicast")]
        RTPUnicast,
        
        /// <remarks/>
        [System.Xml.Serialization.XmlEnumAttribute("RTP-Multicast")]
        RTPMulticast,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public partial class ReceiverConfiguration
    {
        
        private ReceiverMode modeField;
        
        private string mediaUriField;
        
        private StreamSetup streamSetupField;
        
        private System.Xml.XmlElement[] anyField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public ReceiverMode Mode
        {
            get
            {
                return this.modeField;
            }
            set
            {
                this.modeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="anyURI", Order=1)]
        public string MediaUri
        {
            get
            {
                return this.mediaUriField;
            }
            set
            {
                this.mediaUriField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public StreamSetup StreamSetup
        {
            get
            {
                return this.streamSetupField;
            }
            set
            {
                this.streamSetupField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Order=3)]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public enum ReceiverMode
    {
        
        /// <remarks/>
        AutoConnect,
        
        /// <remarks/>
        AlwaysConnect,
        
        /// <remarks/>
        NeverConnect,
        
        /// <remarks/>
        Unknown,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("svcutil", "4.8.3928.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.onvif.org/ver10/schema")]
    public partial class Receiver
    {
        
        private string tokenField;
        
        private ReceiverConfiguration configurationField;
        
        private System.Xml.XmlElement[] anyField;
        
        private System.Xml.XmlAttribute[] anyAttrField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string Token
        {
            get
            {
                return this.tokenField;
            }
            set
            {
                this.tokenField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public ReceiverConfiguration Configuration
        {
            get
            {
                return this.configurationField;
            }
            set
            {
                this.configurationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyElementAttribute(Order=2)]
        public System.Xml.XmlElement[] Any
        {
            get
            {
                return this.anyField;
            }
            set
            {
                this.anyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttributeAttribute()]
        public System.Xml.XmlAttribute[] AnyAttr
        {
            get
            {
                return this.anyAttrField;
            }
            set
            {
                this.anyAttrField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("CoreWCF", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [CoreWCF.MessageContractAttribute(WrapperName="GetReceivers", WrapperNamespace="http://www.onvif.org/ver10/receiver/wsdl", IsWrapped=true)]
    public partial class GetReceiversRequest
    {
        
        public GetReceiversRequest()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("CoreWCF", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [CoreWCF.MessageContractAttribute(WrapperName="GetReceiversResponse", WrapperNamespace="http://www.onvif.org/ver10/receiver/wsdl", IsWrapped=true)]
    public partial class GetReceiversResponse
    {
        
        [CoreWCF.MessageBodyMemberAttribute(Namespace="http://www.onvif.org/ver10/receiver/wsdl", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("Receivers")]
        public OnvifScReceiver.Receiver[] Receivers;
        
        public GetReceiversResponse()
        {
        }
        
        public GetReceiversResponse(OnvifScReceiver.Receiver[] Receivers)
        {
            this.Receivers = Receivers;
        }
    }
}
