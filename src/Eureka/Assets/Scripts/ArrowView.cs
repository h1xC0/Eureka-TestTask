using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ArrowView : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _arrowUp;
    [SerializeField] private Button _arrownDown;

    private void OnEnable()
    {
        _arrowUp.onClick.AddListener(IncreaseNumber);
        _arrownDown.onClick.AddListener(DecreaseNumber);
    }

    private void OnDisable()
    {
        _arrowUp.onClick.RemoveListener(IncreaseNumber);
        _arrownDown.onClick.RemoveListener(DecreaseNumber);
    }

    private void SetNumber(int number) =>
         _inputField.text = number.ToString();

    private void IncreaseNumber()
    {
        if(string.IsNullOrEmpty(_inputField.text)) return;

        var number = Int32.Parse(_inputField.text);
        number += 1;
        SetNumber(number);
    }

    private void DecreaseNumber()
    {
        if(string.IsNullOrEmpty(_inputField.text)) return;
        
        var number = Int32.Parse(_inputField.text);
        number -= 1;
        SetNumber(number);
    }
}
