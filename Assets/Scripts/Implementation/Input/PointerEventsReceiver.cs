using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Game.Plugins.Input
{
    public sealed class PointerEventsReceiver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] private UnityEvent PointerEnter;
        [SerializeField] private UnityEvent PointerExit;
        [SerializeField] private UnityEvent Selected;


        public void OnPointerClick(PointerEventData eventData)
        {
            Selected?.Invoke();
            InputLocator.Service.RaiseSelected(gameObject);
        }


        public void OnPointerEnter(PointerEventData eventData)
        {
            PointerEnter?.Invoke();
            InputLocator.Service.RaisePointerEnter(gameObject);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PointerExit?.Invoke();
            InputLocator.Service.RaisePointerExit(gameObject);
        }
    }
}