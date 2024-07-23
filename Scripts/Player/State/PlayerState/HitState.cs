using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitState : PlayerState
{
    private int damageReceive = 0; 
    public HitState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        AudioManager.Instance.PlayHurtAudio(PlayerStateMachine.Player.playerAudioSource);
        damageReceive = PlayerStateMachine.Player.PlayerBodyCollider.DamReceive;
        PlayerStateMachine.Player.Input.OnEnable();
        PlayerStateMachine.Player.TakeDamage(damageReceive);
        StartAnimation(PlayerSO.PlayerAnimationData.HitStringHash);
        ResetInputVar();
    }

    public override void Update()
    {
        base.Update();
        PlayerStateMachine.ReusableData.IsAttacked = false;
    }

    public override void Exit()
    {
        AudioManager.Instance.StopAudio(PlayerStateMachine.Player.playerAudioSource);
        StopAnimation(PlayerSO.PlayerAnimationData.HitStringHash);
        base.Exit();
    }
}
