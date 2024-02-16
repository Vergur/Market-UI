using UnityEngine;

public class SpritesStorage : MonoBehaviour
{ 
    [SerializeField] public Sprite[] _sprites;
    public Sprite GetRandomSprite() => _sprites[Random.Range(0, _sprites.Length - 1)]; // Get 1 random offer sprite
}
