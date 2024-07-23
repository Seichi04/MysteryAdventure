using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : PlayerState
{

    public GroundedState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(PlayerSO.PlayerAnimationData.GroundedStringHash);
        PlayerStateMachine.ReusableData.NeedNewStartJump = true;
        ResetJumpCount();
    }

    public override void Update()
    {
        base.Update();
        OnJump();
        OnHit();
    }

    public override void Exit()
    {
        StopAnimation(PlayerSO.PlayerAnimationData.GroundedStringHash);
        base.Exit();

    }

    protected virtual void ResetJumpCount()
    {
        PlayerStateMachine.ReusableData.JumpCount = 0;
    }
}
