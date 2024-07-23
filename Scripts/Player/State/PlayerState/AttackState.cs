using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerState
{
    private bool isAttackFinished;
    public AttackState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(PlayerSO.PlayerAnimationData.AttackStringHash);
        isAttackFinished = false;
        PlayerStateMachine.Player.Input.OnDisable();
        Attack();
    }

    public override void Update()
    {
        //Rotate();
        UpdateColliderState();

        if(isAttackFinished)
        {
            PlayerStateMachine.Player.Input.OnEnable();
            OnIdle();
            OnMove();
            OnFall();
            OnJump();
            OnDash();
            OnSlide(); 
            OnAttack();     
        }
        OnHit();

    }

    public override void Exit()
    {
        StopAnimation(PlayerSO.PlayerAnimationData.AttackStringHash);
        PlayerStateMachine.ReusableData.TimeAttack = Time.time;
        base.Exit();
    }

    protected virtual void Attack()
    {
        PlayerStateMachine.Player.Rigibody2D.velocity = Vector2.zero;
    }

    public override void OnAnimationTransitionEvent()
    {
        isAttackFinished = true;
    }

    public override void OnAnimationExitEvent()
    {
        isAttackFinished = true;
    }

    protected override void OnFall()
    {
        if( !PlayerStateMachine.ReusableData.IsGrounded && GetPlayerVelocity().y <= 0f )
        {
            PlayerStateMachine.ChangeState(PlayerStateMachine.FallState);
        }
    }

}
