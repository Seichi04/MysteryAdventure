using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallSlideState : AirborneState
{
    private float velocity;
    public WallSlideState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        AudioManager.Instance.PlaySlideAudio(PlayerStateMachine.Player.playerAudioSource,true);
        base.Enter();
        StartAnimation(PlayerSO.PlayerAnimationData.WallSlideStringHash);
        PlayerStateMachine.ReusableData.CurrentWallSlideSpeedModifier = PlayerSO.AirborneStateData.BaseWallSlideSpeed;
        Rotate();
        // if(PlayerStateMachine.ReusableData.JumpCount==2)
        // {
        //     PlayerStateMachine.ReusableData.JumpCount=1;
        // }

    }

    public override void Update()
    {
        Move();
        UpdateColliderState();
        if(!PlayerStateMachine.ReusableData.IsGrounded)
        {
            ExitGround = true;
        }
        WallSlide();

        if(ExitGround)
        {
            OnIdle();
            OnMove();
            if(!PlayerStateMachine.ReusableData.IsWallBack && !PlayerStateMachine.ReusableData.IsWallFront)
            {
                OnFall();
            }
        }
        OnJump();

        OnDash();
        OnLadderGrab();
        OnHit();
        
    }
    public override void Exit()
    {
        AudioManager.Instance.StopAudio(PlayerStateMachine.Player.playerAudioSource);
        StopAnimation(PlayerSO.PlayerAnimationData.WallSlideStringHash);
        base.Exit();
    }

    private void WallSlide()
    {
        velocity = GetSpeedWallSlide();
        PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(0f, -velocity);
    }


    private float GetSpeedWallSlide()
    {
        return PlayerStateMachine.ReusableData.CurrentWallSlideSpeedModifier * PlayerSO.AirborneStateData.BaseWallSlideSpeed;
    }

    protected override void Rotate()
    {
        Vector2 Input = PlayerStateMachine.ReusableData.MovementInput;
        bool IsRight = PlayerStateMachine.ReusableData.IsRight;
        if( PlayerStateMachine.ReusableData.IsWallBack && IsRight)
        {
            Vector3 rotator = new Vector3(PlayerStateMachine.Player.transform.rotation.x, 180f, PlayerStateMachine.Player.transform.rotation.z);
            PlayerStateMachine.Player.transform.rotation = Quaternion.Euler(rotator);
            PlayerStateMachine.ReusableData.IsRight = !IsRight;
        }
        else if(PlayerStateMachine.ReusableData.IsWallBack && !IsRight)
        {
            Vector3 rotator = new Vector3(PlayerStateMachine.Player.transform.rotation.x, 0f, PlayerStateMachine.Player.transform.rotation.z);
            PlayerStateMachine.Player.transform.rotation = Quaternion.Euler(rotator);
            PlayerStateMachine.ReusableData.IsRight = !IsRight;
        }
    }


}
