using System;
using System.Collections;
using System.Collections.Generic;
using Game.Plugins.Events;
using UnityEngine;

namespace Game.Controller
{
    //Resolve all events (damage, spawn)
    //Usually it's game rules that oversee this
    public class GameEventsResolver : MonoBehaviour
    {
        void OnEnable()
        {
            EventQueueLocator.Service.DamageDealt += OnDamageDealt;
        }

        void OnDisable()
        {
            EventQueueLocator.Service.DamageDealt -= OnDamageDealt;
        }

        void Update()
        {
            EventQueueLocator.Service.ResolveEvents();
        }



        private void OnDamageDealt(DamageData damageData)
        {
            // Debug.Log($"{damageData.Dealer} deals {damageData.Damage} damage to {damageData.Target}");

            damageData.Target.State.Health -= damageData.Damage;

            if (damageData.Target.State.Health > 0)
                return;

            damageData.Target.Actions.StopMoving();
            damageData.Target.Actions.Die();
        }
    }
}