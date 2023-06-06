using System.Collections;
using System.Collections.Generic;
using Game.Entities.Unit;
using UnityEngine;

namespace Game.Plugins.Events
{
    public struct DamageData
    {
        public IUnit Dealer;
        public IUnit Target;

        public int Damage;


        public DamageData(IUnit dealer, IUnit target, int damage)
        {
            Dealer = dealer;
            Target = target;
            Damage = damage;
        }
    }
}