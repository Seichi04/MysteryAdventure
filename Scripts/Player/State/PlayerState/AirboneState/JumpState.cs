using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : AirborneState
{
    private bool ExitEdge;
    public JumpState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();   
        AudioManager.Instance.PlayJumpAudio(PlayerStateMachine.Player.playerAudioSource);
        StartAnimation(PlayerSO.PlayerAnimationData.JumpStringHash);
        ExitEdge = false;
        PlayerStateMachine.ReusableData.ShouldJump = false;
        PlayerStateMachine.ReusableData.NeedNewStartJump = true;
        PlayerStateMachine.ReusableData.JumpCount++;
        UpdateCurrentJumpForceModifier();
        PlayerStateMachine.ReusableData.CurrentSpeedModifier = PlayerSO.AirborneStateData.JumpStateData.SpeedModifier;
        Jump();
    }

    public override void Update()
    {
        base.Update();
        if(!PlayerStateMachine.ReusableData.IsEdge)
        {
            ExitEdge = true;
        }
        if(ExitEdge)
        {          
            OnEdge();
        }
        OnFall();
        OnDash();
        OnLadderGrab();
        OnAttack();
    }

    public override void Exit()
    {
        AudioManager.Instance.StopAudio(PlayerStateMachine.Player.playerAudioSource);
        StopAnimation(PlayerSO.PlayerAnimationData.JumpStringHash);
        base.Exit();
    }


    private void UpdateCurrentJumpForceModifier()
    {
        PlayerStateMachine.ReusableData.CurrentJumpForceModifier = PlayerSO.AirborneStateData.JumpStateData.JumpForceModifier;
    }

    private void Jump()
    {
        Vector2 velocity = GetPlayerVelocity();
        float jumpForce = PlayerStateMachine.ReusableData.CurrentJumpForceModifier * PlayerSO.AirborneStateData.BaseJumpForce;
        PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(velocity.x,jumpForce);      
    }

    protected override void OnMove()
    {
        if( !PlayerStateMachine.ReusableData.IsGrounded || PlayerStateMachine.ReusableData.MovementInput.x == 0 || PlayerStateMachine.ReusableData.MovementInput.y < 0f)
        {
            return;
        }

        if(GetPlayerVelocity().y <=0)
            PlayerStateMachine.ChangeState(PlayerStateMachine.RunState);
    }

}
