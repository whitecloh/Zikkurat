using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Plugins.Input
{
    public sealed class InputPresenter : MonoBehaviour, IInputProvider
    {
        public event Action<GameObject> PointerEnter;
        public event Action<GameObject> PointerExit;
        public event Action<GameObject> Selected;

        public bool InputEnabled { get => enabled; set => ToggleInput(value); }

        [SerializeField] private InputReceiver _inputReceiver;


        void Awake()
        {
            InputLocator.Provide(this);
        }

        void OnDestroy()
        {
            InputLocator.Provide(null);
        }


        public void RaisePointerEnter(GameObject target)
        {
            PointerEnter?.Invoke(target);
        }

        public void RaisePointerExit(GameObject target)
        {
            PointerExit?.Invoke(target);
        }

        public void RaiseSelected(GameObject target)
        {
            Selected?.Invoke(target);
        }



        private void ToggleInput(bool value)
        {
            enabled = value;
        }
    }
}