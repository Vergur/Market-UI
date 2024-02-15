using UnityEngine;

public class PrefabOfferingController : ShopController
{
    [SerializeField] private OfferingData[] _offeringData;
    protected override void HandlePresetOfferingButtonClick()
    {
        base.HandlePresetOfferingButtonClick();
        _view.Initialize(_offeringData[Random.Range(0, _offeringData.Length - 1)]);   // View model initialize
    }
}
