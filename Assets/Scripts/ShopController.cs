using UnityEngine;
using UnityEngine.UI;

public abstract class ShopController : MonoBehaviour
{
    [SerializeField] private OfferingView _viewPrefab;
    [SerializeField] private Button _offeringButton;
    [SerializeField] private Button _closeButton;

    protected OfferingView _view;
    private void Awake()
    {
        _offeringButton.onClick.AddListener(HandlePresetOfferingButtonClick);
        _closeButton.onClick.AddListener(CloseButtonClick);
    }

    protected virtual void HandlePresetOfferingButtonClick()
    {
        _view = Instantiate(_viewPrefab, Vector3.zero, Quaternion.identity); 
    }

    private void CloseButtonClick()
    {
        Destroy(_view.gameObject);
    }
}
