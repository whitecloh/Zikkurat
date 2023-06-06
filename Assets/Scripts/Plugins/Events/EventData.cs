using System;
using System.Collections.Generic;

namespace Game.Plugins.Events
{
    public sealed class EventData : IEvent
    {
        public event Action EventInvoked;
        private bool _raised;


        public void Raise()
        {
            _raised = true;
        }

        public void Resolve()
        {
            if (_raised)
                EventInvoked?.Invoke();

            _raised = false;
        }
    }



    public sealed class EventData<T> : IEvent<T>
    {
        public event Action<T> EventInvoked;
        private Queue<T> _raised = new Queue<T>();


        public void Raise(T arg)
        {
            _raised.Enqueue(arg);
        }

        public void Resolve()
        {
            while (_raised.Count > 0)
                EventInvoked?.Invoke(_raised.Dequeue());
        }
    }



    public sealed class EventData<T0, T1> : IEvent<T0, T1>
    {
        public event Action<T0, T1> EventInvoked;
        private Queue<(T0, T1)> _raised = new Queue<(T0, T1)>();


        public void Raise(T0 arg0, T1 arg1)
        {
            _raised.Enqueue((arg0, arg1));
        }

        public void Resolve()
        {
            while (_raised.Count > 0)
            {
                (var arg0, var arg1) = _raised.Dequeue();
                EventInvoked?.Invoke(arg0, arg1);
            }
        }
    }
}