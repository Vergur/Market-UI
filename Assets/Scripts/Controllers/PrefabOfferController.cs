using UnityEngine;

public class PrefabOfferController : ShopController
{
    [SerializeField] private OfferData[] _offerData;
    protected override void HandlePresetOfferingButtonClick()
    {
        base.HandlePresetOfferingButtonClick();
        _view.Initialize(_offerData[Random.Range(0, _offerData.Length - 1)]);   // View model initialize
    }
}
