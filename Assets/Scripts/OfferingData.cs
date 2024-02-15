using UnityEngine;

[CreateAssetMenu(fileName = "ShopOffering", menuName = "Custom/Shop Offering", order = 2)]
public class OfferingData : ScriptableObject
{
    [SerializeField] private Sprite _icon;
    
    [Space] 
    [Header("Labels")]
    [SerializeField] private string _title;
    [SerializeField] private string _description;

    [Space] 
    [Header("Price Values")]
    [SerializeField] private float _discount;
    [SerializeField] private float _priceWithDiscount;
    [SerializeField] private float _priceWithoutDiscount;
    
    [Space] 
    [SerializeField] private ResourceCell[] _resourceCells; // Resources in pack
    
    public string Title { get => _title; }
    public string Description { get => _description; }
    public float PriceWithDiscount { get => _priceWithDiscount; }
    public float PriceWithoutDiscount { get => _priceWithoutDiscount; set => _priceWithoutDiscount = value; }
    public float Discount { get => _discount; }
    public Sprite Icon { get => _icon; }
    public ResourceCell[] ResourceCells { get => _resourceCells; }
}
