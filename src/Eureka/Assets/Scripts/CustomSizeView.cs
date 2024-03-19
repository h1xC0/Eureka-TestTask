using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text;
using DG.Tweening;

public class CustomSizeView : MonoBehaviour
{
    [SerializeField] private CanvasGroup _customSizeGroup;
    [SerializeField] private Toggle _customSize;
    [SerializeField] private DropdownView _dropdownView; 
    [SerializeField] private Button _okButton;

    [SerializeField] private TMP_InputField _widthField;
    [SerializeField] private TMP_InputField _heightField;


    private void Start()
    {
        _okButton.onClick.AddListener(ApplyChanges);
        _customSize.onValueChanged.AddListener(ShowCustom);
    }

    private void OnDestroy()
    {
        _okButton.onClick.RemoveListener(ApplyChanges);
    }

    private void ApplyChanges()
    {
        _widthField.text = string.IsNullOrEmpty(_widthField.text) ? "0" : _widthField.text;
        _heightField.text = string.IsNullOrEmpty(_heightField.text) ? "0" : _heightField.text;

        var resolutionStringBuilder = new StringBuilder();
        resolutionStringBuilder.Append(_widthField.text);
        resolutionStringBuilder.Append("x");
        resolutionStringBuilder.Append(_heightField.text);

        var resolutionText = resolutionStringBuilder.ToString();

        var newOption = new TMP_Dropdown.OptionData(resolutionText, null);
        _dropdownView.AddNewOption(newOption);

        _dropdownView.SetLabelBackground(true);
    }

    private void ShowCustom(bool flag)
    {
        _customSizeGroup.DOFade(flag ? 1 : 0, 0.5f)
        .OnComplete(() => 
        {
            _customSizeGroup.interactable = flag;
            _customSizeGroup.blocksRaycasts = flag;
        });
    }
}
