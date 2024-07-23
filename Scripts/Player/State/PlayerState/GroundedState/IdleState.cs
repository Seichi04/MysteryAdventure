using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : GroundedState
{
    public IdleState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    #region IState Methods
    public override void Enter()
    {
        base.Enter();
        SetPlayerLayer(PlayerStateMachine.Player.TagLayerSO.Player);
        StartAnimation(PlayerSO.PlayerAnimationData.IdleStringHash);
        PlayerStateMachine.ReusableData.CurrentSpeedModifier = PlayerSO.GroundedStateData.IdleStateData.SpeedModifier;
        ResetVelocity();
    }

    public override void Update()
    {
        base.Update();
        OnMove();
        OnCrouch();
        OnDash();
        OnSlide();
        OnFall();
        OnLadderGrab();
        OnAttack();
    }

    public override void Exit()
    {
        StopAnimation(PlayerSO.PlayerAnimationData.IdleStringHash);
        base.Exit();
    }



    #endregion
}
