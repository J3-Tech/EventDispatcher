
namespace EventDispatcher.Exception
{
    using System;

    /// <summary>
    /// Class NoRegisteredEventException
    /// </summary>
    class NoRegisteredEventException:Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoRegisteredEventException"/> class.
        /// </summary>
        /// <param name="eventName">Name of the event.</param>
        public NoRegisteredEventException(string eventName)
            : base(string.Format("No event \"{0}\" has been registered", eventName))
        {
        }
    }
}
