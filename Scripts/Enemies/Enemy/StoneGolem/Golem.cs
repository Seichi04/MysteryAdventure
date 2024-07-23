using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Golem : MonoBehaviour, IAttackable, IDamagable
{
    [SerializeField] public EnemySO EnemySO;
    [SerializeField] public Transform Pos1Idle;
    [SerializeField] public Transform Pos2Idle;
    public Transform PlayerTransform;

    public string IdleAnimation;
    public string ShootAnimation;
    public string ImmuneAnimation;
    public string GlowAnimation;
    public string Shoot2Animation;
    public string Immune2Animation;
    public string Glow2Animation;
    public string LaserAnimation;
    public string DeathAnimation;

    public string BulletName;
    public Transform BulletPos;

    public string ThornName;
    public Transform ThornStartPos;
    public GameObject ShieldObject;

    public Transform PosImmune2;
    public string LaserName;
    public Transform PosLaser;

    public Rigidbody2D Rigidbody2D;
    public Animator Animator;
    public GolemStateMachine GolemStateMachine;
    public GolemCollider GolemCollider;

    public AudioSource audioSource;

    public GameObject NPCEnd;

    private void Awake() {
        Animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        GolemStateMachine = new GolemStateMachine(this);
        GolemCollider = GetComponent<GolemCollider>();
        GolemReusableData.Moveset = EnemySO.GolemData.MoveSet1;
        GolemReusableData.MoveCount =0;
        GolemReusableData.Health = EnemySO.GolemData.Health;
    }
    private void Start() {
        GolemStateMachine.ChangeState(GolemStateMachine.GolemIdleState);
        GolemReusableData.IsRight = true;
    }

    private void Update() {
        GolemStateMachine.HandleInput();
        GolemStateMachine.Update();
        UpdateShield();
        UpdateMoveSet();

        Debug.Log(GolemReusableData.Health);
    }

    private void FixedUpdate() {
        GolemStateMachine.PhysicsUpdate();
    }

    public void OnAnimationEnterEvent()
    {
        GolemStateMachine.OnAnimationEnterEvent();
    }
    public void OnAnimationExitEvent()
    {
        GolemStateMachine.OnAnimationExitEvent();
    }
    public void OnAnimationTransitionEvent()
    {
        GolemStateMachine.OnAnimationTransitionEvent();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        GolemStateMachine.OnTriggerEnter(other);

        if(other.gameObject.CompareTag("BoxDamage"))
        {
            //Debug.LogError("take dam");
            int dam = other.gameObject.GetComponentInParent<Player>().GetAttack();
            TakeDamage(dam);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        GolemStateMachine.OnTriggerExit(other);
    }


    public int GetAttack()
    {
        return GolemReusableData.CurrentAttack;
    }
    public void TakeDamage(int dam)
    {
        
        GolemReusableData.Health -= dam;
    }


    private void UpdateShield()
    {
        if(GolemReusableData.Shield>0)
        {
            ShieldObject.SetActive(true);
        }
        else
        {
            ShieldObject.SetActive(false);
        }
    }
    private void UpdateMoveSet()
    {
        if(GolemReusableData.Health > EnemySO.GolemData.Health/2)
        {
            GolemReusableData.Moveset= EnemySO.GolemData.MoveSet1;
        }
        else
        {
            GolemReusableData.Moveset= EnemySO.GolemData.MoveSet2;
        }

    }
}
