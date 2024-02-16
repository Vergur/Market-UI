using System;
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

    [Header("Prefabs")] 
    [SerializeField] private ResourceCellView _resourceCellPrefab;
    [SerializeField] private Transform _cellsContainer;
    
    private OfferData _data;
    
    public event Action OnCloseOffer;
    
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
        _currentPriceLabel.SetText( $"${data.PriceWithDiscount:0.00}$");
        _previousPriceLabel.SetText($"{data.PriceWithoutDiscount:0.00}$");
        _discountLabel.SetText($"{data.Discount}%");
        _bigIconImage.sprite = data.Icon;
    }

    private void CloseButton()
    {
        Debug.Log("Closed");
        OnCloseOffer?.Invoke();
    }
}
