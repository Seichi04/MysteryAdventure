using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class GolemState : IState
{
    protected GolemStateMachine GolemStateMachine;
    protected Golem Golem;


    public GolemState(GolemStateMachine stateMachine)
    {
        this.GolemStateMachine = stateMachine;
        Golem = stateMachine.Golem;
    }

    public virtual void Enter()
    {
        //Debug.Log("State: " + GetType().Name);
        GolemReusableData.TimeStartCurrentState = Time.time;
    }

    public virtual void Exit()
    {
        GolemReusableData.TimeEndStateBefore = Time.time;
    }

    public virtual void HandleInput()
    {
    }

    public virtual void OnAnimationEnterEvent()
    {
    }

    public virtual void OnAnimationExitEvent()
    {
    }

    public virtual void OnAnimationTransitionEvent()
    {
    }

    public virtual void OnTriggerEnter(Collider2D collider)
    {
    }

    public virtual void OnTriggerExit(Collider2D collider)
    {

    }

    public virtual void PhysicsUpdate()
    {
    }

    public virtual void Update()
    {
        OnDeath();
        Rotate();
    }

    #region Main methods
    protected virtual void Rotate()
    {
        Vector2 velocity = GetGolemVelovity();
        if(GolemReusableData.IsRight && velocity.x<0 )
        {
            Vector3 rotator = new Vector3(Golem.transform.rotation.x, 180f, Golem.transform.rotation.z);
            Golem.transform.rotation = Quaternion.Euler(rotator);
            GolemReusableData.IsRight = !GolemReusableData.IsRight;
        }
        else if(!GolemReusableData.IsRight && velocity.x>0)
        {
            Vector3 rotator = new Vector3(Golem.transform.transform.rotation.x, 0f, Golem.transform.transform.rotation.z);
            Golem.transform.transform.rotation = Quaternion.Euler(rotator);
            GolemReusableData.IsRight = !GolemReusableData.IsRight;
        }
    }

    #endregion

    #region Reusable methods
    public Vector2 GetGolemVelovity()
    {
        return GolemStateMachine.Golem.Rigidbody2D.velocity;
    }

    public void StartAnimation(string AnimationString)
    {
        GolemStateMachine.Golem.Animator.SetBool(AnimationString,true);
    }

    public void StopAnimation(string AnimationString)
    {
        GolemStateMachine.Golem.Animator.SetBool(AnimationString,false);
    }


    //only use while velocity=0
    public virtual void ChangeRotationWhileVelocityZero(int direction)
    {
            if(GolemReusableData.IsRight && direction == -1)
            {
                Vector3 rotator = new Vector3(Golem.transform.rotation.x, 180f, Golem.transform.rotation.z);
                Golem.transform.rotation = Quaternion.Euler(rotator);
                GolemReusableData.IsRight = !GolemReusableData.IsRight;
            }
            else if(!GolemReusableData.IsRight && direction == 1)
            {
                Vector3 rotator = new Vector3(Golem.transform.transform.rotation.x, 0f, Golem.transform.transform.rotation.z);
                Golem.transform.transform.rotation = Quaternion.Euler(rotator);
                GolemReusableData.IsRight = !GolemReusableData.IsRight;
            }
        
    }

    #endregion

    #region ChangeState Methods
    public virtual void OnIdle()
    {
        if(GolemReusableData.IsAttackEnd)
        {
            GolemStateMachine.ChangeState(GolemStateMachine.GolemIdleState);
        }
    }
    public virtual void OnDeath()
    {
        if(GolemReusableData.Health<=0)
        {
            GolemStateMachine.ChangeState(GolemStateMachine.GolemDeathState);
            Golem.NPCEnd.SetActive(true);
        }
    }


    #endregion
}
