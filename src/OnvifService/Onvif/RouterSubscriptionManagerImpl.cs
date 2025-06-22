﻿using CoreWCF;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SharpOnvifServer.Events;

namespace OnvifService.Onvif
{
    /// <summary>
    /// Routes all incoming Subscription Manager requests to the corresponding Subscription Manager instances.
    /// </summary>
    public class RouterSubscriptionManagerImpl : SubscriptionManagerBase
    {
        private readonly ILogger<RouterSubscriptionManagerImpl> _logger;
        private readonly IEventSubscriptionManager<SubscriptionManagerImpl> _eventSubscriptionManager;

        public RouterSubscriptionManagerImpl(ILogger<RouterSubscriptionManagerImpl> logger, IEventSubscriptionManager<SubscriptionManagerImpl> eventSubscriptionManager)
        {
            _logger = logger;
            _eventSubscriptionManager = eventSubscriptionManager;
        }

        public override PullMessagesResponse PullMessages(PullMessagesRequest request)
        {
            return GetSubscriptionManager().PullMessages(request);
        }

        public override RenewResponse1 Renew(RenewRequest request)
        {
            return GetSubscriptionManager().Renew(request);
        }

        public override UnsubscribeResponse1 Unsubscribe(UnsubscribeRequest request)
        {
            var ret = GetSubscriptionManager().Unsubscribe(request);
            
            int subscriptionID = GetSubscriptionID();
            _eventSubscriptionManager.RemoveSubscription(subscriptionID);
            _logger.LogDebug($"{nameof(RouterSubscriptionManagerImpl)}: Unsubscribed {subscriptionID}");

            return ret;
        }

        public override PauseSubscriptionResponse1 PauseSubscription(PauseSubscriptionRequest request)
        {
            return GetSubscriptionManager().PauseSubscription(request);
        }

        public override ResumeSubscriptionResponse1 ResumeSubscription(ResumeSubscriptionRequest request)
        {
            return GetSubscriptionManager().ResumeSubscription(request);
        }

        public override SeekResponse Seek(SeekRequest request)
        {
            return GetSubscriptionManager().Seek(request);
        }

        public override void SetSynchronizationPoint()
        {
            GetSubscriptionManager().SetSynchronizationPoint();
        }

        private SubscriptionManagerImpl GetSubscriptionManager()
        {
            var subscription = _eventSubscriptionManager.GetSubscription(GetSubscriptionID());
            if (subscription == null)
                throw new EndpointNotFoundException($"Subscription {GetSubscriptionID()} does not exist.");
            return subscription;
        }

        /// <summary>
        /// Retrieves the Subscription ID from the <see cref="HttpContext"/>.
        /// </summary>
        /// <returns>Subscription ID of the current request.</returns>
        private static int GetSubscriptionID()
        {
            HttpContext httpContext = OperationContext.Current.IncomingMessageProperties["Microsoft.AspNetCore.Http.HttpContext"] as HttpContext;
            int subscriptionID = (int)httpContext.Items[OnvifEvents.ONVIF_SUBSCRIPTION_ID];
            return subscriptionID;
        }
    }
}
