namespace EventDispatcher
{
    public class SubscribeEvent
    {
        public string Name { get; set; }

        public string Method { get; set; }

        public int Priority { get; set; }

        public SubscribeEvent()
        {
        }

        public SubscribeEvent(string name, string method)
        {
            this.Name = name;
            this.Method = method;
        }

        public SubscribeEvent(string name, string method, int priority)
            : this(name, method)
        {
            this.Priority = priority;
        }
    }
}