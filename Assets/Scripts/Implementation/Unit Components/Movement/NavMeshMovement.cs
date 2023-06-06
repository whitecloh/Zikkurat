using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Game.Entities.Unit
{
    public class NavMeshMovement : UnitBehavior, IUnitMovement
    {
        private const string MOVEMENT_FORWARD = "Forward_Move";
        private const string MOVEMENT_RIGHT = "Right_Move";

        public bool IsMoving { get; private set; }
        public event Action Stopped;

        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _animator;


        public void SetMovementTarget(Vector3 target)
        {
            StopAllCoroutines();
            StartCoroutine(MovementProcess(target));
        }

        public void Stop()
        {
            StopAllCoroutines();

            IsMoving = false;
            _navMeshAgent.isStopped = true;

            UpdateAnimator();

            Stopped?.Invoke();
        }


        private IEnumerator MovementProcess(Vector3 target)
        {
            _navMeshAgent.SetDestination(target);
            _navMeshAgent.isStopped = false;

            IsMoving = true;

            while (Unit.Position != target)
            {
                UpdateAnimator();
                yield return null;
            }

            Stop();
        }



        private void UpdateAnimator()
        {
            _animator.SetFloat(MOVEMENT_FORWARD, _navMeshAgent.velocity.magnitude);
        }
    }
}