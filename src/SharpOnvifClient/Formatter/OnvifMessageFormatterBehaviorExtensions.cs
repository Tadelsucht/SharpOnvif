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

using System.ServiceModel;

namespace SharpOnvifClient.Formatter
{
    public static class OnvifMessageFormatterBehaviorExtensions
    {
        public static void SetMessageFormatter<TChannel>(
            this ClientBase<TChannel> channel,
            System.ServiceModel.Description.IEndpointBehavior formatterBehavior = null) where TChannel : class
        {
            SetMessageFormatter(channel as TChannel, formatterBehavior);
        }

        public static void SetMessageFormatter<TChannel>(
           TChannel wcfChannel,
           System.ServiceModel.Description.IEndpointBehavior formatterBehavior = null) where TChannel : class
        {
            var channel = wcfChannel as ClientBase<TChannel>;
            if (!channel.Endpoint.EndpointBehaviors.Contains(formatterBehavior))
            {
                channel.Endpoint.EndpointBehaviors.Add(formatterBehavior);
            }
        }
    }
}
