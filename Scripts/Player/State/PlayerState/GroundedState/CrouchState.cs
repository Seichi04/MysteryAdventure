using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CrouchState : GroundedState
{
    private bool isCrouch;
    public CrouchState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        StartAnimation(PlayerSO.PlayerAnimationData.CrouchStringHash);
        PlayerStateMachine.ReusableData.CurrentSpeedModifier = PlayerSO.GroundedStateData.CrouchStateData.SpeedModifier;
        ResetVelocity();
        isCrouch = true;
    }

    public override void Update()
    {
        base.Update();
        if(PlayerStateMachine.ReusableData.IsGrounded == false)
        {
            PlayerStateMachine.ChangeState(PlayerStateMachine.FallState);
        }

        if(isCrouch == false)
        {
            PlayerStateMachine.Player.Animator.speed = 1f;
            OnIdle();
            OnMove();
        }

        
    }

    public override void Exit()
    {
        PlayerStateMachine.Player.Animator.speed = 1f;
        StopAnimation(PlayerSO.PlayerAnimationData.CrouchStringHash);
        base.Exit();
    }


    public override void OnAnimationTransitionEvent()
    {
        if(isCrouch)
        {
            PlayerStateMachine.Player.Animator.speed = 0f;
        }
    }


    protected override void OnMovementCanceled(InputAction.CallbackContext context)
    {
        base.OnMovementCanceled(context);
        if(PlayerStateMachine.ReusableData.MovementInput.y >= 0f)
        {
            isCrouch = false;
        }
    }

    protected override void OnMovementPerformed(InputAction.CallbackContext context)
    {
        base.OnMovementPerformed(context);
        if(PlayerStateMachine.ReusableData.MovementInput.y >= 0f && PlayerStateMachine.ReusableData.MovementInput.x != 0f)
        {
            isCrouch = false;
        }
    }
}
