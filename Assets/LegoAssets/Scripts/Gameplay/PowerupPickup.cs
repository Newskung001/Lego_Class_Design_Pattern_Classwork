using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    public float duration = 5f;
    public float multiplier = 2f;

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerController player = col.GetComponent<PlayerController>();
            CommandManager cmdManager = FindObjectOfType<CommandManager>();

            if (player != null && cmdManager != null)
            {
                // ตรวจสอบการสะกด PowerUpCommand ให้ตรงกับชื่อ Class ในข้อ 2
                ICommand cmd = new PowerUpCommand(player, duration, multiplier);
                cmdManager.ExecuteCommand(cmd);

                gameObject.SetActive(false);
            }
        }
    }
}
