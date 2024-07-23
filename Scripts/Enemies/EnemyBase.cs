using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase:MonoBehaviour,IDamagable,IAttackable
{
    public int Health;
    public TagLayerSO TagLayerSO;
    public EnemySO EnemySO;
    public bool isRight = true;
    public Vector2 CurrentTargetPos;
    private bool IsKnockbackAirborne;


    protected Rigidbody2D Rigidbody2D;
    protected Animator Animator;

    protected virtual void Awake() {
        Animator = GetComponent<Animator>();
        
    }

    protected virtual void Start() 
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        StartCoroutine(AntiKnockbackForceAirborne());

    }
    protected virtual void Update() 
    {
        Rotate();
    }
    protected virtual void OnEnable()
    {

    }
    protected virtual void OnDisable()
    {

    }
    protected virtual void OnDestroy()
    {

    }


    #region Attack method
    public virtual int GetAttack()
    {
        return 0;
    }
    public virtual void TakeDamage(int dam)
    {
        Health-=dam;
        if(Health <=0f)
        {
            Death();
        }
    }

    public virtual void Death()
    {

    }

    #endregion


    #region Behavior Method
    protected virtual void MoveBetween(Vector2 pos1,Vector2 pos2, float speed)
    {
        Vector2 EnemyPos = transform.position;
        if( Mathf.Abs(transform.position.x - CurrentTargetPos.x)  <= 0.1f)
        {
            CurrentTargetPos = (CurrentTargetPos.x==pos1.x)? new Vector2(pos2.x,EnemyPos.y) : new Vector2(pos1.x,EnemyPos.y);
        }
        if(CurrentTargetPos.x < EnemyPos.x)
        {
            Rigidbody2D.velocity = new Vector2(speed * -1,Rigidbody2D.velocity.y);
        }
        else
        {
            Rigidbody2D.velocity = new Vector2(speed * 1,Rigidbody2D.velocity.y);
        }
    }
    protected virtual void ChaseTarget(Vector2 TargetPos,float speed)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position,CurrentTargetPos,step);
        //Debug.LogError("Chase");
    }
    
    #endregion

    #region Reusable Methods
    protected virtual void Rotate()
    {
        float checkPos = transform.position.x - CurrentTargetPos.x;
        if( checkPos >0f &&  isRight )
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f,transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isRight = !isRight;
        }
        else if(checkPos <0f && !isRight)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f,transform.rotation.z);
            transform.rotation = Quaternion.Euler(rotator);
            isRight = !isRight;
        }
    }

    protected virtual void KnockBackGround(int Direction)
    {
        if(  (Direction==1 && isRight)   ||   (Direction==-1 && !isRight))
        {
            Rigidbody2D.velocity = new Vector2(0f,EnemySO.KnockbackForce.y);
        }
        else
        {
            Rigidbody2D.velocity = new Vector2(Direction * EnemySO.KnockbackForce.x, EnemySO.KnockbackForce.y);
        }
    }

    protected virtual void KnockBackAirborne(Vector2 Direction)
    {
        Rigidbody2D.velocity = new Vector2(Direction.x * EnemySO.KnockbackForceAirborne.x, Direction.y*EnemySO.KnockbackForceAirborne.y);
        IsKnockbackAirborne = true;
    }

    protected void StartAnimation(string AnimationString)
    {
        Animator.SetBool(AnimationString, true);
    }
    protected void StopAnimation(string AnimationString)
    {
        Animator.SetBool(AnimationString,false);
    }

    #endregion


    #region IEnumarator

    protected virtual IEnumerator AntiKnockbackForceAirborne()
    {
        while(true)
        {
            if(IsKnockbackAirborne)
            {
                yield return new WaitForSeconds(EnemySO.TimeKnockbackAirborne);
                IsKnockbackAirborne = false;
                Rigidbody2D.velocity = Vector2.zero;
            }
            yield return null;
        }
    }
    #endregion

}
