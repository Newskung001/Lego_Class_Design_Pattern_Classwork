using System;
using UnityEngine;

public static class EventManager
{
    // Event เมื่อเก็บเหรียญ (ส่งค่าคะแนนไปด้วย)
    public static event Action<int> OnCoinCollected;

    public static void RaiseCoinCollected(int coinValue) => OnCoinCollected?.Invoke(coinValue);

    // Event เมื่อผู้เล่นชนะ
    public static event Action OnPlayerWin;

    public static void RaisePlayerWin() => OnPlayerWin?.Invoke();
}
