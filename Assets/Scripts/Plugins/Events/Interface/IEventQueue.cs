using System;
using System.Collections;
using System.Collections.Generic;
using Game.Entities.Unit;
using UnityEngine;

namespace Game.Plugins.Events
{
    public interface IEventQueue
    {
        event Action<DamageData> DamageDealt;
        event Action<UnitSpawnData> SpawnUnit;

        void RaiseDamageEvent(IUnit dealer, IUnit target, int damage);
        void RaiseSpawnEvent(UnitSpawnData spawnData);

        void ResolveEvents();
    }
}