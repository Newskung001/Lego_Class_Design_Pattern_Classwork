using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChaseState : IBossState
{
    private readonly BossController _boss;
    private float _timer;

    public BossChaseState(BossController boss) { _boss = boss; }

    public void Enter()
    {
        if (_boss.animator) { _boss.animator.SetBool("Move",true); }

        _boss.nav.isStopped = false;
        _boss.nav.speed = _boss.normalSpeed;

        _timer = _boss.chaseDuration; 
    }

    public void Tick()
    {
        if (_boss.player == null) return;
        _boss.nav.SetDestination(_boss.player.position);

        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            // Time's up > move to Enrage stage
            Debug.Log("Enrage");
            _boss.StateMachine.ChangeState(new BossEnrageState(_boss));
        }
    }

    public void Exit()
    {
        // preform any action, if required 
        _boss.animator.SetBool("Move",false);
    }
}
