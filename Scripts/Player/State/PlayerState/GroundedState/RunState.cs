using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : GroundedState
{
    public RunState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        AudioManager.Instance.PlayMoveAudio(PlayerStateMachine.Player.playerAudioSource,true);
        StartAnimation(PlayerSO.PlayerAnimationData.RunStringHash);
        PlayerStateMachine.ReusableData.CurrentSpeedModifier = PlayerSO.GroundedStateData.RunStateData.SpeedModifier;
    }

    public override void Update()
    {
        base.Update();
        OnIdle();
        OnCrouch();
        OnDash();
        OnSlide();
        OnLadderGrab();
        OnFall();
        OnAttack();
    }

    public override void Exit()
    {
        AudioManager.Instance.StopAudio(PlayerStateMachine.Player.playerAudioSource);
        StopAnimation(PlayerSO.PlayerAnimationData.RunStringHash);
        base.Exit();
    }

    protected override void OnIdle()
    {
        if (PlayerStateMachine.ReusableData.IsGrounded && PlayerStateMachine.ReusableData.MovementInput.x == 0f && !PlayerStateMachine.ReusableData.IsAttacked)
        {
            PlayerStateMachine.ChangeState(PlayerStateMachine.IdleState);
        }

    }

}
