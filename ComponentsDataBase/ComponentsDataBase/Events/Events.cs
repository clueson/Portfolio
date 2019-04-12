using Prism.Events;

/// <summary>
/// Empty pub/subs for the prsim event aggregator the events (publishers) are wired up to the correct subscribers
/// and may run a command, or respond to an event. 
/// </summary>
namespace ComponentsDataBase.Events
{
    public class Events : PubSubEvent<string>
    {
    }
    public class UpdateTagEvent : PubSubEvent<string>
    {
    }
    public class UpdateEvent : PubSubEvent<string>
    {
    }
    public class UpdateColourEvent : PubSubEvent<string>
    {
    }
    public class UpdateListBoxs : PubSubEvent<string>
    {
    }

}
