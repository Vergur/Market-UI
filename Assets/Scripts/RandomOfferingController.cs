using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


public class RandomOfferingController : ShopController
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
    private Sprite _icon;
    private List<ResourceCellData> _resourceCells;
    
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
        _icon = _iconsStorage.GetRandomSprite();
        _resourceCells = new List<ResourceCellData>(Convert.ToInt32(_offeringsAmount.text));
        foreach (var resourceCell in _resourceCells)
        {
            resourceCell.SetValues(_resourceStorage.GetRandomResource(), Random.Range(1, 100));
        }
    }
    
    private void Initialize(string title, string description, float priceWithDiscount, int discount, Sprite icon, List<ResourceCellData> resourceCells)
    {
        var data = new OfferData();
        data.Initialize(title, description, priceWithDiscount, discount, icon, resourceCells); // Random data initialize
        _view.Initialize(data);   // View model initialize
    }
}
