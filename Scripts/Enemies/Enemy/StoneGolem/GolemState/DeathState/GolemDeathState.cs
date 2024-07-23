using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemDeathState : GolemState
{
    public GolemDeathState(GolemStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Golem.Rigidbody2D.velocity = Vector2.zero;
        StartAnimation(Golem.DeathAnimation);

        Golem.gameObject.tag = "EnemyNoTouch";
        Golem.gameObject.layer = LayerMask.NameToLayer("EnemyNoTouch");
    }

    public override void Update()
    {
        Golem.Rigidbody2D.velocity = Vector2.zero;
    }
}
