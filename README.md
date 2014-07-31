EventDispatcher
===============

[![eventdispatcher MyGet Build Status](https://www.myget.org/BuildSource/Badge/eventdispatcher?identifier=0f18d537-cbad-4690-9d24-d74fe4812600)](https://www.myget.org/)

```c#
	var engine = new Engine();
    engine.AddSubscriberFromNamespace("MyProject.Subscriber");

    engine.Dispatch("OnNewTest", new TestEvent());
    engine.Dispatch("OnTest", new TestEvent());
```