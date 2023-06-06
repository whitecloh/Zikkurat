using System.Collections.Generic;
using Game.Entities.Unit;

namespace Game.Plugins.UnitPool
{
    public interface IUnitPool
    {
        IEnumerable<IUnit> GetAllUnits();
    }
}