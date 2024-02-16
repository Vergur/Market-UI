using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResourceCellView : MonoBehaviour
{
    [Header("DefaultValues")]
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _amount;

    public void Initialize(Sprite sprite, string name, int amount)
    {
        _image.sprite = sprite;
        _name.SetText(name);
        _amount.SetText($"x{amount}");
    }
}
