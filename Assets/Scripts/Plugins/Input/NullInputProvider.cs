using System;
using UnityEngine;

namespace Game.Plugins.Input
{
    public class NullInputProvider : IInputProvider
    {
        public bool InputEnabled { get => false; set => Debug.LogWarning($"Null event set active {value}"); }

        public event Action<GameObject> PointerEnter
        {
            add => throw new NotImplementedException();
            remove => Debug.LogWarning("Null Input unsubscribe");
        }

        public event Action<GameObject> PointerExit
        {
            add => throw new NotImplementedException();
            remove => Debug.LogWarning("Null Input unsubscribe");
        }

        public event Action<GameObject> Selected
        {
            add => throw new NotImplementedException();
            remove => Debug.LogWarning("Null Input unsubscribe");
        }


        public void RaisePointerEnter(GameObject target)
        {
            throw new NotImplementedException();
        }

        public void RaisePointerExit(GameObject target)
        {
            throw new NotImplementedException();
        }

        public void RaiseSelected(GameObject target)
        {
            throw new NotImplementedException();
        }
    }
}