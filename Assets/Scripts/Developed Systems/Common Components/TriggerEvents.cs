using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    public event Action<Collider> ColliderEnter;
    public event Action<Collider> OnExitEvent;


    private void OnTriggerEnter(Collider other)
    {
        ColliderEnter?.Invoke(other);
    }

    void OnTriggerExit(Collider other)
    {
        OnExitEvent?.Invoke(other);
    }
}
