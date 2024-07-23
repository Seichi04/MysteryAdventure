using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Orc : EnemyBase
{
    [SerializeField]private Transform pos1;
    [SerializeField]private Transform pos2;
    [SerializeField]private float DistanceChase;
    [SerializeField]private AttackArea AttackArea;
    [SerializeField]private ChaseArea ChaseArea;

    [SerializeField]private string WalkStateString;
    [SerializeField]private string AttackStateString;
    [SerializeField]private string HitStateString;
    [SerializeField]private string DeathStateString;

    [SerializeField]private GameObject DeathEffect;
    private bool isAttacked;

    private bool isAttack;
    private AudioSource audioSource;

    protected override void Start()
    {
        base.Start();
        CurrentTargetPos = pos1.position;
        StartAnimation(WalkStateString);
        Health = EnemySO.OrcData.Health;
        isAttack = true;
        isAttacked = false;
        audioSource = GetComponent<AudioSource>();
        AudioManager.Instance.PlayOrcVoiceNomalAudio(audioSource,true);
    }
    protected override void Update()
    {
        base.Update();
        if(Health >0f)
        {
            if(!AttackArea.ShouldAttack || !isAttack)
            {
                StopAnimation(AttackStateString);
                StartAnimation(WalkStateString);
                Rigidbody2D.velocity = Vector2.zero;
                if(!ChaseArea.ShouldChase)
                {
                    if(CurrentTargetPos.x != pos1.position.x && CurrentTargetPos.x != pos2.position.x)
                    {
                        CurrentTargetPos = new Vector2(pos1.position.x,transform.position.y);
                    }
                    MoveBetween(pos1.position,pos2.position,EnemySO.OrcData.Speed);
                }
                else
                {
                    if(!AttackArea.ShouldAttack)
                    {
                        CurrentTargetPos = new Vector2(ChaseArea.TargetPos.x,transform.position.y);
                        if(CurrentTargetPos.x > transform.position.x)
                        {
                            Rigidbody2D.velocity = new Vector2(EnemySO.OrcData.ChaseSpeed,Rigidbody2D.velocity.y);
                        }
                        else
                        {
                            Rigidbody2D.velocity = new Vector2(-EnemySO.OrcData.ChaseSpeed,Rigidbody2D.velocity.y);

                        }
                    }
                }
            }
            else
            {
                StopAnimation(AttackStateString);
                StartAnimation(WalkStateString);
                if(isAttack && AttackArea.ShouldAttack)
                {
                    Attack();
                }
                
            }

            if(AttackArea.ShouldAttack)
            {
                Rigidbody2D.velocity = Vector2.zero;
                CurrentTargetPos = transform.position;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(TagLayerSO.BoxDamage))
        {
            if(!isAttacked)
            {
                KnockBackGround((other.transform.position.x > transform.position.x)? -1: 1);
                int dam = other.gameObject.GetComponentInParent<Player>().GetAttack();
                TakeDamage(dam);

                
                StopAnimation(WalkStateString);
                StopAnimation(AttackStateString);
                StartAnimation(HitStateString);
                isAttacked = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag(TagLayerSO.BoxDamage))
        {
            StopAnimation(HitStateString);
            StartAnimation(WalkStateString);
            isAttacked = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(TagLayerSO.MapLayerString))
        {
            StopAnimation(HitStateString);
            StartAnimation(WalkStateString);
        }
    }

    public void ResetVelocity()
    {
        Rigidbody2D.velocity = Vector2.zero;
    }

    private void Attack()
    {
        AudioManager.Instance.PlayOrcAttackAudio(audioSource);
        StopAnimation(WalkStateString);
        StopAnimation(HitStateString);
        StartAnimation(AttackStateString);
        Rigidbody2D.velocity = Vector2.zero;
        isAttack = false;
    }

    public void AttackTrue()
    {
        isAttack = true;
    }




    public override int GetAttack()
    {
        return EnemySO.SkeletonData.Attack;
    }

    public override void Death()
    {
        StopAnimation(HitStateString);
        StopAnimation(WalkStateString);
        StopAnimation(AttackStateString);
        StartAnimation(DeathStateString);
        gameObject.layer = LayerMask.NameToLayer(TagLayerSO.EnemyNoTouch);
    }

    public void Disappear()
    {
        transform.parent.gameObject.SetActive(false);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
