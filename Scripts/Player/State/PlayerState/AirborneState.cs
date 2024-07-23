using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirborneState : PlayerState
{
    protected bool ExitGround;
    public AirborneState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(PlayerSO.PlayerAnimationData.AirborneStringHash);
        ExitGround = false;
    }

    public override void Update()
    {
        base.Update();
        if(!PlayerStateMachine.ReusableData.IsGrounded)
        {
            ExitGround = true;
        }

        if(ExitGround)
        {
            OnIdle();
            OnMove();
            
        }
        OnJump();
        OnHit();
    }

    public override void Exit()
    {
        StopAnimation(PlayerSO.PlayerAnimationData.AirborneStringHash);
        base.Exit();
    }
}
