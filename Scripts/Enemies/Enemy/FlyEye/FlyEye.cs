using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEye : EnemyBase
{
    [SerializeField] private AttackArea AttackArea;
    [SerializeField]private Transform pos1;
    [SerializeField]private Transform pos2;


    protected override void Start()
    {
        base.Start();
        Health = EnemySO.FlyEyeData.Health;
        CurrentTargetPos = pos1.position;
    }

    protected override void Update()
    {
        base.Update();
        if(AttackArea.ShouldAttack)
        {
            CurrentTargetPos = GameObject.FindWithTag("Player").transform.position;
            ChaseTarget(CurrentTargetPos,EnemySO.FlyEyeData.Speed);
        }
        else
        {
            if(CurrentTargetPos.x != pos1.position.x && CurrentTargetPos.x != pos2.position.x)
            {
                CurrentTargetPos = pos1.position;
            }
            MoveBetween(pos1.position,pos2.position,EnemySO.FlyEyeData.Speed);
        }
    }

    protected override void MoveBetween(Vector2 pos1, Vector2 pos2, float speed)
    {
        Vector2 EnemyPos = transform.position;
        if( Vector2.Distance(EnemyPos,CurrentTargetPos)  <= 0.1f)
        {
            CurrentTargetPos = (CurrentTargetPos.x==pos1.x)? new Vector2(pos2.x,EnemyPos.y) : new Vector2(pos1.x,EnemyPos.y);
        }
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(EnemyPos, CurrentTargetPos, step);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(TagLayerSO.BoxDamage))
        {
            KnockBackAirborne(new Vector2(transform.position.x-other.transform.position.x,transform.position.y-other.transform.position.y ));
            int dam = other.gameObject.GetComponentInParent<Player>().GetAttack();
            TakeDamage(dam);
        }
    }

    public override int GetAttack()
    {
        return EnemySO.FlyEyeData.Attack;
    }


    public override void Death()
    {
        base.Death();
        gameObject.SetActive(false);
        gameObject.transform.parent.gameObject.SetActive(false);
    }

    public void PlayFlyAudio()
    {
        AudioManager.Instance.PlayRandomFlyAudio(GetComponent<AudioSource>());
    }
}
