using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public BossStateMachine StateMachine { get; private set; }
    public NavMeshAgent nav;
    public Animator animator;
    public Transform player;
    public Transform introTargetPoint;

    // Config ค่าต่างๆ
    public float normalSpeed = 3.5f;
    public float enrageSpeed = 6f;
    public float chaseDuration = 10f;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        // หา Player จาก Tag ให้ชัวร์
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        StateMachine = new BossStateMachine();
    }

    void Start()
    {
        // เริ่มต้นด้วยสถานะ Intro
        StateMachine.Initialize(new BossIntroState(this));
    }

    void Update()
    {
        StateMachine.Tick();
    }

    // Observer: หยุดบอสเมื่อผู้เล่นชนะ
    void OnEnable() => EventManager.OnPlayerWin += HandlePlayerWin;

    void OnDisable() => EventManager.OnPlayerWin -= HandlePlayerWin;

    void HandlePlayerWin()
    {
        StateMachine.ChangeState(new BossPlayerWinState(this));
    }
}
