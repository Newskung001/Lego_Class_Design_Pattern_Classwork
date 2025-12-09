using UnityEngine;

public class BossIntroState : IBossState
{
    private BossController _boss;
    private bool _reached;

    public BossIntroState(BossController boss)
    {
        _boss = boss;
    }

    public void Enter()
    {
        _boss.nav.isStopped = false;
        if (_boss.introTargetPoint != null)
            _boss.nav.SetDestination(_boss.introTargetPoint.position);

        if (_boss.animator)
            _boss.animator.SetBool("Move", true);
    }

    public void Tick()
    {
        if (_boss.introTargetPoint == null)
            return;

        if (!_reached && _boss.nav.remainingDistance <= _boss.nav.stoppingDistance)
        {
            _reached = true;
            // เมื่อถึงจุด Intro ให้เริ่มไล่ล่า
            _boss.StateMachine.ChangeState(new BossChaseState(_boss));
        }
    }

    public void Exit() { }
}
