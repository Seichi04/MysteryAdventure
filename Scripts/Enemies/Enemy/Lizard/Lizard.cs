using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : EnemyBase
{
    [SerializeField]private Transform pos1;
    [SerializeField]private Transform pos2;
    [SerializeField]private string WalkStateString;
    [SerializeField]private string ShootStateString;
    [SerializeField]private GameObject DeathEffect;
    [SerializeField]private string NameBullet;
    [SerializeField]private float AttackCoolDown;
    [SerializeField]private AttackArea AttackArea;


    protected override void Start()
    {
        base.Start();
        CurrentTargetPos = pos1.position;
        StartAnimation(WalkStateString);
        Health = EnemySO.LizardData.Health;
        StartCoroutine(ShootCoroutine());
    }
    protected override void Update()
    {
        base.Update();
        if(Health >0f)
        {
            if(!AttackArea.ShouldAttack)
            {
                StartAnimation(WalkStateString);
                StopAnimation(ShootStateString);
                MoveBetween(pos1.position,pos2.position,EnemySO.LizardData.Speed);
            }
            else
            {
                if(  (isRight && AttackArea.TargetPos.x >= transform.position.x)   ||  (!isRight && AttackArea.TargetPos.x <= transform.position.x))
                {
                    Rigidbody2D.velocity = Vector2.zero;
                }
                else
                {
                    StartAnimation(WalkStateString);
                    StopAnimation(ShootStateString);
                    MoveBetween(pos1.position,pos2.position,EnemySO.LizardData.Speed);
                }
            }
        }
    }

    #region Collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(TagLayerSO.BoxDamage))
        {
            KnockBackGround((other.transform.position.x > transform.position.x)? -1: 1);
            int dam = other.gameObject.GetComponentInParent<Player>().GetAttack();
            TakeDamage(dam);
        }
    }
    #endregion

    


    public override int GetAttack()
    {
        return EnemySO.LizardData.Attack;
    }

    public override void Death()
    {
        base.Death();
        gameObject.SetActive(false);
        gameObject.transform.parent.gameObject.SetActive(false);
    }

    private void Shoot()
    {
        AudioManager.Instance.PlayLizardShootAudio(GetComponent<AudioSource>());
        StopAnimation(WalkStateString);
        StartAnimation(ShootStateString);
        GameObject bullet = ObjectPool.instance.GetPooledObject(NameBullet);
        if(bullet != null)
        {
            if(!isRight)
            {
                bullet.transform.eulerAngles = new Vector3(bullet.transform.eulerAngles.x,bullet.transform.eulerAngles.y,180 + 90);
            }
            else
            {
                bullet.transform.eulerAngles = new Vector3(bullet.transform.eulerAngles.x,bullet.transform.eulerAngles.y,90);
            }
            bullet.transform.position = transform.position;
            bullet.SetActive(true);
        }
    }
    private IEnumerator ShootCoroutine()
    {
        while(true)
        {
            if(AttackArea.ShouldAttack)
            {
                if(  (isRight && AttackArea.TargetPos.x >= transform.position.x)   ||  (!isRight && AttackArea.TargetPos.x <= transform.position.x))
                {
                    Shoot();
                    yield return new WaitForSeconds(AttackCoolDown);
                }
            }
            yield return null;
        }
    }
}
