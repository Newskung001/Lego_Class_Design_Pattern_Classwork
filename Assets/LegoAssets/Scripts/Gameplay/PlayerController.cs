using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent nav;
    private float baseSpeed;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        // จำค่าความเร็วเริ่มต้นไว้
        baseSpeed = nav.speed;
    }

    void Update()
    {
        // Logic การเดินด้วยการคลิกเมาส์
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                nav.SetDestination(hit.point);
            }
        }
    }

    // --- ส่วนที่เพิ่มเข้ามาเพื่อรองรับ Command Pattern ---

    // ฟังก์ชันสำหรับ Command เรียกใช้เพื่อเพิ่มความเร็ว
    public void ApplySpeedBoost(float multiplier, float duration)
    {
        // หยุด Coroutine เก่าก่อน (กรณีเก็บซ้อน)
        StopAllCoroutines();
        StartCoroutine(SpeedBoostRoutine(multiplier, duration));
    }

    // Coroutine สำหรับนับเวลาและคืนค่าความเร็วเดิมอัตโนมัติ
    private IEnumerator SpeedBoostRoutine(float multiplier, float duration)
    {
        nav.speed = baseSpeed * multiplier;
        yield return new WaitForSeconds(duration);
        nav.speed = baseSpeed;
    }

    // ฟังก์ชันสำหรับ Undo Command เรียกใช้เพื่อรีเซ็ตความเร็วทันที
    public void ResetSpeed()
    {
        StopAllCoroutines(); // หยุดการนับถอยหลัง
        nav.speed = baseSpeed; // คืนค่าความเร็วเดิมทันที
    }
}
