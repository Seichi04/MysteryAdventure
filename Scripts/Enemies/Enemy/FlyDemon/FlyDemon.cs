using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyDemon : EnemyBase
{
    [SerializeField]private string IdleStateString;
    [SerializeField]private string AttackStateString;
    [SerializeField]private string HurtStateString;
    [SerializeField]private string DeathStateString;
    [SerializeField]private string NameBullet;
    [SerializeField]private float AttackCoolDown;
    [SerializeField]private AttackArea AttackArea;

    private bool IsAttack;

    protected override void Start()
    {
        base.Start();
        StartAnimation(IdleStateString);
        Health = EnemySO.LizardData.Health;
        StartCoroutine(ShootCoroutine());
        IsAttack = false;
    }
    protected override void Update()
    {
        if(Health >0f)
        {
            if(!AttackArea.ShouldAttack || !IsAttack)
            {
                StartAnimation(IdleStateString);
                StopAnimation(AttackStateString);
                StopAnimation(HurtStateString);
            }
        }
    }

    #region Collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(TagLayerSO.BoxDamage))
        {
            StartAnimation(HurtStateString);
            StopAnimation(AttackStateString);
            StopAnimation(IdleStateString);
            int dam = other.gameObject.GetComponentInParent<Player>().GetAttack();
            TakeDamage(dam);
        }
    }
    #endregion

    public override int GetAttack()
    {
        return EnemySO.FlyDemonData.Attack;
    }

    public override void TakeDamage(int dam)
    {
        Health-=dam;
        if(Health <=0f)
        {
            StopAnimation(AttackStateString);
            StopAnimation(IdleStateString);
            StopAnimation(HurtStateString);
            StartAnimation(DeathStateString);
        }
    }

    public override void Death()
    {
        gameObject.SetActive(false);
    }

    private void Shoot()
    {
        GameObject bullet = ObjectPool.instance.GetPooledObject(NameBullet);
        if(bullet != null)
        {
            if(!isRight)
            {
                bullet.transform.eulerAngles = new Vector3(bullet.transform.eulerAngles.x,bullet.transform.eulerAngles.y,180 + 90);
                bullet.transform.position = new Vector2(transform.position.x - 0.7f,transform.position.y-0.05f);
            }
            else
            {
                bullet.transform.eulerAngles = new Vector3(bullet.transform.eulerAngles.x,bullet.transform.eulerAngles.y,90);
                bullet.transform.position = new Vector2(transform.position.x + 0.7f,transform.position.y-0.05f);
            }
            
            bullet.SetActive(true);
        }
        IsAttack = false;
    }
    private IEnumerator ShootCoroutine()
    {
        while(true)
        {
            if(AttackArea.ShouldAttack)
            {
                StopAnimation(IdleStateString);
                StopAnimation(HurtStateString);
                AudioManager.Instance.PlayFlyDemonShootAudio(GetComponent<AudioSource>());
                StartAnimation(AttackStateString);
                IsAttack = true;
                yield return new WaitForSeconds(AttackCoolDown);
            }
            yield return null;
        }
    }

    public void PlayFlyAudio()
    {
        AudioManager.Instance.PlayRandomFlyAudio(GetComponent<AudioSource>());
    }
}
