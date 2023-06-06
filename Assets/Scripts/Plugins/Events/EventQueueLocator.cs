namespace Game.Plugins.Events
{
    public static class EventQueueLocator
    {
        public static IEventQueue Service { get; } = new EventQueue();
    }
}