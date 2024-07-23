using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAttackState : AttackState
{
    public DashAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        AudioManager.Instance.PlayDashAttackAudio(PlayerStateMachine.Player.playerAudioSource);
        StartAnimation(PlayerSO.PlayerAnimationData.DashAttackStringHash);
        PlayerStateMachine.ReusableData.ShouldAttack = false;
        PlayerStateMachine.ReusableData.CurrentAttackModifier = PlayerSO.AttackStateData.DashAttackStateData.AttackModifier;
    }

    protected override void Rotate()
    {
    }

    public override void Exit()
    {
        StopAnimation(PlayerSO.PlayerAnimationData.DashAttackStringHash);
        base.Exit();
    }
}
