using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;

public class LadderGrabState : AirborneState
{
    private float velocity;
    private bool isLadderGrab;
    public LadderGrabState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    #region IState Methods
    public override void Enter()
    {
        base.Enter();
        if(PlayerStateMachine.ReusableData.JumpCount==2)
        {
            PlayerStateMachine.ReusableData.JumpCount=1;
        }
        isLadderGrab = true;
        StartAnimation(PlayerSO.PlayerAnimationData.LadderGrabStringHash);
        SetNewPosition();
        PlayerStateMachine.ReusableData.CurrentLadderSpeedModifier = PlayerSO.AirborneStateData.LadderGrabStateData.LadderSpeedModifier;
        velocity = GetLadderSpeed();
        LadderGrab();
    }

    public override void Update()
    {

        Move();
        LadderGrab();
        //Rotate();
        UpdateColliderState();
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

        OnDash();
        if(PlayerStateMachine.ReusableData.IsLadder == false)
        {
            PlayerStateMachine.ChangeState(PlayerStateMachine.FallState);
        }


        if(isLadderGrab)
        {
            PlayerStateMachine.Player.Animator.speed = 1f;
        }
        else
        {
            PlayerStateMachine.Player.Animator.speed = 0f;
        }
    }
    public override void Exit()
    {
        PlayerStateMachine.Player.Animator.speed = 1f;
        StopAnimation(PlayerSO.PlayerAnimationData.LadderGrabStringHash);
        base.Exit();
    }
    #endregion

    private void LadderGrab()
    {
        if(PlayerStateMachine.ReusableData.MovementInput.y ==0)
        {
            PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(0f,PlayerSO.AirborneStateData.LadderGrabStateData.AntiGravityForce);
        }
        else
        {           
            PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(0f,velocity * GetDirectionY());
        }
        
    }

    private float GetLadderSpeed()
    {
        float speedModifier = PlayerStateMachine.ReusableData.CurrentLadderSpeedModifier;
        float speed = PlayerSO.AirborneStateData.BaseLadderSpeed;
        return speed * speedModifier;
    }

    private void SetNewPosition()
    {
        PlayerStateMachine.Player.transform.position = new Vector2(PlayerStateMachine.Player.PlayerBodyCollider.PosLadder.x,PlayerStateMachine.Player.transform.position.y);
    }


    protected override void OnJump()
    {
        if(PlayerStateMachine.ReusableData.MovementInput.y >= 0f && PlayerStateMachine.ReusableData.JumpCount <2 
            && PlayerStateMachine.ReusableData.ShouldJump && !PlayerStateMachine.ReusableData.NeedNewStartJump)
        {
            PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(GetDirection(),PlayerSO.AirborneStateData.BaseJumpForce * 10);
            PlayerStateMachine.ChangeState(PlayerStateMachine.JumpState);
        }
    }


    #region ChangeState Methods
    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        base.OnMovementCanceled(context);
        if(PlayerStateMachine.ReusableData.MovementInput.y == 0f)
        {
            isLadderGrab= false;
        }
    }

    protected override void OnMovementPerformed(InputAction.CallbackContext context)
    {
        base.OnMovementPerformed(context);
        if(PlayerStateMachine.ReusableData.MovementInput.y==0f)
        {
            isLadderGrab = false;
        }
        else
        {
            isLadderGrab = true;
        }
    }
    #endregion
}
