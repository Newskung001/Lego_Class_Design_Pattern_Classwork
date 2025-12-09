using UnityEngine;

public class BossChaseState : IBossState
{
    private BossController _boss;
    private float _timer;

    public BossChaseState(BossController boss)
    {
        _boss = boss;
    }

    public void Enter()
    {
        _boss.nav.speed = _boss.normalSpeed;
        _boss.nav.isStopped = false;
        if (_boss.animator)
            _boss.animator.SetBool("Move", true);
        _timer = _boss.chaseDuration;
    }

    public void Tick()
    {
        if (_boss.player != null)
        {
            _boss.nav.SetDestination(_boss.player.position);
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                // หมดเวลา Chase เข้าสู่โหมดโกรธ
                _boss.StateMachine.ChangeState(new BossEnrageState(_boss));
            }
        }
    }

    public void Exit() { }
}
