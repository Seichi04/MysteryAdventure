using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GolemImmune2State : GolemState
{
    private int countAttack;
    private bool IsAttack;
    public GolemImmune2State(GolemStateMachine stateMachine) : base(stateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        GolemReusableData.IsAttackEnd = false;
        GolemReusableData.CurrentAttack = Golem.EnemySO.GolemData.AttackIdle;
        countAttack =0;
        IsAttack = false;
        Golem.Animator.speed = 1f;
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
            if(Mathf.Abs(Golem.PosImmune2.position.x - Golem.transform.position.x) > 0.5f)
            {
                int direction =Golem.PosImmune2.position.x >= Golem.transform.position.x ? 1 : -1;
                Golem.Rigidbody2D.velocity = new Vector2(Golem.EnemySO.GolemData.SpeedImmune2 * direction, 0f); 
            }
            else
            {
                Golem.Rigidbody2D.velocity = Vector2.zero; 
                StartAnimation(Golem.Immune2Animation);

                if(IsAttack)
                {
                    Attack();
                }
            }
        }

        if(GolemReusableData.IsLaserEnd)
        {
            Golem.Animator.speed = 1f;
        }


    }
    public override void Exit()
    {
        StopAnimation(Golem.Immune2Animation);
        base.Exit();
    }

    public override void OnAnimationTransitionEvent()
    {
        IsAttack = true;
        Golem.Animator.speed = 0f;
    }
    public override void OnAnimationExitEvent()
    {
        GolemReusableData.IsAttackEnd = true;
    }


    //type 0: all, type 1: odd, type 2: even
    public void CallLaser(int quantity,float eulerAngles,int type)
    {
        if(type==3)
            return;
        float offset=4;
        List<GameObject> lasers = new();
        lasers = ObjectPool.instance.GetListPooledObject(Golem.LaserName, quantity);

        if(type==2)
        {
            for(int i=0;i<quantity;i++)
            {
                int temp = i/2;
                if(i % 2 == 0)
                    lasers[i].transform.position = new Vector2(Golem.PosImmune2.position.x - (temp+1) * offset, Golem.PosImmune2.position.y);
                else
                    lasers[i].transform.position = new Vector2(Golem.PosImmune2.position.x + (temp+1) * offset, Golem.PosImmune2.position.y);

                lasers[i].transform.eulerAngles = new Vector3(lasers[i].transform.eulerAngles.x,lasers[i].transform.eulerAngles.y,eulerAngles);
                lasers[i].SetActive(true);
            }
        }
        else if(type==1)
        {
            for(int i=0;i<quantity;i++)
            {
                int temp = i/2;
                if(temp%2==0)
                {
                    if(i % 2 == 0)
                        lasers[i].transform.position = new Vector2(Golem.PosImmune2.position.x - (temp+1) * offset, Golem.PosImmune2.position.y);
                    else
                        lasers[i].transform.position = new Vector2(Golem.PosImmune2.position.x + (temp+1) * offset, Golem.PosImmune2.position.y);

                    lasers[i].transform.eulerAngles = new Vector3(lasers[i].transform.eulerAngles.x,lasers[i].transform.eulerAngles.y,eulerAngles);
                    lasers[i].SetActive(true);
                }
            }
        }
        else if(type==0)
        {
            for(int i=0;i<quantity;i++)
            {
                int temp = i/2;
                if(temp%2==1)
                {
                    if(i % 2 == 0)
                        lasers[i].transform.position = new Vector2(Golem.PosImmune2.position.x - (temp+1) * offset, Golem.PosImmune2.position.y);
                    else
                        lasers[i].transform.position = new Vector2(Golem.PosImmune2.position.x + (temp+1) * offset, Golem.PosImmune2.position.y);

                    lasers[i].transform.eulerAngles = new Vector3(lasers[i].transform.eulerAngles.x,lasers[i].transform.eulerAngles.y,eulerAngles);
                    lasers[i].SetActive(true);
                }
            }
        }

        
    }

    public void Attack()
    {
        if(countAttack ==0 && GolemReusableData.IsLaserEnd == true)
        {
            CallLaser(20,-90,0);
            countAttack=1;
        }
        else if(countAttack == 1 && GolemReusableData.IsLaserEnd == true)
        {
            CallLaser(20,-90,1);
            countAttack=2;
        }
        else if(countAttack == 2 && GolemReusableData.IsLaserEnd==true)
        {
            CallLaser(20,-90,2);
            countAttack=3;
        }
    }
}
