using UnityEngine;

[System.Serializable]
public class ResourceCell
{
    [SerializeField] private ResourceData _resourceData;
    [SerializeField] private int _quantity;

    public ResourceData ResourceData { get => _resourceData; }
    public int Quantity { get => _quantity; }
}
