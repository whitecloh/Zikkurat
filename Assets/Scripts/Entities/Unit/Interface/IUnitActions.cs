using UnityEngine;

namespace Game.Entities.Unit
{
    //Actions: move to point, light attack, heavy attack, die
    public interface IUnitActions
    {
        void MoveTo(Vector3 target);

        void LookAt(Vector3 target);

        void LightAttack();
        void HeavyAttack();

        void Die();
        void StopMoving();
    }
}