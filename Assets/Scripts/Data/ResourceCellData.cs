using UnityEngine;

[System.Serializable]
public class ResourceCellData // Data about resources in the cell
{
    [SerializeField] private ResourceData _resourceData; 
    [SerializeField] private int _quantity;

    public ResourceData ResourceData { get => _resourceData; set => _resourceData = value; }
    public int Quantity { get => _quantity; set => _quantity = value;}

    public void SetValues(ResourceData resourceData, int quantity)
    {
        _resourceData = resourceData;
        _quantity = quantity;
    }
}
