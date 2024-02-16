using System;
using Controllers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OfferView : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Image _bigIconImage;
    [SerializeField] private Button _closeButton;
    
    [Header("Labels")]
    [SerializeField] private TextMeshProUGUI _titleLabel;
    [SerializeField] private TextMeshProUGUI _descriptionLabel;
    
    [Header("Price Values")]
    [SerializeField] private TextMeshProUGUI _currentPriceLabel;
    [SerializeField] private TextMeshProUGUI _previousPriceLabel;
    [SerializeField] private TextMeshProUGUI _discountLabel;
    [SerializeField] private GameObject _discountBox;

    [Header("Prefabs")] 
    [SerializeField] private ResourceCellView _resourceCellPrefab;
    [SerializeField] private Transform _cellsContainer;
    
    private OfferData _data;
    
    
    public void Initialize(OfferData data)
    {
        _data = data;
        _data.PriceWithoutDiscount = _data.PriceWithDiscount / (100 - _data.Discount) * 100; // Fake "real" price calculation 
        UpdateUI(_data);
        _closeButton.onClick.AddListener(CloseButton);
    }

    private void UpdateUI(OfferData data)
    {
        _titleLabel.text = data.Title;
        _descriptionLabel.text = data.Description;
        foreach (var cellData in data.ResourceCells)
        {
            var cell = Instantiate(_resourceCellPrefab, _cellsContainer);
            cell.Initialize(cellData.ResourceData.ResourceSprite, cellData.ResourceData.ResourceName, cellData.Quantity);
        }

        _discountBox.SetActive(data.IsDiscountAvailable);
        _previousPriceLabel.gameObject.SetActive(data.IsDiscountAvailable);
        
        _discountLabel.SetText($"{data.Discount}%");
        _currentPriceLabel.SetText( $"${data.PriceWithDiscount:0.00}$");
        _previousPriceLabel.SetText($"{data.PriceWithoutDiscount:0.00}$");
        _bigIconImage.sprite = data.Icon;
    }

    private void CloseButton()
    {
        Debug.Log("Closed");
        EventsController.FireCloseOffer();
        EventsController.FireChangeBackgroundState(false);
    }

    private void BuyButton()
    {
        Debug.Log("Buy");
        EventsController.FireBuyOffer();
    }
}
