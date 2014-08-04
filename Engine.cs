using System;
using System.Collections.Generic;
using System.Linq;

namespace EventDispatcher
{
    using EventDispatcher.Exception;
    using System.Reflection;

    public class Engine
    {
        private readonly List<ISubscriber> subscribers = new List<ISubscriber>();

        /// <summary>
        /// Adds the subscribers from namespace.
        /// </summary>
        /// <param name="nameSpace">The namespace.</param>
        public void AddSubscribersFromNamespace(string nameSpace)
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

        /// <summary>
        /// Dispatches the specified event name.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        /// <param name="evt">The event.</param>
        /// <exception cref="EventDispatcher.Exception.NoRegisteredEventException"></exception>
        public void Dispatch(string eventName, IEvent evt)
        {
            foreach (var subscriber in subscribers)
            {
                if (subscriber.GetSubscribedEvents().All(s => s.Name != eventName))
                {
                    throw new NoRegisteredEventException(eventName);
                }
                var item = subscriber.GetSubscribedEvents().OrderBy(s => s.Priority).First(s => s.Name == eventName);
                var instance = Activator.CreateInstance(subscriber.GetType());
                var methodInfo = instance.GetType().GetMethod(item.Method);
                if (methodInfo != null)
                {
                    methodInfo.Invoke(instance, new object[] { evt });
                }
                else
                {
                    throw new NoRegisteredEventException(item.Name);
                }
            }
        }

        /// <summary>
        /// Gets the types in namespace.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <param name="nameSpace">The namespace.</param>
        /// <returns>IEnumerable{Type}.</returns>
        private static IEnumerable<Type> GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            return assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
        }
    }
}