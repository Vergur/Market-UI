using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public abstract class ShopController : MonoBehaviour
{
    [SerializeField] private OfferingData[] _windowData; 
    [SerializeField] private OfferingView _viewPrefab;
    [SerializeField] private Button _offeringButton;
    [SerializeField] private Button _closeButton;

    private OfferingView _view;
    private void Awake()
    {
        _offeringButton.onClick.AddListener(HandlePresetOfferingButtonClick);
        _closeButton.onClick.AddListener(CloseButtonClick);
    }

    private void HandlePresetOfferingButtonClick()
    {
        _view = Instantiate(_viewPrefab, Vector3.zero, Quaternion.identity); 
        _view.Initialize(_windowData[Random.Range(0, _windowData.Length - 1)]);   // View model initialize
    }

    private void CloseButtonClick()
    {
        Destroy(_view.gameObject);
    }
}
