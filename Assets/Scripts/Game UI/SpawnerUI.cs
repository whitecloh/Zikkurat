using UnityEngine;
using Game.Plugins.Input;
using Game.Entities.Unit.Spawn;
using System;
using System.Collections;

namespace Game.UI
{
    public class SpawnerUI : MonoBehaviour
    {
        public bool SelectionInProgress { get; private set; }

        //Add all sliders?
        [SerializeField] private SliderValueReceiver _healthSlider;
        [SerializeField] private SliderValueReceiver _lightDamageSlider;
        [SerializeField] private SliderValueReceiver _heavyDamageSlider;
        [SerializeField] private SliderValueReceiver _accuracySlider;
        [SerializeField] private SliderValueReceiver _critChanceSlider;
        [SerializeField] private SliderValueReceiver _heavyAttackChanceSlider;

        [SerializeField] private PanelBehavior _panelBehavior;


        private UnitSpawner _currentSpawner;
        private UnitStats _currentUnitStats;


        IEnumerator Start()
        {
            yield return null;

            InputLocator.Service.Selected += OnObjectSelected;
        }


        // Start is called before the first frame update
        void OnEnable()
        {
            try
            {
                InputLocator.Service.Selected += OnObjectSelected;
            }
            catch
            {
                Debug.LogWarning("Failed to subscribe");
            }
        }

        // Update is called once per frame
        void OnDisable()
        {
            InputLocator.Service.Selected -= OnObjectSelected;
        }


        //TODO: Update initial slider values
        public void StartSelection(UnitSpawner spawner)
        {
            _currentSpawner = spawner;
            _currentUnitStats = spawner.SpawnUnitStats;

            SetSliders(spawner.SpawnUnitStats);

            SelectionInProgress = true;
            _panelBehavior.Expand();
        }

        public void ConfirmSelection()
        {
            _currentSpawner.SpawnUnitStats = _currentUnitStats;

            SelectionInProgress = false;
            _panelBehavior.Hide();
        }

        public void StopSelection()
        {
            SelectionInProgress = false;
            _panelBehavior.Hide();
        }


        public void UI_SetHealth(int value)
        {
            _currentUnitStats.MaxHealth = value;
        }

        public void UI_SetLightDamage(int value)
        {
            _currentUnitStats.LightAttackDamage = value;
        }

        public void UI_SetHeavyDamage(int value)
        {
            _currentUnitStats.HeavyAttackDamage = value;
        }

        public void UI_SetAccuracy(float value)
        {
            _currentUnitStats.Accuracy = value;
        }

        public void UI_SetCritChance(float value)
        {
            _currentUnitStats.CritChance = value;
        }

        public void UI_SetHeavyAttackChance(float value)
        {
            _currentUnitStats.HeavyAttackChance = value;
        }



        private void OnObjectSelected(GameObject obj)
        {
            if (SelectionInProgress)
                return;

            if (!obj.TryGetComponent<UnitSpawner>(out var spawner))
                return;

            StartSelection(spawner);
        }


        private void SetSliders(UnitStats spawnUnitStats)
        {
            _healthSlider.SetValueWithoutNotify(spawnUnitStats.MaxHealth);
            _lightDamageSlider.SetValueWithoutNotify(spawnUnitStats.LightAttackDamage);
            _heavyDamageSlider.SetValueWithoutNotify(spawnUnitStats.HeavyAttackDamage);
            _accuracySlider.SetValueWithoutNotify(spawnUnitStats.Accuracy);
            _critChanceSlider.SetValueWithoutNotify(spawnUnitStats.CritChance);
            _heavyAttackChanceSlider.SetValueWithoutNotify(spawnUnitStats.HeavyAttackChance);
        }
    }
}