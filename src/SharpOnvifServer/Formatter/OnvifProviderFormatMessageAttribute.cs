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
using CoreWCF.Description;
using CoreWCF.Dispatcher;
using System;

namespace SharpOnvifServer
{
    [AttributeUsage(AttributeTargets.Method)]
    public class OnvifProviderFormatMessageAttribute : Attribute, IOperationBehavior
    {
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters) { }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation) { }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            var serializerBehavior = operationDescription.OperationBehaviors[typeof(XmlSerializerOperationBehavior)];

            if (dispatchOperation.Formatter == null)
            {
                serializerBehavior.ApplyDispatchBehavior(operationDescription, dispatchOperation);
            }

            IDispatchMessageFormatter innerDispatchFormatter = dispatchOperation.Formatter;

            dispatchOperation.Formatter = new OnvifMessageFormatter(innerDispatchFormatter);
        }

        public void Validate(OperationDescription operationDescription) { }
    }
}
