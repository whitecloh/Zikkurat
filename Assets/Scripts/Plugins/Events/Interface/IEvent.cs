//TODO: Determine if it's worth to use this type of events
//TODO: Improve generic events-objects concept

namespace Game.Plugins.Events
{
    public interface IEvent
    {
        event System.Action EventInvoked;

        void Raise();
        void Resolve();
    }


    public interface IEvent<T>
    {
        event System.Action<T> EventInvoked;

        void Raise(T arg);
        void Resolve();
    }


    public interface IEvent<T0, T1>
    {
        event System.Action<T0, T1> EventInvoked;

        void Raise(T0 arg0, T1 arg1);
        void Resolve();
    }


    public interface IEvent<T0, T1, T2>
    {
        event System.Action<T0, T1, T2> EventInvoked;

        void Enqueue(T0 arg0, T1 arg1, T2 arg2);
    }
}