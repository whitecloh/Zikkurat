using System.Collections;
using System.Collections.Generic;
using Game.Entities.Unit;
using UnityEngine;

namespace Game.Debug
{
    [RequireComponent(typeof(Unit))]
    public class DebugUnitInitializer : MonoBehaviour
    {
        [SerializeField] private Color _unitColor;
        [SerializeField] private UnitStats _unitStats;
        [SerializeField] private Animator _animator;

        [SerializeField] private bool _startMoving;
        [SerializeField] private Vector3 _movementTarget;


        // Start is called before the first frame update
        void Awake()
        {
            var unit = GetComponent<Unit>();
            var actions = GetComponent<UnitActions>();

            var state = new UnitState(unit, _unitStats.MaxHealth);

            unit.Actions = actions;
            unit.State = state;
            unit.Stats = _unitStats;

            unit.SetColor(_unitColor);

            if (_startMoving)
                unit.Actions.MoveTo(_movementTarget);
        }
    }
}