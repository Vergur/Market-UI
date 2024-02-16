using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour
{
    [SerializeField] private TMP_InputField _offeringsAmount;
    [SerializeField] private Button _getRandomOfferButton;
    
    public void Start()
    {
        _offeringsAmount.onValueChanged.AddListener(delegate {ValueChangeCheck(); }); // Invokes a method when the value changes
        ValueChangeCheck();
    }
    
    private void ValueChangeCheck()
    {
        _getRandomOfferButton.interactable = _offeringsAmount.text != "" && Convert.ToInt32(_offeringsAmount.text) >= 1 && Convert.ToInt32(_offeringsAmount.text) <= 6;
    }
}
