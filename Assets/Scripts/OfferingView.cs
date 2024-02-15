using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OfferingView : MonoBehaviour
{
    [SerializeField] private Image _bigIconImage;
    
    [Space]
    [Header("Labels")]
    [SerializeField] private TextMeshProUGUI _titleLabel;
    [SerializeField] private TextMeshProUGUI _descriptionLabel;
    [SerializeField] private TextMeshProUGUI[] _itemLabels;
    
    [Space] 
    [Header("Price Values")]
    [SerializeField] private TextMeshProUGUI _currentPriceLabel;
    [SerializeField] private TextMeshProUGUI _previousPriceLabel;
    [SerializeField] private TextMeshProUGUI _discountLabel;

    private OfferingData _data;

    public void Initialize(OfferingData data)
    {
        _data = data;
        _data.PriceWithoutDiscount = _data.PriceWithoutDiscount / (100 - _data.Discount) * 100; // Fake "real" price calculation 
        UpdateUI(_data);
    }

    private void UpdateUI(OfferingData data)
    {
        _titleLabel.text = data.Title;
        _descriptionLabel.text = data.Description;
        for (int i = 0; i < _itemLabels.Length; i++)
        {
            _itemLabels[i].text = $"{data.ResourceCells[i].ResourceData.ResourceName} x{data.ResourceCells[i].Quantity}";
        }
        _currentPriceLabel.SetText( $"Current price: ${data.PriceWithDiscount}");
        _previousPriceLabel.SetText($"{data.PriceWithoutDiscount}");
        _discountLabel.SetText($"{data.Discount}%");
        _bigIconImage.sprite = data.Icon;
    }
}
