using System;
using System.Collections.Generic;
using System.Linq;

namespace EventDispatcher
{
    using System.Reflection;

    public class Engine
    {
        private readonly List<ISubscriber> subscribers = new List<ISubscriber>();

        public void AddSubscriberFromNamespace(string nameSpace)
        {
            var types = GetTypesInNamespace(Assembly.GetCallingAssembly(), nameSpace);
            foreach (var type in types)
            {
                if (!type.IsClass || type.IsAbstract) continue;
                var obj = Activator.CreateInstance(type);
                if (obj is ISubscriber)
                {
                    this.subscribers.Add(obj as ISubscriber);
                }
            }
        }

        public void Dispatch(string eventName, IEvent evt)
        {
            foreach (var subscriber in subscribers)
            {
                if (subscriber.GetSubscribedEvents().All(s => s.Key != eventName)) continue;
                var foo = subscriber.GetSubscribedEvents().First(s => s.Key == eventName);
                var obj = Activator.CreateInstance(foo.Value);
                var mInfo = obj.GetType().GetMethod(foo.Key);
                if (mInfo != null)
                {
                    mInfo.Invoke(obj, new object[] { evt });
                }
            }
        }

        private static IEnumerable<Type> GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }
    }
}
