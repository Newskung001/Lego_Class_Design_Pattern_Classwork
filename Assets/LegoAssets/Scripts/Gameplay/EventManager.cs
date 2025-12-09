using System;

public static class EventManager
{
    // public static event Action OnCoinCollected;
    // public static void RaiseCoinCollected() => OnCoinCollected?.Invoke();
    public static event Action<int> OnCoinCollected;

    public static void RaiseCoinCollected(int coinValue)
    {
        OnCoinCollected?.Invoke(coinValue);
    }
    
    public static event Action OnPlayerWin;
    public static void RaisePlayerWin() => OnPlayerWin?.Invoke();
}
