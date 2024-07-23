using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtState : HitState
{
    private bool isAnimationFinish;
    private float timeStart;
    public HurtState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        PlayerStateMachine.Player.Input.OnDisable();
        KnockBack();
        PlayerStateMachine.ReusableData.TimeHurt = Time.time;
        StartAnimation(PlayerSO.PlayerAnimationData.HurtStringHash);
        isAnimationFinish = false;
        timeStart = Time.time;
    }

    public override void Update()
    {
        //base.Update();
        if(isAnimationFinish)
        {
            OnIdle();
            OnMove();
            OnFall();
            OnJump();
        }

        if(Time.time - timeStart > 0.35f)
        {
            OnIdle();
            OnMove();
            OnFall();
            OnJump();
        }
    }

    public override void Exit()
    {
        PlayerStateMachine.Player.Input.OnEnable();
        StopAnimation(PlayerSO.PlayerAnimationData.HurtStringHash);
        base.Exit();
    }

    public override void OnAnimationExitEvent()
    {
        base.OnAnimationExitEvent();
        isAnimationFinish = true;
    }
}
