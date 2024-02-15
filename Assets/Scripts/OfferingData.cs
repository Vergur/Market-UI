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
    private float _priceWithoutDiscount;
    
    [Space] 
    [SerializeField] private ResourceCell[] _resourceCells; // Resources in pack

    public void Initialize(string title, string description, float priceWithDiscount, float discount, Sprite icon, ResourceCell[] resourceCells)
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
    public ResourceCell[] ResourceCells { get => _resourceCells; }
}
