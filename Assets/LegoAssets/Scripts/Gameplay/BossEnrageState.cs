using UnityEngine;

public class BossEnrageState : IBossState
{
    private BossController _boss;

    // เพิ่ม Logic วิ่งสลับหยุด (Phase) ตามสไลด์
    private enum EnragePhase
    {
        Run,
        Pause,
    }

    private EnragePhase _phase;
    private float _timer;
    private float runDuration = 2f;
    private float pauseDuration = 1f;

    public BossEnrageState(BossController boss)
    {
        _boss = boss;
    }

    public void Enter()
    {
        _phase = EnragePhase.Run;
        _timer = runDuration;

        _boss.nav.speed = _boss.enrageSpeed;
        _boss.nav.isStopped = false;
        if (_boss.animator)
            _boss.animator.SetBool("Move", true);
    }

    public void Tick()
    {
        if (_boss.player == null)
            return;

        _timer -= Time.deltaTime;

        switch (_phase)
        {
            case EnragePhase.Run:
                _boss.nav.isStopped = false;
                _boss.nav.SetDestination(_boss.player.position);
                if (_boss.animator)
                    _boss.animator.SetBool("Move", true);

                if (_timer <= 0)
                {
                    _phase = EnragePhase.Pause;
                    _timer = pauseDuration;
                }
                break;

            case EnragePhase.Pause:
                _boss.nav.isStopped = true;
                if (_boss.animator)
                    _boss.animator.SetBool("Move", false);

                if (_timer <= 0)
                {
                    _phase = EnragePhase.Run;
                    _timer = runDuration;
                }
                break;
        }
    }

    public void Exit() { }
}
