using System;
using System.Collections.Generic;

namespace EventDispatcher
{
    /// <summary>
    /// Interface ISubscriber
    /// </summary>
    public interface ISubscriber
    {
        /// <summary>
        /// Gets the subscribed events.
        /// </summary>
        /// <returns>Dictionary{System.StringType}.</returns>
        Dictionary<string, Type> GetSubscribedEvents();
    }
}
