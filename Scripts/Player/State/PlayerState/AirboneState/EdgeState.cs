using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeState : AirborneState
{
    public EdgeState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(PlayerSO.PlayerAnimationData.EdgeStringHash);
        if(PlayerStateMachine.ReusableData.JumpCount==2)
        {
            PlayerStateMachine.ReusableData.JumpCount=1;
        }
    }

    public override void Update()
    {
        PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(0f,PlayerSO.AirborneStateData.EdgeStateData.AntiGravityForce);
        if(!PlayerStateMachine.ReusableData.ShouldEdge)
        {
            OnFall();
        }
        OnDash();
        OnJump();
        OnLadderGrab();
        OnAttack();
    }
    public override void Exit()
    {
        StopAnimation(PlayerSO.PlayerAnimationData.EdgeStringHash);
        base.Exit();

    }

    protected override void OnFall()
    {
        PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(0f,-PlayerSO.AirborneStateData.BaseFallSpeed);
        base.OnFall();
    }

    protected override void OnJump()
    {
        if(PlayerStateMachine.ReusableData.MovementInput.y >= 0f && PlayerStateMachine.ReusableData.JumpCount <2 
            && PlayerStateMachine.ReusableData.ShouldJump && !PlayerStateMachine.ReusableData.NeedNewStartJump)
        {
            PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(GetDirection(),PlayerSO.AirborneStateData.BaseJumpForce);
            PlayerStateMachine.ChangeState(PlayerStateMachine.JumpState);
        }
    }
}
