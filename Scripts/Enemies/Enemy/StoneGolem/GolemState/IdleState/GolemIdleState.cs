using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GolemIdleState : GolemState
{
    private Vector2 TargetPos;
    public GolemIdleState(GolemStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(Golem.IdleAnimation);
        GolemReusableData.CurrentAttack = Golem.EnemySO.GolemData.AttackIdle;
        if(GolemReusableData.IsRight)
            TargetPos = new Vector2(Golem.Pos2Idle.position.x,Golem.transform.position.y);
        else
            TargetPos = new Vector2(Golem.Pos1Idle.position.x,Golem.transform.position.y);
        
        Golem.gameObject.tag = "EnemyNoTouch";
        // Golem.gameObject.layer = LayerMask.NameToLayer("EnemyNoTouch");
    }

    public override void Update()
    {
        base.Update();
        MoveBetween(Golem.Pos1Idle.position,Golem.Pos2Idle.position,Golem.EnemySO.GolemData.SpeedIdle);
        if(GolemReusableData.MoveCount < GolemReusableData.Moveset.Count)
        {
            if(GolemReusableData.Moveset[GolemReusableData.MoveCount] == GolemStateEnum.Immune1)
            {
                OnImmune1();
            }
            else if(GolemReusableData.Moveset[GolemReusableData.MoveCount] == GolemStateEnum.Shoot1)
            {
                OnShoot1();
            }
            else if(GolemReusableData.Moveset[GolemReusableData.MoveCount] == GolemStateEnum.Thorn1)
            {
                OnThorn1();
            }
            else if(GolemReusableData.Moveset[GolemReusableData.MoveCount] == GolemStateEnum.Immune2)
            {
                OnImmune2();
            }
            else if(GolemReusableData.Moveset[GolemReusableData.MoveCount] == GolemStateEnum.Shoot2)
            {
                OnShoot2();
            }
            else if(GolemReusableData.Moveset[GolemReusableData.MoveCount] == GolemStateEnum.Thorn2)
            {
                OnThorn2();
            }
            else if(GolemReusableData.Moveset[GolemReusableData.MoveCount] == GolemStateEnum.Laser)
            {
                OnLaser();
            }
        }
        else
        {
            GolemReusableData.MoveCount =0;
        }


        
    }

    public override void Exit()
    {
        Golem.gameObject.tag = "EnemyTouch";
        // Golem.gameObject.layer = LayerMask.NameToLayer("EnemyTouch");
        StopAnimation(Golem.IdleAnimation);
        base.Exit();
    }

    private void MoveBetween(Vector2 pos1,Vector2 pos2, float speed)
    {
        Vector2 golemPos = Golem.transform.position;
        //Debug.Log(golemPos + " " + TargetPos);
        if( Mathf.Abs(Golem.transform.position.x - TargetPos.x)  <= 0.1f)
        {
            TargetPos = (TargetPos.x==pos1.x)? new Vector2(pos2.x,golemPos.y) : new Vector2(pos1.x,golemPos.y);
        }
        if(TargetPos.x < golemPos.x)
        {
            GolemStateMachine.Golem.Rigidbody2D.velocity = new Vector2(Golem.EnemySO.GolemData.SpeedIdle * -1,GetGolemVelovity().y);
        }
        else
        {
            GolemStateMachine.Golem.Rigidbody2D.velocity = new Vector2(Golem.EnemySO.GolemData.SpeedIdle * 1,GetGolemVelovity().y);

        }
    }

    #region ChangeState Methods
    public virtual void OnImmune1()
    {
        if(Time.time - GolemReusableData.TimeStartCurrentState >= Golem.EnemySO.GolemData.TimeAttackCoolDown)
        {
            GolemReusableData.MoveCount++;
            GolemStateMachine.ChangeState(GolemStateMachine.GolemImmune1State);
        }
    }
    public virtual void OnShoot1()
    {
        if(Time.time - GolemReusableData.TimeStartCurrentState >= Golem.EnemySO.GolemData.TimeAttackCoolDown && Mathf.Abs(Golem.transform.position.x - TargetPos.x)  <= 2f)
        {
            GolemReusableData.MoveCount++;
            GolemStateMachine.ChangeState(GolemStateMachine.GolemShoot1State);
        }
    }
    public virtual void OnThorn1()
    {
        if(Time.time - GolemReusableData.TimeStartCurrentState >= Golem.EnemySO.GolemData.TimeAttackCoolDown && Mathf.Abs(Golem.transform.position.x - TargetPos.x)  <= 5f)
        {
            GolemReusableData.MoveCount++;
            GolemStateMachine.ChangeState(GolemStateMachine.GolemThorn1State);
        }
    }

    public virtual void OnImmune2()
    {
        if(Time.time - GolemReusableData.TimeStartCurrentState >= Golem.EnemySO.GolemData.TimeAttackCoolDown && Mathf.Abs(Golem.transform.position.x - TargetPos.x)  <= 1f)
        {
            GolemReusableData.MoveCount++;
            GolemStateMachine.ChangeState(GolemStateMachine.GolemImmune2State);
        }
    }
    public virtual void OnShoot2()
    {
        if(Time.time - GolemReusableData.TimeStartCurrentState >= Golem.EnemySO.GolemData.TimeAttackCoolDown && Mathf.Abs(Golem.transform.position.x - TargetPos.x)  <= 2f)
        {
            GolemReusableData.MoveCount++;
            GolemStateMachine.ChangeState(GolemStateMachine.GolemShoot2State);
        }
    }
    public virtual void OnThorn2()
    {
        if(Time.time - GolemReusableData.TimeStartCurrentState >= Golem.EnemySO.GolemData.TimeAttackCoolDown && Mathf.Abs(Golem.transform.position.x - TargetPos.x)  <= 1f)
        {
            GolemReusableData.MoveCount++;
            GolemStateMachine.ChangeState(GolemStateMachine.GolemThorn2State);
        }
    }

    public virtual void OnLaser()
    {
        if(Time.time - GolemReusableData.TimeStartCurrentState >= Golem.EnemySO.GolemData.TimeAttackCoolDown && Mathf.Abs(Golem.transform.position.x - TargetPos.x)  <= 3f)
        {
            GolemReusableData.MoveCount++;
            GolemStateMachine.ChangeState(GolemStateMachine.GolemLaserState);
        }
    }



    #endregion
}
