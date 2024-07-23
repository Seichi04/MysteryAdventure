using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class FireSkull : EnemyBase
{
    [SerializeField]private GameObject Target;
    [SerializeField]private string IdleStateString;
    [SerializeField]private string BustStateString;
    [SerializeField]private GameObject BustEffect;

    private bool IsPlay;

    protected override void Start()
    {
        base.Start();
        Health = EnemySO.FireSkullData.Health; 
        IsPlay = false;
    }

    protected override void OnEnable()
    {
        AudioManager.Instance.PlayFireSkullVoiceAudio(GetComponent<AudioSource>(),true);
        StartAnimation(IdleStateString);
        BustEffect.SetActive(false);
        FireSkullManager.ShouldSpawn = false;

    }
    protected override void Update()
    {
        Rigidbody2D.velocity = new Vector2(Target.GetComponent<Rigidbody2D>().velocity.x,Rigidbody2D.velocity.y);
        if(Time.time - FireSkullManager.TimeEnable > EnemySO.FireSkullData.TimeWaitAttack)
        {
            StartBust();
            if(Time.time - FireSkullManager.TimeEnable > EnemySO.FireSkullData.TimeWaitAttack + EnemySO.FireSkullData.TimeAttack)
            {
                Bust();
                if(Time.time - FireSkullManager.TimeEnable > EnemySO.FireSkullData.TimeWaitAttack + EnemySO.FireSkullData.TimeAttack + EnemySO.FireSkullData.TimeDisable)
                {
                    Death();
                }
            }
            else
            {
                LockTarget();
            }
        }
        else
        {
            LockTarget();
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        FireSkullManager.TimeDisable = Time.time;
        FireSkullManager.ShouldSpawn = true;
        StartAnimation(IdleStateString);
        StopAnimation(BustStateString);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            BustEffect.transform.position = other.transform.position;
            BustEffect.SetActive(true);
        }
    }
    private void StartBust()
    {
        StartAnimation(BustStateString);
        StopAnimation(IdleStateString);
    }

    public void Bust()
    {
        if(!IsPlay)
        {
            AudioManager.Instance.PlayFireSkullDashAudio(GetComponent<AudioSource>());
            IsPlay = true;
        }
        Rigidbody2D.velocity = new Vector2(EnemySO.FireSkullData.Speed,0f);
    }
    private void LockTarget()
    {
        Vector2 postion = new Vector2(transform.position.x,Target.transform.position.y);
        transform.position = Vector2.Lerp(transform.position, postion, Time.deltaTime * EnemySO.FireSkullData.SpeedLockTarget);
    }
    public override int GetAttack()
    {
        return EnemySO.FireSkullData.Attack;
    }

    public override void Death()
    {
        base.Death();
        gameObject.SetActive(false);
    }

    
}
