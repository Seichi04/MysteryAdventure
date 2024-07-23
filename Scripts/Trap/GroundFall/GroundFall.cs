using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GroundFall : MonoBehaviour
{
    public float timeDelay = 1f;
    public float speed = 5f;

    private float fallModifier =0f;
    private bool IsCount = false;
    private float TimeStart;
    private Rigidbody2D Rigidbody2D;


    private void Start() {
        fallModifier = 0f;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        IsCount = false;
    }

    private void Update() {
        if(IsCount && Time.time - TimeStart > timeDelay)
        {
            fallModifier = 1f;
        }
        Rigidbody2D.velocity = new Vector2(0f,-speed * fallModifier);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            IsCount = true;
            TimeStart = Time.time;
            Destroy(gameObject,10f);
        }
    }

}
