using UnityEngine;

[System.Serializable]
public class ResourceCell
{
    [SerializeField] private ResourceData _resourceData;
    [SerializeField] private int _quantity;

    public ResourceData ResourceData { get => _resourceData; set => _resourceData = value; }
    public int Quantity { get => _quantity; set => _quantity = value;}
}
