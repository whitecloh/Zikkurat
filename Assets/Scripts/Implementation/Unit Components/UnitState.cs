using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Entities.Unit
{
    public class UnitState : BaseUnitComponent, IUnitState
    {
        public event Action StateChanged;

        public int Health { get => _health; set => SetHealth(value); }
        public UnitActionState ActionState { get => _actionState; set => SetActionState(value); }

        public bool LockPosition { get; set; } = false;
        public bool LockDirection { get; set; } = false;

        private int _health;
        private UnitActionState _actionState;


        public UnitState(IUnit unit, int health) : base(unit)
        {
            this._health = health;
            this._actionState = UnitActionState.Idle;
        }


        private void SetHealth(int value)
        {
            _health = value;
            StateChanged?.Invoke();
        }

        private void SetActionState(UnitActionState value)
        {
            _actionState = value;
            StateChanged?.Invoke();
        }
    }
}