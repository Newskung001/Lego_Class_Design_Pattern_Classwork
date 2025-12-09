using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
    public NavMeshAgent nav;
    public Animator animator;
    public Transform player;

    // public fields used by states
    public float normalSpeed = 3.5f;
    public float enrageSpeed = 6f;
    public float chaseDuration = 5f;

    public Transform introTargetPoint;

    public BossStateMachine StateMachine { get; private set; }

    void Awake()
    {
        if (nav == null) nav = GetComponent<NavMeshAgent>();
        if (animator == null) animator = GetComponent<Animator>();
        if (player == null)
        {
            var playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null) player = playerObj.transform;
        }
        StateMachine = new BossStateMachine();
    }

    void Start()
    {
        // Start with chasing state
        StateMachine.ChangeState(new BossChaseState(this));
    }

    void Update()
    {
        StateMachine?.Tick();
    }

    public void ChangeToChaseState()
    {
        StateMachine.ChangeState(new BossChaseState(this));
    }

    public void ChangeToEnrageState()
    {
        StateMachine.ChangeState(new BossEnrageState(this));
    }
}
