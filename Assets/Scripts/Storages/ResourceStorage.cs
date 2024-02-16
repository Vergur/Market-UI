using System.Collections.Generic;
using UnityEngine;

public class ResourceStorage : MonoBehaviour 
{
    [SerializeField] public ResourceData[] _resourceData;

    public ResourceData GetRandomResource() => _resourceData[Random.Range(0, _resourceData.Length - 1)]; // Get 1 random resource

    public List<ResourceData> GetRandomResourceAmount(int amount) // Get a certain amount of random resources
    {
        var resourceData = new List<ResourceData>();
        for (int i = 0; i < amount; i++)
        {
            resourceData.Add(GetRandomResource());
        }

        return resourceData;
    }
}