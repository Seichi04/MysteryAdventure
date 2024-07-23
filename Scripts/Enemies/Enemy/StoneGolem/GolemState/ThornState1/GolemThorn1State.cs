using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemThorn1State : GolemState
{
    public GolemThorn1State(GolemStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        GolemReusableData.CurrentAttack = Golem.EnemySO.GolemData.AttackIdle;
        StartAnimation(Golem.GlowAnimation);
        GolemReusableData.IsAttackEnd = false;
        if(Golem.transform.position.x < Golem.PlayerTransform.position.x)
        {
            ChangeRotationWhileVelocityZero(1);
        }
        else
        {
            ChangeRotationWhileVelocityZero(-1);
        }
    }

    public override void Update()
    {

        if(GolemReusableData.IsAttackEnd)
        {
            OnIdle();
        }
        else
        {
            Golem.Rigidbody2D.velocity = new Vector2(0f, 0f); 
        }
    }
    public override void Exit()
    {
        StopAnimation(Golem.GlowAnimation);
        base.Exit();
    }
    public override void OnAnimationEnterEvent()
    {
        CallThorn(75);
    }
    public override void OnAnimationTransitionEvent()
    {
        CallShield(1);
    }

    public override void OnAnimationExitEvent()
    {
        GolemReusableData.IsAttackEnd = true;
    }


    public void CallThorn(int quantity)
    {
        List<GameObject> thorns = new();
        int distance = 1;
        thorns = ObjectPool.instance.GetListPooledObject(Golem.ThornName,quantity);
        Vector2 startPos= Golem.ThornStartPos.position;

        for(int i=0;i<quantity;i++)
        {
            thorns[i].GetComponent<Thorn>().time = Golem.EnemySO.GolemData.TimeThorne1State;
            if(!GolemReusableData.IsRight)
            {
                thorns[i].transform.eulerAngles = new Vector3(thorns[i].transform.eulerAngles.x,0,thorns[i].transform.eulerAngles.z);
                thorns[i].transform.position = new(startPos.x - i * distance,startPos.y);
            }
            else
            {
                thorns[i].transform.eulerAngles = new Vector3(thorns[i].transform.eulerAngles.x,180,thorns[i].transform.eulerAngles.z);
                thorns[i].transform.position = new(startPos.x + i * distance,startPos.y);
            }

            thorns[i].SetActive(true);
        }
    }

    public void CallShield(int shield)
    {
        GolemReusableData.Shield += shield;
    }
}
