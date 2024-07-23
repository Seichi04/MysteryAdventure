using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public string PlayerLayer = "Player";
    public string PlayerNoTouchLayer = "PlayerNoTouch";
    public bool ShouldAttack;
    public Vector2 TargetPos;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(PlayerLayer))
        {
            ShouldAttack = true;
            TargetPos = other.gameObject.transform.position;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(PlayerLayer))
        {
            ShouldAttack = true;
            TargetPos = other.gameObject.transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(PlayerLayer))
        {
            ShouldAttack = false;
            TargetPos = other.gameObject.transform.position;
        }
    }
}
