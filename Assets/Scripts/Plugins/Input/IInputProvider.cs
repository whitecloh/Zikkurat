using System;
using UnityEngine;

namespace Game.Plugins.Input
{
    public interface IInputProvider
    {
        event Action<GameObject> PointerEnter;
        event Action<GameObject> PointerExit;
        event Action<GameObject> Selected;

        bool InputEnabled { get; set; }


        void RaisePointerEnter(GameObject obj);
        void RaisePointerExit(GameObject obj);
        void RaiseSelected(GameObject obj);
    }
}