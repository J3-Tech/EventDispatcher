using System;
using System.Collections.Generic;

namespace EventDispatcher
{
    public interface ISubscriber
    {
        Dictionary<string, Type> GetSubscribedEvents();
    }
}
