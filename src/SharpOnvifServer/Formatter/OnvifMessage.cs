// SharpOnvif
// Copyright (C) 2026 Lukas Volf
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE 
// SOFTWARE.

using CoreWCF.Channels;
using System.Xml;

namespace SharpOnvifServer
{
    public class OnvifMessage : Message
    {
        private readonly Message message;

        public OnvifMessage(Message message)
        {
            this.message = message;
        }
        public override MessageHeaders Headers
        {
            get { return this.message.Headers; }
        }
        public override MessageProperties Properties
        {
            get { return this.message.Properties; }
        }
        public override MessageVersion Version
        {
            get { return this.message.Version; }
        }
        protected override void OnWriteStartBody(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("Body", "http://www.w3.org/2003/05/soap-envelope");
        }
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            this.message.WriteBodyContents(writer);
        }
        protected override void OnWriteStartEnvelope(XmlDictionaryWriter writer)
        {
            /*
            <?xml version="1.0" encoding="UTF-8"?>
            <env:Envelope 
                xmlns:env="http://www.w3.org/2003/05/soap-envelope" 
                xmlns:soapenc="http://www.w3.org/2003/05/soap-encoding" 
                xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
                xmlns:xs="http://www.w3.org/2001/XMLSchema"
                xmlns:tt="http://www.onvif.org/ver10/schema" 
                xmlns:tds="http://www.onvif.org/ver10/device/wsdl" 
                xmlns:trt="http://www.onvif.org/ver10/media/wsdl" 
                xmlns:timg="http://www.onvif.org/ver20/imaging/wsdl" 
                xmlns:tev="http://www.onvif.org/ver10/events/wsdl" 
                xmlns:tptz="http://www.onvif.org/ver20/ptz/wsdl" 
                xmlns:tan="http://www.onvif.org/ver20/analytics/wsdl"
                xmlns:tst="http://www.onvif.org/ver10/storage/wsdl" 
                xmlns:ter="http://www.onvif.org/ver10/error" 
                xmlns:dn="http://www.onvif.org/ver10/network/wsdl" 
                xmlns:tns1="http://www.onvif.org/ver10/topics" 
                xmlns:tmd="http://www.onvif.org/ver10/deviceIO/wsdl" 
                xmlns:wsdl="http://schemas.xmlsoap.org/wsdl"
                xmlns:wsoap12="http://schemas.xmlsoap.org/wsdl/soap12"
                xmlns:http="http://schemas.xmlsoap.org/wsdl/http" 
                xmlns:d="http://schemas.xmlsoap.org/ws/2005/04/discovery" 
                xmlns:wsadis="http://schemas.xmlsoap.org/ws/2004/08/addressing"
                xmlns:wsnt="http://docs.oasis-open.org/wsn/b-2" 
                xmlns:wsa="http://www.w3.org/2005/08/addressing" 
                xmlns:wstop="http://docs.oasis-open.org/wsn/t-1" 
                xmlns:wsrf-bf="http://docs.oasis-open.org/wsrf/bf-2"
                xmlns:wsntw="http://docs.oasis-open.org/wsn/bw-2" 
                xmlns:wsrf-rw="http://docs.oasis-open.org/wsrf/rw-2"
                xmlns:wsaw="http://www.w3.org/2006/05/addressing/wsdl" 
                xmlns:wsrf-r="http://docs.oasis-open.org/wsrf/r-2" 
                xmlns:trc="http://www.onvif.org/ver10/recording/wsdl" 
                xmlns:tse="http://www.onvif.org/ver10/search/wsdl" 
                xmlns:trp="http://www.onvif.org/ver10/replay/wsdl" 
                xmlns:tnshik="http://www.hikvision.com/2011/event/topics" 
                xmlns:hikwsd="http://www.onvifext.com/onvif/ext/ver10/wsdl" 
                xmlns:hikxsd="http://www.onvifext.com/onvif/ext/ver10/schema" 
                xmlns:tas="http://www.onvif.org/ver10/advancedsecurity/wsdl" 
                xmlns:tr2="http://www.onvif.org/ver20/media/wsdl" 
                xmlns:axt="http://www.onvif.org/ver20/analytics">
                <env:Body>
                ...
                </env:Body>
            </env:Envelope>
             */
            writer.WriteStartElement("env", "Envelope", "http://www.w3.org/2003/05/soap-envelope");
            writer.WriteAttributeString("xmlns", "tt", null, "http://www.onvif.org/ver10/schema");
        }
    }
}
