using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game.Plugins.Events
{
    public sealed class EventQueueListener : MonoBehaviour
    {
        [SerializeField] private UnityEvent<DamageData> _damageDealt;
        [SerializeField] private UnityEvent<UnitSpawnData> _spawnUnit;


        void OnEnable()
        {
            EventQueueLocator.Service.DamageDealt += OnDamageDealt;
            EventQueueLocator.Service.SpawnUnit += OnSpawnUnit;
        }

        void OnDisable()
        {
            EventQueueLocator.Service.DamageDealt -= OnDamageDealt;
            EventQueueLocator.Service.SpawnUnit -= OnSpawnUnit;
        }



        private void OnDamageDealt(DamageData damageData) => _damageDealt?.Invoke(damageData);
        private void OnSpawnUnit(UnitSpawnData spawnData) => _spawnUnit?.Invoke(spawnData);
    }
}