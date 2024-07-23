using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalAttackState : AttackState
{
    public NomalAttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        AudioManager.Instance.PlayNomalAttackAudio(PlayerStateMachine.Player.playerAudioSource);
        StartAnimation(PlayerSO.PlayerAnimationData.NomalAttackStringHash);
        PlayerStateMachine.ReusableData.ShouldAttack = false;
        PlayerStateMachine.ReusableData.CurrentAttackModifier = PlayerSO.AttackStateData.NomalAttackStateData.AttackModifier;
    }

    protected override void Rotate()
    {
        
    }

    public override void Exit()
    {
        StopAnimation(PlayerSO.PlayerAnimationData.NomalAttackStringHash);
        base.Exit();
    }
}
