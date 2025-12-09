using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int coinValue = 10;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            // แจ้งเตือน Event แทนการเรียก ScoreController โดยตรง
            EventManager.RaiseCoinCollected(coinValue);
            gameObject.SetActive(false);
        }
    }
}
