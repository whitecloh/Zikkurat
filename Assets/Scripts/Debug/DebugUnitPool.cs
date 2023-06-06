using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Plugins.UnitPool;
using Game.Entities.Unit;
using System.Linq;

namespace Game.Debug
{
    public class DebugUnitPool : MonoBehaviour, IUnitPool
    {
        private List<IUnit> units = new List<IUnit>();


        private void Awake()
        {
            UnitPoolLocator.Provide(this);

            var unitObjects = GameObject.FindObjectOfType<Unit>();
            units.AddRange((IEnumerable<IUnit>)unitObjects);
        }

        private void OnDestroy()
        {
            UnitPoolLocator.Provide(null);
        }


        public IEnumerable<IUnit> GetAllUnits()
        {
            return units.Where(t => t.State.Health > 0);
        }
    }
}