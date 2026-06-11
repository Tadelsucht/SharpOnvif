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

        protected override XmlDictionaryReader OnGetReaderAtBodyContents()
        {
            return message.GetReaderAtBodyContents();
        }

        protected override void OnBodyToString(XmlDictionaryWriter writer)
        {
            message.WriteBodyContents(writer);
        }

        protected override void OnWriteStartBody(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("Body", "http://www.w3.org/2003/05/soap-envelope");
        }

        protected override void OnWriteStartHeaders(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("Header", "http://www.w3.org/2003/05/soap-envelope");
        }

        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            this.message.WriteBodyContents(writer);
        }

        protected override void OnWriteStartEnvelope(XmlDictionaryWriter writer)
        {
            writer.WriteStartElement("SOAP-ENV", "Envelope", "http://www.w3.org/2003/05/soap-envelope");
            writer.WriteAttributeString("xmlns", "tt", null, "http://www.onvif.org/ver10/schema");
        }
    }
}
