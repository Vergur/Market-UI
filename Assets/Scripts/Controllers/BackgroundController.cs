using Controllers;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private GameObject _background;
    private void Awake()
    {
        EventsController.OnChangeBackgroundState += ChangeBackgroundState;
    }

    private void ChangeBackgroundState(bool state)
    {
        _background.SetActive(state);
    }
    
    private void OnDestroy()
    {
        EventsController.OnChangeBackgroundState -= ChangeBackgroundState;
    }
}
