using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBodyCollider : MonoBehaviour
{
    public TagLayerSO TagLayerSO;
    public Player Player;
    public bool IsLadder;
    public bool IsAttacked;
    public Vector2 PosLadder;
    public int DamReceive =0;
    public AudioSource BuffAudioSource;

    private void Start() {
        TagLayerSO = GetComponentInParent<Player>().TagLayerSO;
        Player = GetComponentInParent<Player>();
        IsLadder = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag(TagLayerSO.LadderTag))
        {
            IsLadder = true;
            PosLadder = other.transform.position;
        }
        if(other.gameObject.CompareTag(TagLayerSO.EnemyTouch) || other.CompareTag(TagLayerSO.BulletTag))
        {
            Player.playerStateMachine.ReusableData.DirectionKnockback = (other.gameObject.transform.position.x > transform.position.x) ? -1: 1;
            IsAttacked = true;
            //Debug.LogError("IsAttacked");
            DamReceive = other.gameObject.GetComponent<IAttackable>().GetAttack();
        }

        if(other.gameObject.CompareTag(TagLayerSO.BuffTag))
        {
            Buff buff = other.GetComponent<IBuff>().GetBuff();
            AudioManager.Instance.PlayCollectBuffAudio(BuffAudioSource);
            if(buff.type == BuffEnum.HealthBuff)
            {
                Player.playerStateMachine.ReusableData.MaxHealth += buff.AmountBuff;
                Player.playerStateMachine.ReusableData.CurrentHealth += buff.AmountBuff;
                other.GetComponent<IBuff>().Disappear();
                Player.UpdateMaxHealthUI();
                Player.UpdateCurrentHealthUI();
            }
            else if(buff.type == BuffEnum.ShieldBuff)
            {
                Player.playerStateMachine.ReusableData.MaxShield += buff.AmountBuff;
                Player.playerStateMachine.ReusableData.CurrentShield += buff.AmountBuff;
                other.GetComponent<IBuff>().Disappear();
                Player.UpdateMaxShieldUI();
                Player.UpdateCurrentShieldUI();
            }
            else if(buff.type == BuffEnum.HealthRecover 
                && Player.playerStateMachine.ReusableData.CurrentHealth < Player.playerStateMachine.ReusableData.MaxHealth)
            {
                Player.playerStateMachine.ReusableData.CurrentHealth += buff.AmountBuff;
                if (Player.playerStateMachine.ReusableData.CurrentHealth > Player.playerStateMachine.ReusableData.MaxHealth)
                {
                    Player.playerStateMachine.ReusableData.CurrentHealth = Player.playerStateMachine.ReusableData.MaxHealth;
                }
                other.GetComponent<IBuff>().Disappear();
                Player.UpdateCurrentHealthUI();
            }
            else if(buff.type == BuffEnum.ShieldRecover
                && Player.playerStateMachine.ReusableData.CurrentShield < Player.playerStateMachine.ReusableData.MaxShield)
            {
                Player.playerStateMachine.ReusableData.CurrentShield += buff.AmountBuff;
                if (Player.playerStateMachine.ReusableData.CurrentShield > Player.playerStateMachine.ReusableData.MaxShield)
                {
                    Player.playerStateMachine.ReusableData.CurrentShield = Player.playerStateMachine.ReusableData.MaxShield;
                }
                other.GetComponent<IBuff>().Disappear();
                Player.UpdateCurrentShieldUI();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag(TagLayerSO.LadderTag))
            IsLadder = false;
        if(other.CompareTag(TagLayerSO.BulletTag) || other.gameObject.CompareTag(TagLayerSO.EnemyTouch))
        {
            IsAttacked = false;
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag(TagLayerSO.EnemyTouch)  || other.gameObject.CompareTag(TagLayerSO.BulletTag))
        {
            Player.playerStateMachine.ReusableData.DirectionKnockback = (other.gameObject.transform.position.x > transform.position.x) ? -1: 1;
            IsAttacked = true;
            DamReceive = other.gameObject.GetComponent<IAttackable>().GetAttack();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag(TagLayerSO.EnemyTouch))
        {
            IsAttacked = false;
        }
    }
}
