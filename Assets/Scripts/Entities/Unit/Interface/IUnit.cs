using UnityEngine;

namespace Game.Entities.Unit
{
    public interface IUnit
    {
        Color UnitColor { get; }

        Vector3 Position { get; }
        Vector3 Direction { get; set; }

        UnitStats Stats { get; }
        IUnitState State { get; }

        IUnitActions Actions { get; }

        //Can walk to position, do actions like attack. Can have AI outside
        //What if default expected unit behaviors (like die when HP is set to 0) are also outside components (or IUnitBehaviors)? That way it's closer to ECS

        //State: color, position, direction, current locked states (position, direction), health, movement speed
        //Special state: current target for AI (handled in AI)
        //Parameters: max health, movement speed, miss and crit chance, heavy attack chance
        //Actions: move to point, lock parameters, change health, light attack, heavy attack, die
    }
}