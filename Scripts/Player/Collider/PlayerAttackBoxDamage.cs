using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBoxDamage : MonoBehaviour
{
    public GameObject AttackEffect;
    public Transform PosAttackEffect;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("EnemyNoTouch") || other.gameObject.CompareTag("EnemyTouch"))
        {
            AttackEffect.transform.position = PosAttackEffect.position;
            AttackEffect.SetActive(true);
            //Debug.Log("Attack");
        }
    }
}
