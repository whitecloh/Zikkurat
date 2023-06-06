using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.Entities.Unit
{
    //Continuous actions problem
    //Possible solution: coroutine plugin, capable of launching coroutines and providing simple waiting functions 
    //Those functions do provided actions after condition was satisfied


    public class UnitActions : UnitBehavior, IUnitActions
    {
        private const string LIGHT_ATTACK_TRIGGER = "FastAttack";
        private const string HEAVY_ATTACK_TRIGGER = "StrongAttack";
        private const string DIE_TRIGGER = "Die";

        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshMovement _movement;
        [SerializeField] private AnimationEventsHandler _animationEvents;

        [SerializeField] private AttackSender _attackSender;


        private void OnEnable()
        {
            // _movement.Stopped += OnMovementStopped;
            _animationEvents.ActionEnded += OnActionEnded;
        }

        private void OnDisable()
        {
            // _movement.Stopped -= OnMovementStopped;
            _animationEvents.ActionEnded -= OnActionEnded;
        }


        public void MoveTo(Vector3 target)
        {
            _movement.SetMovementTarget(target);
            SetActionState(UnitActionState.Moving);
        }

        public void LookAt(Vector3 target)
        {
            Unit.Direction = (target - Unit.Position);
        }

        public void StopMoving()
        {
            _movement.Stop();
            SetActionState(UnitActionState.Idle);
        }


        public void LightAttack()
        {
            _attackSender.Damage = Unit.Stats.LightAttackDamage;

            PlayTrigger(LIGHT_ATTACK_TRIGGER);
            SetActionState(UnitActionState.Attacking);
        }

        public void HeavyAttack()
        {
            _attackSender.Damage = Unit.Stats.HeavyAttackDamage;

            PlayTrigger(HEAVY_ATTACK_TRIGGER);
            SetActionState(UnitActionState.Attacking);
        }


        public void Die()
        {
            PlayTrigger(DIE_TRIGGER);
            SetActionState(UnitActionState.Dead);
        }



        private void OnActionEnded()
        {
            SetActionState(UnitActionState.Idle);
        }

        private void OnMovementStopped()
        {
            SetActionState(UnitActionState.Idle);
        }


        private void PlayTrigger(string trigger)
        {
            _animator.SetTrigger(trigger);
        }

        private void SetActionState(UnitActionState value)
        {
            Unit.State.ActionState = value;
        }
    }
}