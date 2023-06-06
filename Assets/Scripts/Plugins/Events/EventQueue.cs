using System;
using System.Collections;
using System.Collections.Generic;
using Game.Entities.Unit;
using UnityEngine;

namespace Game.Plugins.Events
{
    public class EventQueue : IEventQueue
    {
        public event Action<DamageData> DamageDealt
        {
            add => _damageDealtEvent.EventInvoked += value;
            remove => _damageDealtEvent.EventInvoked -= value;
        }

        public event Action<UnitSpawnData> SpawnUnit
        {
            add => _spawnEvent.EventInvoked += value;
            remove => _spawnEvent.EventInvoked -= value;
        }


        private IEvent<DamageData> _damageDealtEvent { get; } = new EventData<DamageData>();
        private IEvent<UnitSpawnData> _spawnEvent { get; } = new EventData<UnitSpawnData>();


        public void RaiseDamageEvent(IUnit dealer, IUnit target, int damage)
        {
            var damageData = new DamageData(dealer, target, damage);
            _damageDealtEvent.Raise(damageData);
        }

        public void RaiseSpawnEvent(UnitSpawnData spawnData)
        {
            _spawnEvent.Raise(spawnData);
        }


        public void ResolveEvents()
        {
            _damageDealtEvent.Resolve();
            _spawnEvent.Resolve();
        }
    }
}