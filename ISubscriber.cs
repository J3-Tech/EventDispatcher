using System.Collections.Generic;

namespace EventDispatcher
{
    /// <summary>
    /// Interface ISubscriber
    /// </summary>
    public interface ISubscriber
    {
        List<SubscribeEvent> GetSubscribedEvents();
    }
}