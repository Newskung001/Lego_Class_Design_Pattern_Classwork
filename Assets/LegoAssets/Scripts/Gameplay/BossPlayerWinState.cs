using UnityEngine;

public class BossPlayerWinState : IBossState
{
    private BossController _boss;

    public BossPlayerWinState(BossController boss)
    {
        _boss = boss;
    }

    public void Enter()
    {
        _boss.nav.isStopped = true;
        _boss.nav.ResetPath();
        if (_boss.animator)
        {
            _boss.animator.SetBool("Move", false);
            _boss.animator.SetTrigger("Die"); // หรือเล่น Animation แพ้
        }
    }

    public void Tick() { }

    public void Exit() { }
}
