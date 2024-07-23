using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemLaserState : GolemState
{
    public GolemLaserState(GolemStateMachine stateMachine) : base(stateMachine)
    {
    }

    private int countAttack;
    private bool IsAttack;

    public override void Enter()
    {
        base.Enter();
        GolemReusableData.CurrentAttack = Golem.EnemySO.GolemData.AttackIdle;
        GolemReusableData.IsAttackEnd = false;
        countAttack =0;
        Golem.Animator.speed = 1f;
        StartAnimation(Golem.LaserAnimation);

        if(Golem.PosLaser.position.x - Golem.transform.position.x > 0)
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
            if(Mathf.Abs(Golem.transform.position.y - Golem.Pos1Idle.position.y)  > 0.1f)
                Golem.Rigidbody2D.velocity = new Vector2(GetGolemVelovity().x,Golem.EnemySO.GolemData.SpeedIdle * -1);
            else
            {
                Golem.Rigidbody2D.velocity = Vector2.zero;
                OnIdle();
            }
        }
        else
        {
            if(Golem.PosLaser.position.x != Golem.transform.position.x  || Golem.PosLaser.position.y != Golem.transform.position.y)
            {
                float step = Golem.EnemySO.GolemData.SpeedLaserState * Time.deltaTime;
                Golem.transform.position = Vector2.MoveTowards(Golem.transform.position, Golem.PosLaser.position, step);
            }
            else
            {
                Golem.Rigidbody2D.velocity = Vector2.zero; 
                StartAnimation(Golem.LaserAnimation);

                if(IsAttack)
                {
                    Attack();
                }
            }
        }

        if(GolemReusableData.IsLaserEnd && countAttack==4)
        {
            Golem.Animator.speed = 1f;
        }



    }
    public override void Exit()
    {
        Debug.Log("Exit Laser");
        StopAnimation(Golem.LaserAnimation);
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

    public void CallLaser(int type)
    {
        
        if(type==4)
            return;
        float offset = 5f;
        if(type==0)
        {
            GameObject laser1 = ObjectPool.instance.GetPooledObject(Golem.LaserName);
            laser1.transform.position = new Vector2(Golem.transform.position.x,Golem.transform.position.y + offset);
            laser1.GetComponent<Laser>().SetUpRotateLaser(330,210);
            laser1.SetActive(true);
        }
        else if(type==1)
        {
            GameObject laser1 = ObjectPool.instance.GetPooledObject(Golem.LaserName);
            laser1.transform.position = new Vector2(Golem.transform.position.x,Golem.transform.position.y + offset);
            laser1.GetComponent<Laser>().SetUpRotateLaser(210,330);
            laser1.SetActive(true);
        }
        else if(type==2)
        {
            GameObject laser1 = ObjectPool.instance.GetPooledObject(Golem.LaserName);
            laser1.transform.position = new Vector2(Golem.transform.position.x,Golem.transform.position.y + offset);
            laser1.GetComponent<Laser>().SetUpRotateLaser(265,210);
            laser1.SetActive(true);

            GameObject laser2 = ObjectPool.instance.GetPooledObject(Golem.LaserName);
            laser2.transform.position = new Vector2(Golem.transform.position.x,Golem.transform.position.y + offset);
            laser2.GetComponent<Laser>().SetUpRotateLaser(275,330);
            laser2.SetActive(true);
        }
        else if(type==3)
        {
            GameObject laser1 = ObjectPool.instance.GetPooledObject(Golem.LaserName);
            laser1.transform.position = new Vector2(Golem.transform.position.x,Golem.transform.position.y + offset);
            laser1.GetComponent<Laser>().SetUpRotateLaser(210,265);
            laser1.SetActive(true);

            GameObject laser2 = ObjectPool.instance.GetPooledObject(Golem.LaserName);
            laser2.transform.position = new Vector2(Golem.transform.position.x,Golem.transform.position.y + offset);
            laser2.GetComponent<Laser>().SetUpRotateLaser(330,275);
            laser2.SetActive(true);
        }

        
    }

    public void Attack()
    {
        if(countAttack ==0 && GolemReusableData.IsLaserEnd == true)
        {
            CallLaser(0);
            countAttack=1;
        }
        else if(countAttack == 1 && GolemReusableData.IsLaserEnd == true)
        {
            CallLaser(1);
            countAttack=2;
        }
        else if(countAttack == 2 && GolemReusableData.IsLaserEnd==true)
        {
            CallLaser(2);
            countAttack=3;
        }
        else if(countAttack == 3 && GolemReusableData.IsLaserEnd==true)
        {
            CallLaser(3);
            countAttack = 4;
        }

    }
}
