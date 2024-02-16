using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class RandomOfferController : ShopController
{
    [Header("DefaultValues")]
    [SerializeField] private TMP_InputField _offeringsAmount;
    
    [Header("Storages")]
    [SerializeField] private ResourceStorage _resourceStorage;
    [SerializeField] private SpritesStorage _iconsStorage;

    private string _title;
    private string _description;
    private float _priceWithDiscount;
    private int _discount;
    private bool _isDiscountAvailable;
    private Sprite _icon;
    private List<ResourceCellData> _resourceCells;
    
    protected override void HandlePresetOfferingButtonClick()
    {
        base.HandlePresetOfferingButtonClick();
        SetValues();
        Initialize(_title, _description, _priceWithDiscount, _isDiscountAvailable, _discount, _icon, _resourceCells);
    }

    private void SetValues()
    {
        _title = "Random offer";
        _description = "This is the temporary offer";
        _priceWithDiscount = Random.Range(0, 10) + 0.99f;
        _isDiscountAvailable = Random.Range(0, 2) == 1;
        _discount = Random.Range(10, 60);
        _icon = _iconsStorage.GetRandomSprite();
        _resourceCells = new List<ResourceCellData>();
        for (var i = 0; i < Convert.ToInt32(_offeringsAmount.text); i++) // Cells initialization
        {
            var resourceCell = new ResourceCellData();
            resourceCell.SetValues(_resourceStorage.GetRandomResource(), Random.Range(1, 100));
            _resourceCells.Add(resourceCell);
        }
    }
    
    private void Initialize(string title, string description, float priceWithDiscount, bool isDiscountAvailable , int discount, Sprite icon, List<ResourceCellData> resourceCells)
    {
        var data = ScriptableObject.CreateInstance<OfferData>();
        data.Initialize(title, description, priceWithDiscount, isDiscountAvailable, discount, icon, resourceCells); // Random data initialize
        _view.Initialize(data);   // View model initialize
    }
}
