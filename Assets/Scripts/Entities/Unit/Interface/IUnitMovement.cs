using UnityEngine;

namespace Game.Entities.Unit
{
    public interface IUnitMovement
    {
        bool IsMoving { get; }
        event System.Action Stopped;

        void SetMovementTarget(Vector3 target);
        void Stop();
    }
}