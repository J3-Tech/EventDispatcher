using System.Collections.Generic;

namespace EventDispatcher
{
    public abstract class BaseSubscriber : ISubscriber
    {
        /// <summary>
        /// Gets the subscribed events.
        /// </summary>
        /// <returns>Dictionary{System.StringType}.</returns>
        public abstract List<SubscribeEvent> GetSubscribedEvents();
    }
}