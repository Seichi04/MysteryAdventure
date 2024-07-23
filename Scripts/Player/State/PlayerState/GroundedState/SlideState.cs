using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideState : GroundedState
{
    private float timeStart;
    float direction = 0f;
    public SlideState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        AudioManager.Instance.PlaySlideAudio(PlayerStateMachine.Player.playerAudioSource,true);
        StartAnimation(PlayerSO.PlayerAnimationData.SlideStringHash);
        PlayerStateMachine.ReusableData.TimeSlide = Time.time;
        timeStart = Time.time;
        UpdateSlideForceModifier();
        Slide();
    }

    public override void Update()
    {
        base.Update();
        PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(GetPlayerVelocity().x,GetPlayerVelocity().y);
        ResetShouldSlide();
        if(Time.time - timeStart >= PlayerSO.GroundedStateData.SlideStateData.TimeSlideMin)
        {
            OnIdle();
            OnMove();
            OnCrouch();
        }
        OnFall();
        
    }

    public override void Exit()
    {
        AudioManager.Instance.StopAudio(PlayerStateMachine.Player.playerAudioSource);
            PlayerStateMachine.ReusableData.ShouldSlide = false;

        StopAnimation(PlayerSO.PlayerAnimationData.SlideStringHash);
        base.Exit();
    }


    private void Slide()
    {
        Vector2 velocity = GetPlayerVelocity();
        float SlideForce = PlayerStateMachine.ReusableData.CurrentSlideForceModifier * PlayerSO.GroundedStateData.BaseSlideForce;
        direction = GetDirection();
        PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(SlideForce * direction,0f);

    }

    private void UpdateSlideForceModifier()
    {
        PlayerStateMachine.ReusableData.CurrentSlideForceModifier = PlayerSO.GroundedStateData.SlideStateData.SlideForceModifier;
    }

    private void ResetShouldSlide()
    {
        if(Time.time - timeStart >= PlayerSO.GroundedStateData.SlideStateData.TimeSlideMax)
        {
            PlayerStateMachine.ReusableData.ShouldSlide = false;
        }
    }

    #region ChangeState Methods
    protected override void OnIdle()
    {
        if(PlayerStateMachine.ReusableData.IsGrounded && PlayerStateMachine.ReusableData.MovementInput ==Vector2.zero)
        {
            PlayerStateMachine.ReusableData.ShouldSlide = false;
            PlayerStateMachine.ChangeState(PlayerStateMachine.IdleState);
        }
    }

    protected override void OnMove()
    {
        if( !PlayerStateMachine.ReusableData.IsGrounded || PlayerStateMachine.ReusableData.MovementInput.x == 0 
            || PlayerStateMachine.ReusableData.MovementInput.y != 0f || PlayerStateMachine.ReusableData.ShouldSlide)
        {
            return;
        }
        PlayerStateMachine.ChangeState(PlayerStateMachine.RunState);
    }

    #endregion
}
