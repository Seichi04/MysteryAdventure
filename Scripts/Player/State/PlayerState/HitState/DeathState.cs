using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DeathState : HitState
{
    public DeathState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(PlayerSO.PlayerAnimationData.DeathStringHash);
        SetPlayerLayer(PlayerStateMachine.Player.TagLayerSO.PlayerNoTouch);
        
    }

    public override void Update()
    {
        //base.Update();
        PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(0f,-PlayerSO.AirborneStateData.BaseFallSpeed);
    }

    public override void Exit()
    {
        StopAnimation(PlayerSO.PlayerAnimationData.DeathStringHash);
        base.Exit();
    }

    public override void OnAnimationExitEvent()
    {
        Death();
    }

    public void Death(int State=0)
    {
        Debug.Log("Death");
        Exit();
        if(State==0)
        {
            RespawnPlayer();
        }
        else if(State ==1)
        {
            PlayerStateMachine.Player.DestroyPlayer();

        }
        else if(State ==2)
        {
            PlayerStateMachine.Player.gameObject.SetActive(false);
        }
    }

    public void RespawnPlayer()
    {
        Transform closestSpawnPoint = RespawnPointManager.instance.GetClosestRespawnPoint(PlayerStateMachine.Player.transform);
        PlayerStateMachine.Player.transform.position = closestSpawnPoint.position;
        PlayerStateMachine.ReusableData.CurrentHealth = PlayerStateMachine.ReusableData.MaxHealth;
        PlayerStateMachine.ReusableData.CurrentShield = PlayerStateMachine.ReusableData.MaxShield;
        PlayerStateMachine.Player.UpdateMaxHealthUI();
        PlayerStateMachine.Player.UpdateMaxShieldUI();
        PlayerStateMachine.Player.UpdateCurrentHealthUI();
        PlayerStateMachine.Player.UpdateCurrentShieldUI();
        PlayerStateMachine.ChangeState(PlayerStateMachine.IdleState);
    }
}
