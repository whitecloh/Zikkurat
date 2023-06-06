using System.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Game.Plugins.Events;
using Game.Plugins.UnitPool;
using UnityEngine;

namespace Game.Entities.Unit.Spawn
{
    public class UnitSpawner : MonoBehaviour
    {
        public UnitStats SpawnUnitStats { get => _unitStats; set => SetStats(value); }
        public float SpawnInterval { get => _spawnInterval; set => _spawnInterval = value; }

        [SerializeField] private Color _unitColor;
        [SerializeField] private UnitStats _unitStats;

        [SerializeField] private float _spawnInterval;
        [SerializeField] private int _maxAmount;
        //Spawn parameters
        //Update sends spawn message once per interval

        private Coroutine _currentProcess;


        void OnEnable()
        {
            ResetCycle();
        }

        void OnDisable()
        {
            StopCycle();
        }


        public void ResetCycle()
        {
            StopCycle();

            _currentProcess = StartCoroutine(SpawnProcess());
        }

        public void StopCycle()
        {
            if (_currentProcess != null)
                StopCoroutine(_currentProcess);
        }



        private IEnumerator SpawnProcess()
        {
            var spawnData = new UnitSpawnData(_unitColor, transform.position, transform.forward, SpawnUnitStats);

            yield return null;

            while (true)
            {
                if (GetFriendlyUnitCount() < _maxAmount)
                    EventQueueLocator.Service.RaiseSpawnEvent(spawnData);

                yield return new WaitForSeconds(SpawnInterval);
            }
        }


        private void SetStats(UnitStats value)
        {
            _unitStats = value;
            ResetCycle();
        }


        private int GetFriendlyUnitCount()
        {
            return UnitPoolLocator.Service.GetAllUnits().Count(t => t.UnitColor == _unitColor);
        }
    }
}