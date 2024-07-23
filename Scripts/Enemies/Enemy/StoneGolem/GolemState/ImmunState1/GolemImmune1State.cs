using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemImmune1State : GolemState
{
    private int DashModifier = 0;
    public GolemImmune1State(GolemStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        AudioManager.Instance.PlayStoneGolemDashAudio(Golem.audioSource);
        GolemReusableData.CurrentAttack = Golem.EnemySO.GolemData.AttackImmune;
        StartAnimation(Golem.ImmuneAnimation);
        GolemReusableData.IsAttackEnd = false;
        DashModifier = 0;
    }

    public override void Update()
    {
        base.Update();

        if(GolemReusableData.IsAttackEnd)
        {
            OnIdle();
        }
        else
        {
            int direction = GolemReusableData.IsRight ? 1 : -1;
            Golem.Rigidbody2D.velocity = new Vector2(Golem.EnemySO.GolemData.SpeedImmune1 * direction * DashModifier, 0f); 
        }
    }
    public override void Exit()
    {
        StopAnimation(Golem.ImmuneAnimation);
        base.Exit();
    }

    public override void OnAnimationTransitionEvent()
    {
        Dash();
    }
    public override void OnTriggerEnter(Collider2D collider)
    {
        //if(Golem.GolemCollider.IsWallFront)
        if(collider.gameObject.layer == LayerMask.NameToLayer("Map"))
        {
            GolemReusableData.IsAttackEnd = true;
            DashModifier = 0;
            CameraShake.instance.ShakeCamera(0.5f);
        }

    }
    
    public void Dash()
    {
        DashModifier = 1;
    }



}
