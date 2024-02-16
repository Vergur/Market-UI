using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopOffer", menuName = "Custom/Shop Offer", order = 2)]
public class OfferData : ScriptableObject
{
    [Header("Offer Icon")]
    [SerializeField] private Sprite _icon;
    
    [Header("Labels")]
    [SerializeField] private string _title;
    [SerializeField] private string _description;

    [Header("Price Values")]
    [SerializeField] private float _discount;
    [SerializeField] private float _priceWithDiscount;
    private float _priceWithoutDiscount;
    
    [Space] 
    [SerializeField] private List<ResourceCellData> _resourceCells; // Resources in offer

    public void Initialize(string title, string description, float priceWithDiscount, float discount, Sprite icon, List<ResourceCellData> resourceCells)
    {
        _title = title;
        _description = description;
        _priceWithDiscount = priceWithDiscount;
        _discount = discount;
        _icon = icon;
        _resourceCells = resourceCells;
    }

    public string Title { get => _title; }
    public string Description { get => _description; }
    public float PriceWithDiscount { get => _priceWithDiscount; }
    public float PriceWithoutDiscount { get => _priceWithoutDiscount; set => _priceWithoutDiscount = value; }
    public float Discount { get => _discount; }
    public Sprite Icon { get => _icon; }
    public List<ResourceCellData> ResourceCells { get => _resourceCells; }
}
