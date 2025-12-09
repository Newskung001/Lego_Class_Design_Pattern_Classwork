using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnrageState : IBossState
{
    private readonly BossController _boss;

    private enum EnragePhase { Run, Pause }
    private EnragePhase _phase;
    private float _timer;
    
    private readonly float _runDuration = 2f;
    private readonly float _pauseDuration = 1f;
    
    public BossEnrageState(BossController boss) { _boss = boss; }
    
    public void Enter()
    {
        _phase = EnragePhase.Run;
        _timer = _runDuration;

        _boss.nav.isStopped = false;
        _boss.nav.speed = _boss.enrageSpeed;

        if (_boss.animator) { _boss.animator.SetBool("Move",true); }
    }
    
    public void Tick()
    {
        if (_boss.player == null) return;

        _timer -= Time.deltaTime;

        switch (_phase)
        {
            case EnragePhase.Run:
                _boss.nav.isStopped = false;
                _boss.nav.SetDestination(_boss.player.position);

                if (_timer <= 0f)
                {
                    _phase = EnragePhase.Pause;
                    _timer = _pauseDuration;
                    _boss.nav.isStopped = true;

                    if (_boss.animator)
                        _boss.animator.SetBool("Move",false); 
                }
                break;

            case EnragePhase.Pause:
                if (_timer <= 0f)
                {
                    _phase = EnragePhase.Run;
                    _timer = _runDuration;
                    _boss.nav.isStopped = false;

                    if (_boss.animator)
                        _boss.animator.SetBool("Move",true); 
                }
                break;
        }
    }
    
    public void Exit()
    {
        _boss.nav.isStopped = false;
    }
}
