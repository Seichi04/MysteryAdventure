using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UIElements;

public class FireBullet1 : MonoBehaviour,IAttackable
{
    [SerializeField] private string BustString;
    [SerializeField] private string FlyString;
    [SerializeField] private float BulletSpeed;
    private Animator animator;
    [SerializeField] private Rigidbody2D Rigidbody2D;
    private Vector2 direction;
    public int Attack;


    private void Awake() {
        animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() {
        float rotation = transform.eulerAngles.z - 90;
        direction = new Vector2(Mathf.Cos(rotation * Mathf.Deg2Rad),Mathf.Cos((90-rotation) * Mathf.Deg2Rad));
        //Debug.Log(rotation + " " + direction);
        Rigidbody2D.velocity = new Vector2(BulletSpeed * direction.x,BulletSpeed * direction.y);
        animator.SetBool(FlyString,true);
        animator.SetBool(BustString, false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player") ||other.gameObject.layer == LayerMask.NameToLayer("Map") || other.gameObject.CompareTag("BoxDamage"))
        {
            animator.SetBool(FlyString, false);
            animator.SetBool(BustString, true);
            Rigidbody2D.velocity = Vector2.zero;
        }
    }


    public void EnableGameObject()
    {
        gameObject.SetActive(true);
    }

    public void DisableGameObject()
    {
        gameObject.SetActive(false);

    }


    public int GetAttack()
    {
        return Attack;
    }
}
