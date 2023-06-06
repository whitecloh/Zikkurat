using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Game.Entities.Unit;
using UnityEngine;

namespace Game.Plugins.UnitPool
{
    public class UnitPoolDefault : MonoBehaviour, IUnitPool
    {
        private List<Unit> units = new List<Unit>();

        [SerializeField] private GameObject _unitPrefab;


        private void Awake()
        {
            UnitPoolLocator.Provide(this);

            var unitObjects = GameObject.FindObjectsOfType<Unit>(true);
            units.AddRange(unitObjects);
        }

        private void OnDestroy()
        {
            UnitPoolLocator.Provide(null);
        }

        void LateUpdate()
        {
            CleanupUnits();
        }


        public void SpawnNew(UnitSpawnData spawnData)
        {
            if (!TryGetInactive(out Unit unit))
                unit = CreateNew(spawnData);

            SetParameters(unit, spawnData);
            unit.gameObject.SetActive(true);
        }

        public IEnumerable<IUnit> GetAllUnits()
        {
            return units.Where(t => t.State.Health > 0);
        }



        private Unit CreateNew(UnitSpawnData spawnData)
        {
            var unitObject = Instantiate(_unitPrefab, transform);
            var unit = unitObject.GetComponent<Unit>();

            var actions = unit.GetComponent<UnitActions>();
            var state = new UnitState(unit, spawnData.Stats.MaxHealth);

            unit.Actions = actions;
            unit.State = state;

            units.Add(unit);
            unit.gameObject.SetActive(false);

            return unit;
        }

        private void SetParameters(Unit unit, UnitSpawnData spawnData)
        {
            unit.Position = spawnData.Position;
            unit.Direction = spawnData.Direction;

            unit.Stats = spawnData.Stats;

            unit.SetColor(spawnData.UnitColor);
            unit.State.Health = spawnData.Stats.MaxHealth;

            //Reset action state
        }


        private void CleanupUnits()
        {
            foreach (var unit in units)
                if (unit.State.ActionState == UnitActionState.Idle && unit.State.Health <= 0)
                    unit.gameObject.SetActive(false);
        }


        private bool TryGetInactive(out Unit unit)
        {
            unit = units.FirstOrDefault(t => !t.gameObject.activeSelf);
            return unit != null;
        }
    }
}