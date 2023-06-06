using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderValueReceiver : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> _valueChangedInt;

    [SerializeField] private Slider _slider;

    [SerializeField] private TextMeshProUGUI _minValue;
    [SerializeField] private TextMeshProUGUI _maxValue;
    [SerializeField] private TextMeshProUGUI _currentValue;


    void Awake()
    {
        _minValue.SetText(GetStringFromValue(_slider.minValue, _slider.wholeNumbers));
        _maxValue.SetText(GetStringFromValue(_slider.maxValue, _slider.wholeNumbers));

        SetValueText(_slider.value);
    }

    public void SetValueWithoutNotify(float value)
    {
        _slider.SetValueWithoutNotify(value);
        SetValueText(value);
    }


    public void OnValueChanged(float value)
    {
        _valueChangedInt?.Invoke(Convert.ToInt32(value));
        SetValueText(value);
    }



    private void SetValueText(float value)
    {
        _currentValue.SetText(GetStringFromValue(value, _slider.wholeNumbers));
    }

    private string GetStringFromValue(float value, bool wholeNumbers)
    {
        if (wholeNumbers)
            return Convert.ToInt32(value).ToString();
        else
            return value.ToString("0.00");
    }
}
