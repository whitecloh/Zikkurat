using System.Collections.Generic;
using Game.Entities.Unit;

namespace Game.Plugins.UnitPool
{
    internal class NullUnitPool : IUnitPool
    {
        public IEnumerable<IUnit> GetAllUnits()
        {
            throw new System.NotImplementedException();
        }
    }
}