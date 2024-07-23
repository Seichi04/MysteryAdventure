using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBullet : MonoBehaviour,IAttackable
{
    [SerializeField] private float BulletSpeed;
    private Animator animator;
    [SerializeField] private Rigidbody2D Rigidbody2D;
    private Vector2 direction;
    public int Attack;
    public bool ShouldDestroy;
    private bool contact;


    private void Awake() {
        animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        ShouldDestroy = true;
    }

    private void OnEnable() {
        float rotation = transform.eulerAngles.z;
        direction = new Vector2(Mathf.Cos(rotation * Mathf.Deg2Rad),Mathf.Cos((90-rotation) * Mathf.Deg2Rad));
        Rigidbody2D.velocity = new Vector2(BulletSpeed * direction.x,BulletSpeed * direction.y);
        contact = false;
    }

    private void Update() {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player") ||other.gameObject.layer == LayerMask.NameToLayer("Map"))
        {
            //Rigidbody2D.velocity = Vector2.zero;
            ContinueAnimator();
            contact = true;
        }
    }


    public void EnableGameObject()
    {
        gameObject.SetActive(true);
    }

    public void DisableGameObject()
    {
        if(ShouldDestroy)
            gameObject.SetActive(false);
    }

    public void StopAnimator()
    {
        if(contact == false)
            animator.speed = 0f;
    }
    public void ContinueAnimator()
    {
        animator.speed = 1f;
    }


    public int GetAttack()
    {
        return Attack;
    }
}
