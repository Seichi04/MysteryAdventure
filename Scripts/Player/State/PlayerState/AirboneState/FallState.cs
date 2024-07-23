using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : AirborneState
{
    public FallState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(PlayerSO.PlayerAnimationData.FallStringHash);
        PlayerStateMachine.ReusableData.CurrentSpeedModifier = PlayerSO.AirborneStateData.FallStateData.SpeedModifier;
        Fall();
    }

    public override void Update()
    {
        base.Update();
        OnDash();
        OnEdge();
        OnLadderGrab();
        OnWallSlide();
        OnAttack();
    }

    public override void Exit()
    {
        StopAnimation(PlayerSO.PlayerAnimationData.FallStringHash);
        base.Exit();

    }

    protected override void Move()
    {
        if(PlayerStateMachine.ReusableData.MovementInput.x == 0f || PlayerStateMachine.ReusableData.CurrentSpeedModifier <=0.1f 
                || PlayerStateMachine.ReusableData.ShouldDash || PlayerStateMachine.ReusableData.ShouldSlide)
        {
            return;
        }
        float movementSpeed = GetCurrentMovementSpeed()/1.2f;
        Vector2 currentVelocity = GetPlayerVelocity();
        PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(movementSpeed * PlayerStateMachine.ReusableData.MovementInput.x,currentVelocity.y);
    }

    private void Fall()
    {
        Vector2 velocity = GetPlayerVelocity();
        PlayerStateMachine.ReusableData.CurrentFallSpeedModifier = PlayerSO.AirborneStateData.FallStateData.FallSpeedModifier;
        float fallSpeed = PlayerSO.AirborneStateData.BaseFallSpeed * PlayerStateMachine.ReusableData.CurrentFallSpeedModifier;
        if(PlayerStateMachine.ReusableData.MovementInput.x!=0f)
            PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(velocity.x/1.2f,-fallSpeed);
        else
            PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(0f,-fallSpeed);
    }

    protected override void OnIdle()
    {
        if(PlayerStateMachine.ReusableData.IsGrounded && PlayerStateMachine.ReusableData.MovementInput.x ==0f)
        {
            AudioManager.Instance.PlayLandAudio(PlayerStateMachine.Player.playerAudioSource);
            PlayerStateMachine.ChangeState(PlayerStateMachine.IdleState);
        }
    }

    protected override void OnWallSlide()
    {
        if(PlayerStateMachine.ReusableData.IsWallFront)
        {
            if(GetPlayerVelocity().y < 0f )
            {
                if(PlayerStateMachine.ReusableData.MovementInput.x>0f  && PlayerStateMachine.ReusableData.IsRight)
                {
                    if(PlayerStateMachine.ReusableData.IsWallFront)
                    {
                        PlayerStateMachine.ChangeState(PlayerStateMachine.WallSlideState);
                    }
                }
                else if(PlayerStateMachine.ReusableData.MovementInput.x<0f  && !PlayerStateMachine.ReusableData.IsRight)
                {
                    if(PlayerStateMachine.ReusableData.IsWallFront)
                    {
                        PlayerStateMachine.ChangeState(PlayerStateMachine.WallSlideState);
                    }
                }

            }
        }
    }
}
