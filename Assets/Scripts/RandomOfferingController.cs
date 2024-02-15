using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class RandomOfferingController : ShopController
{
    [SerializeField] private TMP_InputField _offeringsAmount;
    [SerializeField] private Sprite[] _icons;
    [SerializeField] private Sprite[] _sprites;
    [SerializeField] private ResourceStorage _resourceStorage;

    private string _title;
    private string _description;
    private float _priceWithDiscount;
    private int _discount;
    private Sprite _icon;
    private ResourceCell[] _resourceCells;
    
    protected override void HandlePresetOfferingButtonClick()
    {
        base.HandlePresetOfferingButtonClick();
        SetValues();
        Initialize(_title, _description, _priceWithDiscount, _discount, _icon, _resourceCells);
    }

    private void SetValues()
    {
        _title = "Random offer";
        _description = "This is the temporary offer";
        _priceWithDiscount = Random.Range(0, 9) + 0.99f;
        _discount = Random.Range(10, 60);
        _icon = _icons[Random.Range(0, _icons.Length - 1)];
        _resourceCells = new ResourceCell[Convert.ToInt32(_offeringsAmount.text)];
        
        foreach (var resourceCell in _resourceCells)
        {
            resourceCell.ResourceData = _resourceStorage.GetRandomResource();
            resourceCell.Quantity = Random.Range(1, 100);
        }
    }
    
    private void Initialize(string title, string description, float priceWithDiscount, int discount, Sprite icon, ResourceCell[] resourceCells)
    {
        OfferingData _data = new OfferingData();
        _data.Initialize(title, description, priceWithDiscount, discount, icon, resourceCells); // Random data initialize
        _view.Initialize(_data);   // View model initialize
    }
}
