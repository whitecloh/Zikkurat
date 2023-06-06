using UnityEngine;

namespace Game.Entities.Unit
{
    public abstract class UnitBehavior : MonoBehaviour
    {
        public IUnit Unit => _unit;
        [SerializeField] private Unit _unit;
    }
}