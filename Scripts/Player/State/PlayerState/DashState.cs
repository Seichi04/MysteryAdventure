using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : PlayerState
{
    private float timeStart;
    float direction = 0f;
    public DashState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        AudioManager.Instance.PlayDashAudio(PlayerStateMachine.Player.playerAudioSource);
         StartAnimation(PlayerSO.PlayerAnimationData.DashStringHash);
        PlayerStateMachine.ReusableData.TimeDash = Time.time;
        timeStart = Time.time;
        ResetVelocity();
        UpdateDashForceModifier();
        Dash();
        PlayerStateMachine.Player.GhostEffect.enabled = true;
    }

    public override void Update()
    {
        base.Update();
        PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(GetPlayerVelocity().x,0f);
        ResetShouldDash();
        OnIdle();
        OnMove();
        if(!PlayerStateMachine.ReusableData.ShouldDash)
        {
            OnJump();
            OnFall();
            OnAttack();
        }
        OnHit();
    }
    public override void Exit()
    {
        //AudioManager.Instance.StopAudio(PlayerStateMachine.Player.playerAudioSource);
        PlayerStateMachine.Player.GhostEffect.enabled = false;
        StopAnimation(PlayerSO.PlayerAnimationData.DashStringHash);
        base.Exit();
    }


    private void Dash()
    {
        Vector2 velocity = GetPlayerVelocity();
        float DashForce = PlayerStateMachine.ReusableData.CurrentDashForceModifier * PlayerSO.DashStateData.BaseDashForce;
        direction = GetDirection();
        PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(DashForce * direction,0f);

    }

    private void UpdateDashForceModifier()
    {
        PlayerStateMachine.ReusableData.CurrentDashForceModifier = PlayerSO.DashStateData.DashForceModifier;
    }

    private void ResetShouldDash()
    {
        if(Time.time - timeStart >= PlayerSO.DashStateData.TimeDash)
        {
            PlayerStateMachine.ReusableData.ShouldDash = false;
        }
    }

    #region ChangeState Methods
    protected override void OnIdle()
    {
        if(PlayerStateMachine.ReusableData.IsGrounded && PlayerStateMachine.ReusableData.MovementInput ==Vector2.zero && !PlayerStateMachine.ReusableData.ShouldDash)
        {
            PlayerStateMachine.ChangeState(PlayerStateMachine.IdleState);
        }
    }

    protected override void OnMove()
    {
        if( !PlayerStateMachine.ReusableData.IsGrounded || PlayerStateMachine.ReusableData.MovementInput.x == 0 
            || PlayerStateMachine.ReusableData.MovementInput.y != 0f || PlayerStateMachine.ReusableData.ShouldDash)
        {
            return;
        }
        PlayerStateMachine.ChangeState(PlayerStateMachine.RunState);
    }


    protected override void OnFall()
    {
        PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(0f,-0.1f);
        base.OnFall();
    }

    protected override void OnAttack()
    {
        if(PlayerStateMachine.ReusableData.ShouldAttack)
        {
            PlayerStateMachine.ChangeState(PlayerStateMachine.DashAttackState);
        }
    }

    #endregion



}
