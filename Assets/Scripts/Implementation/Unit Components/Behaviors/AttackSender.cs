using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Plugins.Events;

namespace Game.Entities.Unit
{
    public class AttackSender : UnitBehavior
    {
        public int Damage { get; set; } = 1;

        private Stack<IUnit> _detectedUnits = new Stack<IUnit>();

        [SerializeField] private Collider _attackCollider;

        [SerializeField] private AnimationEventsHandler _animationEvents;
        [SerializeField] private TriggerEvents _triggerEvents;


        void OnEnable()
        {
            _triggerEvents.ColliderEnter += OnTriggerEnter;

            _animationEvents.AttackStarted += OnAttackStarted;
            _animationEvents.AttackEnded += OnAttackEnded;
        }

        void OnDisable()
        {
            _triggerEvents.ColliderEnter -= OnTriggerEnter;

            _animationEvents.AttackStarted -= OnAttackStarted;
            _animationEvents.AttackEnded -= OnAttackEnded;
        }



        private void OnAttackStarted()
        {
            _attackCollider.enabled = true;
        }

        private void OnAttackEnded()
        {
            _attackCollider.enabled = false;
            _detectedUnits.Clear();
        }


        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<Unit>(out var otherUnit))
                return;

            if (otherUnit.UnitColor == Unit.UnitColor || _detectedUnits.Contains(otherUnit))
                return;

            _detectedUnits.Push(otherUnit);

            if (Random.Range(0, 1f) > Unit.Stats.Accuracy)
                return;

            SendAttack(otherUnit);
        }


        private void SendAttack(Unit otherUnit)
        {
            var damageMultiplier = Random.Range(0, 1f) > Unit.Stats.CritChance ? 2 : 1;

            EventQueueLocator.Service.RaiseDamageEvent(Unit, otherUnit, Damage * damageMultiplier);
        }
    }
}