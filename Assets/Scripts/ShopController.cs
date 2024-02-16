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
        _view.OnCloseOffer += HandleCloseButtonClick;
    }

    private void HandleCloseButtonClick()
    {
        Destroy(_view.gameObject);
    }

    private void OnDestroy()
    {
        if (_view != null) _view.OnCloseOffer -= HandleCloseButtonClick;
    }
}
