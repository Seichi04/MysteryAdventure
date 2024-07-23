using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseArea : MonoBehaviour
{
    public string PlayerLayer = "Player";
    public string PlayerNoTouchLayer = "PlayerNoTouch";
    public bool ShouldChase;
    public Vector2 TargetPos;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(PlayerLayer))
        {
            ShouldChase = true;
            TargetPos = other.gameObject.transform.position;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(PlayerLayer))
        {
            ShouldChase = true;
            TargetPos = other.gameObject.transform.position;
        }
        if(other.gameObject.layer == LayerMask.NameToLayer(PlayerNoTouchLayer))
        {
            ShouldChase = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(PlayerLayer))
        {
            ShouldChase = false;
        }
    }
}
