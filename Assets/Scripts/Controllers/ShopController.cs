using Controllers;
using UnityEngine;
using UnityEngine.UI;

public abstract class ShopController : MonoBehaviour
{
    [Header("DefaultValues")]
    [SerializeField] private OfferView _offerViewPrefab;
    [SerializeField] private Button _offerButton;
    [SerializeField] private Transform _canvas;
    
    protected OfferView _view;
    
    private void Awake()
    {
        _offerButton.onClick.AddListener(HandlePresetOfferingButtonClick);
    }

    protected virtual void HandlePresetOfferingButtonClick()
    {
        _view = Instantiate(_offerViewPrefab, _canvas);
        EventsController.OnCloseOffer += HandleCloseButtonClick;
        EventsController.FireChangeBackgroundState(true);
    }

    private void HandleCloseButtonClick()
    {
        Destroy(_view.gameObject);
        EventsController.OnCloseOffer -= HandleCloseButtonClick;
    }

    private void OnDestroy()
    {
        EventsController.OnCloseOffer -= HandleCloseButtonClick;
    }
}
