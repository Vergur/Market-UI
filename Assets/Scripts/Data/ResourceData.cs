using UnityEngine;

[CreateAssetMenu(fileName = "ResourceData", menuName = "Custom/Resource Data", order = 1)]
public class ResourceData : ScriptableObject // Data about resource 
{
    [SerializeField] private string _resourceName;
    [SerializeField] private Sprite _resourceSprite;
    
    public string ResourceName { get => _resourceName; }
    public Sprite ResourceSprite { get => _resourceSprite; }
}
