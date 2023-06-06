using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Plugins.UnitPool;
using UnityEngine;

namespace Game.Entities.Unit
{
    //Замечание: задание не подразумевает адаптивного поведения, лишь простой алгоритм
    public class UnitAI : UnitBehavior
    {
        private bool IsTargetValid => CheckTarget(_target);
        private bool IsAlive => Unit.State.Health > 0;

        [SerializeField] private Vector3 _defaultDestination;

        private IUnit _target;

        private UnitActionState _aiActionState = UnitActionState.Idle;
        private Coroutine _currentProcess;


        private void OnDisable()
        {
            _aiActionState = UnitActionState.Idle;

            if (_currentProcess != null)
                StopCoroutine(_currentProcess);
        }


        void Update()
        {
            if (!IsAlive || !IsTargetValid)
                return;

            UpdateAI(_target);
        }

        void LateUpdate()
        {
            if (!IsAlive)
                return;

            if (!IsTargetValid)
                FindNewTarget();

            //If target is still not valid - go to default point
            if (!IsTargetValid && !IsAtDefaultDestination())
                Unit.Actions.MoveTo(_defaultDestination);
        }



        private void FindNewTarget()
        {
            //Find closest enemy unit
            var units = UnitPoolLocator.Service.GetAllUnits();

            _target = GetClosestEnemy(units);
        }

        private void UpdateAI(IUnit target)
        {
            if (_aiActionState != UnitActionState.Idle)
                return;

            //Attack if close
            if (IsCloseToTarget(Unit, target.Position))
            {
                SetAttacking(target);
                return;
            }

            SetMoving(target);
        }


        private void SetMoving(IUnit target)
        {
            // if (_aiActionState == UnitActionState.Moving)
            //     return;

            _aiActionState = UnitActionState.Moving;

            if (_currentProcess != null)
                StopCoroutine(_currentProcess);

            _currentProcess = StartCoroutine(ChaseProcess(target));
        }

        private void SetAttacking(IUnit target)
        {
            // if (_aiActionState == UnitActionState.Attacking)
            //     return;

            _aiActionState = UnitActionState.Attacking;

            if (_currentProcess != null)
                StopCoroutine(_currentProcess);

            _currentProcess = StartCoroutine(AttackProcess(_target));
        }


        private IEnumerator AttackProcess(IUnit target)
        {
            Unit.Actions.StopMoving();
            RollAttack(target);

            while (CheckTarget(target) && Unit.State.ActionState != UnitActionState.Idle)
            {
                Unit.Actions.LookAt(target.Position);
                yield return null;
            }

            _aiActionState = UnitActionState.Idle;

            // Debug.Log("Finished Attack!");
        }

        private IEnumerator ChaseProcess(IUnit target)
        {
            // Debug.Log($"{gameObject.name} starting chase");

            while (CheckTarget(target) && !IsCloseToTarget(Unit, target.Position))
            {
                Unit.Actions.MoveTo(target.Position);
                yield return new WaitForSeconds(0.1f);
            }

            Unit.Actions.StopMoving();
            _aiActionState = UnitActionState.Idle;

            // Debug.Log("Finished chase!");
        }


        private void RollAttack(IUnit target)
        {
            var attackRoll = UnityEngine.Random.Range(0, 1f);

            if (attackRoll < Unit.Stats.HeavyAttackChance)
                Unit.Actions.HeavyAttack();
            else
                Unit.Actions.LightAttack();
        }


        private bool CheckTarget(IUnit target) => target != null && target.State.Health > 0;

        private bool IsCloseToTarget(IUnit unit, Vector3 target)
        {
            return (unit.Position - target).sqrMagnitude <= unit.Stats.AttackDistance * unit.Stats.AttackDistance;
        }

        private bool IsAtDefaultDestination()
        {
            return IsCloseToTarget(Unit, _defaultDestination) && Unit.State.ActionState == UnitActionState.Idle;
        }


        private IUnit GetClosestEnemy(IEnumerable<IUnit> allUnits)
        {
            return allUnits.OrderBy(t => (t.Position - Unit.Position).sqrMagnitude)
                .FirstOrDefault(t => t.UnitColor != Unit.UnitColor);
        }
    }
}