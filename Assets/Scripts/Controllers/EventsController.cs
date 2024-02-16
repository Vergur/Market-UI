using System;

namespace Controllers
{
    public static class EventsController
    {
        public static Action OnCloseOffer;

        public static void FireCloseOffer()
        {
            OnCloseOffer?.Invoke();
        }
        
        public static Action OnOpenOffer;

        public static void FireOpenOffer()
        {
            OnOpenOffer?.Invoke();
        }
        
        public static Action<bool> OnChangeBackgroundState;

        public static void FireChangeBackgroundState(bool state)
        {
            OnChangeBackgroundState?.Invoke(state);
        }
    }
}