using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class DropdownView : MonoBehaviour
{
    [SerializeField] private TMP_Text _dropDownLabel;
    [SerializeField] private Image _labelBackground;
    [SerializeField] private TMP_Dropdown _resolutionDropDown;
    [SerializeField] private TMP_Text _selectedResolutionTMP;


    private void OnEnable()
    {
        _resolutionDropDown.onValueChanged.AddListener(_ => 
        {
            SetLabelBackground(false);
            RefreshCaptionText();
        });
        _selectedResolutionTMP.text = $"Selected size: {_dropDownLabel.text} mm";
    }

    private void OnDisable()
    {
        _resolutionDropDown.onValueChanged.RemoveAllListeners();
        _selectedResolutionTMP.text = $"Selected size: {_dropDownLabel.text} mm";
    }


    public void SetLabelBackground(bool flag)
    {
        _labelBackground.enabled = flag;
        _dropDownLabel.color = flag ? Color.white : Color.black;
    }
    private void RefreshCaptionText()
    {
        Debug.Log($"Index of dropdown: {_resolutionDropDown.value}");
        // _resolutionDropDown.captionText.text = _resolutionDropDown.options[_resolutionDropDown.value].text;
    }

    public void AddNewOption(TMP_Dropdown.OptionData optionData)
    {
        _selectedResolutionTMP.text = $"Selected size: {optionData.text} mm";
        // _resolutionDropDown.captionText.text = optionData.text;

        var fadeSpeed = _resolutionDropDown.alphaFadeSpeed;
        var optionList = new List<TMP_Dropdown.OptionData>();
        optionList.AddRange(_resolutionDropDown.options);
        optionList.Add(optionData);

        _resolutionDropDown.ClearOptions();
        _resolutionDropDown.AddOptions(optionList);

        _resolutionDropDown.SetValueWithoutNotify(_resolutionDropDown.options.Count - 1);

        // StartCoroutine(ChangeValue(_resolutionDropDown.options.Count - 1));

        _resolutionDropDown.alphaFadeSpeed = 0;
        _resolutionDropDown.RefreshShownValue();
        _resolutionDropDown.RefreshOptions();
        _resolutionDropDown.alphaFadeSpeed = fadeSpeed;
        _resolutionDropDown.Hide();
    }

    private IEnumerator ChangeValue(int newValue)
    {
        _resolutionDropDown.Select();
        yield return new WaitForEndOfFrame();
        _resolutionDropDown.value = newValue;
        _resolutionDropDown.RefreshShownValue();
    }
}
