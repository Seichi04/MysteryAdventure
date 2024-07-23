using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour,IDamagable,IAttackable
{
    [field: Header("Reference")]
    [field: SerializeField]public PlayerSO PlayerSO {get; private set;}
    [field: SerializeField]public TagLayerSO TagLayerSO {get;private set;}
    [field: SerializeField] public PlayerCollider PlayerCollider {get; private set;}

    [field: SerializeField]private GameObject ShieldObject;
 
    public PlayerInput Input{get; private set;}
    public PlayerBodyCollider PlayerBodyCollider;

    public Rigidbody2D Rigibody2D {get; private set;}
    public Animator Animator {get;set;}
    public GhostEffect GhostEffect;
    public HealthSlider HealthSlider;
    public ShieldSlider ShieldSlider;
    public AudioSource playerAudioSource;

    public PlayerStateMachine playerStateMachine;

    private void Awake() {
        Input = GetComponent<PlayerInput>();
        Rigibody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponentInChildren<Animator>();
        playerStateMachine = new PlayerStateMachine(this);

        PlayerSO.PlayerAnimationData.Initialize();

        playerStateMachine.ReusableData.MaxHealth = PlayerSO.BaseHealth;
        playerStateMachine.ReusableData.MaxShield = PlayerSO.BaseShield;
        playerStateMachine.ReusableData.CurrentHealth = playerStateMachine.ReusableData.MaxHealth;
        playerStateMachine.ReusableData.CurrentShield = 0;

        UpdateMaxHealthUI();
        UpdateMaxShieldUI();
        UpdateCurrentHealthUI();
        UpdateCurrentShieldUI();
    }

    private void Start() {
        LoadData();

        playerStateMachine.ChangeState(playerStateMachine.IdleState);
        UpdateMaxHealthUI();
        UpdateMaxShieldUI();
        UpdateCurrentHealthUI();
        UpdateCurrentShieldUI();
    }

    private void Update() {
        playerStateMachine.HandleInput();
        playerStateMachine.Update();

        UpdateShieldState();

        //Debug.Log("Health: " + playerStateMachine.ReusableData.CurrentHealth.ToString() + " Shield: " + playerStateMachine.ReusableData.CurrentShield.ToString());
    }

    private void FixedUpdate() {
        playerStateMachine.PhysicsUpdate();
    }

    public void OnAnimationEnterEvent()
    {
        playerStateMachine.OnAnimationEnterEvent();
    }
    public void OnAnimationExitEvent()
    {
        playerStateMachine.OnAnimationExitEvent();
    }
    public void OnAnimationTransitionEvent()
    {
        playerStateMachine.OnAnimationTransitionEvent();
    }

    public void DestroyPlayer(float second=0f)
    {
        Destroy(gameObject,second);
    }

    public int GetAttack()
    {
        return PlayerSO.AttackStateData.BaseAttack * playerStateMachine.ReusableData.CurrentAttackModifier;
    }
    public void TakeDamage(int dam)
    {
        if(playerStateMachine.ReusableData.CurrentShield<= 0)
        {
            playerStateMachine.ReusableData.CurrentHealth -= dam;
        }
        else
        {
            playerStateMachine.ReusableData.CurrentShield -= dam;
            if(playerStateMachine.ReusableData.CurrentShield <0)
            {
                playerStateMachine.ReusableData.CurrentHealth += playerStateMachine.ReusableData.CurrentShield;
                playerStateMachine.ReusableData.CurrentShield =0;
            }
        }
        UpdateMaxHealthUI();
        UpdateMaxShieldUI();
        UpdateCurrentHealthUI();
        UpdateCurrentShieldUI();
    }

    private void UpdateShieldState()
    {
        ShieldObject.transform.position = Vector2.MoveTowards(ShieldObject.transform.position,GetComponentInChildren<CapsuleCollider2D>().bounds.center, 20 * Time.deltaTime);
        if(playerStateMachine.ReusableData.CurrentShield>0)
        {
            ShieldObject.SetActive(true);
        }
        else
        {
            if(ShieldObject.activeInHierarchy)
            {
                ShieldObject.SetActive(false);
            }
        }
    }

    public void UpdateCurrentHealthUI()
    {
        HealthSlider.SetCurrentHealth(playerStateMachine.ReusableData.CurrentHealth,playerStateMachine.ReusableData.MaxHealth);
    }
    public void UpdateMaxHealthUI()
    {
        HealthSlider.SetMaxHealth(playerStateMachine.ReusableData.CurrentHealth,playerStateMachine.ReusableData.MaxHealth);
    }

    public void UpdateCurrentShieldUI()
    {
        ShieldSlider.SetCurrentShield(playerStateMachine.ReusableData.CurrentShield,playerStateMachine.ReusableData.MaxShield);
    }
    public void UpdateMaxShieldUI()
    {
        ShieldSlider.SetMaxShield(playerStateMachine.ReusableData.CurrentShield,playerStateMachine.ReusableData.MaxShield);
    }


    public SaveData GetDataSave()
    {
        SaveData saveData  = new();
        saveData.MaxHealth = playerStateMachine.ReusableData.MaxHealth;
        saveData.Health = playerStateMachine.ReusableData.CurrentHealth;
        saveData.MaxShield = playerStateMachine.ReusableData.MaxShield;
        saveData.Shield = playerStateMachine.ReusableData.CurrentShield;
        saveData.Position = transform.position;
        return saveData;
    }

    public void LoadData()
    {
        if(GameManager.Instance.SaveData != null)
        {
            playerStateMachine.ReusableData.MaxHealth = GameManager.Instance.SaveData.MaxHealth;
            playerStateMachine.ReusableData.CurrentHealth = GameManager.Instance.SaveData.Health;
            playerStateMachine.ReusableData.MaxShield = GameManager.Instance.SaveData.MaxShield;
            playerStateMachine.ReusableData.CurrentShield = GameManager.Instance.SaveData.Shield;
            transform.position = GameManager.Instance.SaveData.Position;
        }
    }



}
