using System.Collections;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

public abstract class ShopController : MonoBehaviour
{
    [Header("DefaultValues")]
    [SerializeField] private OfferView _offerViewPrefab;
    [SerializeField] private Button _offerButton;
    [SerializeField] private Transform _canvas;
    [SerializeField] private GameObject _purchasedWindow;
    
    protected OfferView _view;
    
    private void Awake()
    {
        _offerButton.onClick.AddListener(HandlePresetOfferingButtonClick);
    }

    protected virtual void HandlePresetOfferingButtonClick()
    {
        _view = Instantiate(_offerViewPrefab, _canvas);
        EventsController.OnCloseOffer += HandleCloseButtonClick;
        EventsController.OnPurchaseOffer += HandlePurchaseButtonClick;
        EventsController.FireChangeBackgroundState(true);
    }

    private void HandleCloseButtonClick()
    {
        if (_view != null) Destroy(_view.gameObject);
        EventsController.OnCloseOffer -= HandleCloseButtonClick;
    }
    
    private void HandlePurchaseButtonClick()
    {
        if (_view != null) Destroy(_view.gameObject);
        EventsController.OnPurchaseOffer -= HandlePurchaseButtonClick;
        StartCoroutine(PurchasedWindowControl());
    }

    private IEnumerator PurchasedWindowControl()
    {
        _purchasedWindow.SetActive(true);
        yield return new WaitForSeconds(1);
        _purchasedWindow.SetActive(false);
    }

    private void OnDestroy()
    {
        EventsController.OnCloseOffer -= HandleCloseButtonClick;
        EventsController.OnPurchaseOffer -= HandlePurchaseButtonClick;
    }
}
