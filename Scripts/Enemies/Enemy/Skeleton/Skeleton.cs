using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skeleton : EnemyBase
{
    [SerializeField]private Transform pos1;
    [SerializeField]private Transform pos2;
    [SerializeField]private string WalkStateString;
    [SerializeField]private string IdleStateString;

    protected override void Start()
    {
        base.Start();
        AudioManager.Instance.PlaySkeletonWalkAudio(GetComponent<AudioSource>(),true);
        CurrentTargetPos = pos1.position;
        StartAnimation(WalkStateString);
        Health = EnemySO.SkeletonData.Health;
    }
    protected override void Update()
    {
        base.Update();
        if(Health >0f)
        {
            MoveBetween(pos1.position,pos2.position,EnemySO.SkeletonData.Speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(TagLayerSO.BoxDamage))
        {
            KnockBackGround((other.transform.position.x > transform.position.x)? -1: 1);
            int dam = other.gameObject.GetComponentInParent<Player>().GetAttack();
            TakeDamage(dam);
            StopAnimation(WalkStateString);
            StartAnimation(IdleStateString);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(TagLayerSO.MapLayerString))
        {
            StopAnimation(IdleStateString);
            StartAnimation(WalkStateString);
        }
    }

    public override int GetAttack()
    {
        return EnemySO.SkeletonData.Attack;
    }

    public override void Death()
    {
        base.Death();
        //gameObject.SetActive(false);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
