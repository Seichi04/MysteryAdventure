using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerState : IState
{
    protected PlayerStateMachine PlayerStateMachine;
    public PlayerSO PlayerSO;


    public PlayerState(PlayerStateMachine stateMachine)
    {
        this.PlayerStateMachine = stateMachine;
        PlayerSO = PlayerStateMachine.Player.PlayerSO;
    }

    #region IState Methods
    public virtual void Enter()
    {
        //Debug.Log("State: " + GetType().Name);
        PlayerStateMachine.Player.Animator.speed = 1f;
        AddInputActionsCallback();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallback();
    }

    public virtual void HandleInput()
    {
    }

    public virtual void OnAnimationEnterEvent()
    {
        
    }

    public virtual void OnAnimationExitEvent()
    {
        
    }

    public virtual void OnAnimationTransitionEvent()
    {
        
    }
    public void OnTriggerEnter(Collider2D collider)
    {
    }

    public void OnTriggerExit(Collider2D collider)
    {
    }

    public virtual void PhysicsUpdate()
    {
        
    }

    public virtual void Update()
    {
        Move();
        Rotate();
        UpdateColliderState();      
        //Debug.Log(PlayerStateMachine.ReusableData.Health);  
    }
    #endregion

    #region Main Method
    //Movement
    protected virtual void Move()
    {
        if(PlayerStateMachine.ReusableData.MovementInput.x == 0f || PlayerStateMachine.ReusableData.CurrentSpeedModifier <=0.1f 
                || PlayerStateMachine.ReusableData.ShouldDash || PlayerStateMachine.ReusableData.ShouldSlide)
        {
            return;
        }
        float movementSpeed = GetCurrentMovementSpeed();
        Vector2 currentVelocity = GetPlayerVelocity();
        PlayerStateMachine.Player.Rigibody2D.velocity = new Vector2(movementSpeed * PlayerStateMachine.ReusableData.MovementInput.x,currentVelocity.y);
    }
    protected virtual void Rotate()
    {
        Vector2 Input = PlayerStateMachine.ReusableData.MovementInput;
        bool IsRight = PlayerStateMachine.ReusableData.IsRight;
        if( (Input.x < -0.1f &&  IsRight) )
        {
            Vector3 rotator = new Vector3(PlayerStateMachine.Player.transform.rotation.x, 180f, PlayerStateMachine.Player.transform.rotation.z);
            PlayerStateMachine.Player.transform.rotation = Quaternion.Euler(rotator);
            PlayerStateMachine.ReusableData.IsRight = !IsRight;
        }
        else if((Input.x > 0.1f && !IsRight))
        {
            Vector3 rotator = new Vector3(PlayerStateMachine.Player.transform.rotation.x, 0f, PlayerStateMachine.Player.transform.rotation.z);
            PlayerStateMachine.Player.transform.rotation = Quaternion.Euler(rotator);
            PlayerStateMachine.ReusableData.IsRight = !IsRight;
        }

    }
    
    protected virtual void KnockBack(int Direction=0)
    {
        if(Direction==0)
        {
            Direction = PlayerStateMachine.ReusableData.DirectionKnockback;
        }
        PlayerStateMachine.Player.Rigibody2D.velocity 
                = new Vector2(Direction * PlayerSO.HitStateData.ForceKnockback.x,  PlayerSO.HitStateData.ForceKnockback.y);
    }

    //Config Input
    protected virtual void AddInputActionsCallback()
    {
        PlayerStateMachine.Player.Input.PlayerActions.Movement.started += OnMovementStarted;
        PlayerStateMachine.Player.Input.PlayerActions.Movement.performed += OnMovementPerformed;
        PlayerStateMachine.Player.Input.PlayerActions.Movement.canceled += OnMovementCanceled;
        PlayerStateMachine.Player.Input.PlayerActions.Attack.started += OnAttackStarted;
        PlayerStateMachine.Player.Input.PlayerActions.Dash.started += OnDashedStarted;
        PlayerStateMachine.Player.Input.PlayerActions.Slide.started += OnSlideStarted;
        PlayerStateMachine.Player.Input.PlayerActions.Edge.started += OnEdgeStarted;
        PlayerStateMachine.Player.Input.PlayerActions.Edge.canceled += OnEdgeCanceled;
        PlayerStateMachine.Player.Input.PlayerActions.Jump.started += OnJumpStarted;
        PlayerStateMachine.Player.Input.PlayerActions.Jump.canceled += OnJumpCanceled;
    }
    protected virtual void RemoveInputActionsCallback()
    {
        PlayerStateMachine.Player.Input.PlayerActions.Movement.started -= OnMovementStarted;
        PlayerStateMachine.Player.Input.PlayerActions.Movement.performed -= OnMovementPerformed;
        PlayerStateMachine.Player.Input.PlayerActions.Movement.canceled -= OnMovementCanceled;
        PlayerStateMachine.Player.Input.PlayerActions.Attack.started -= OnAttackStarted;
        PlayerStateMachine.Player.Input.PlayerActions.Dash.started -= OnDashedStarted;
        PlayerStateMachine.Player.Input.PlayerActions.Slide.started -= OnSlideStarted;
        PlayerStateMachine.Player.Input.PlayerActions.Edge.started -= OnEdgeStarted;
        PlayerStateMachine.Player.Input.PlayerActions.Edge.canceled -= OnEdgeCanceled;
        PlayerStateMachine.Player.Input.PlayerActions.Jump.started -= OnJumpStarted;
        PlayerStateMachine.Player.Input.PlayerActions.Jump.canceled -= OnJumpCanceled;
    }

    protected virtual void UpdateColliderState()
    {
        PlayerStateMachine.ReusableData.IsGrounded = PlayerStateMachine.Player.PlayerCollider.IsGrounded;
        PlayerStateMachine.ReusableData.IsWallFront = PlayerStateMachine.Player.PlayerCollider.IsWallFront;
        PlayerStateMachine.ReusableData.IsWallBack = PlayerStateMachine.Player.PlayerCollider.IsWallBack;
        PlayerStateMachine.ReusableData.IsWallTop = PlayerStateMachine.Player.PlayerCollider.IsWallTop;
        PlayerStateMachine.ReusableData.IsEdge = PlayerStateMachine.Player.PlayerCollider.IsEdge;
        PlayerStateMachine.ReusableData.IsLadder = PlayerStateMachine.Player.PlayerBodyCollider.IsLadder;
        PlayerStateMachine.ReusableData.IsAttacked = PlayerStateMachine.Player.PlayerBodyCollider.IsAttacked;
    }

    
    #endregion


    #region Reusable Methods
    protected float GetCurrentMovementSpeed()
    {
        float baseSpeed =PlayerStateMachine.Player.PlayerSO.GroundedStateData.BaseSpeed;
        float speedModifier = PlayerStateMachine.ReusableData.CurrentSpeedModifier;
        return  baseSpeed * speedModifier;
    }
    protected Vector2 GetPlayerVelocity()
    {
        return PlayerStateMachine.Player.Rigibody2D.velocity;
    }

    protected void ResetVelocity()
    {
        PlayerStateMachine.Player.Rigibody2D.velocity = Vector2.zero;
    }

    protected virtual int GetDirection()
    {
        int direction;
        if(PlayerStateMachine.ReusableData.MovementInput.x != 0f )
        {
            direction = PlayerStateMachine.ReusableData.MovementInput.x >0 ? 1: -1;
        }
        else
        {
            direction = PlayerStateMachine.ReusableData.IsRight ? 1: -1;
        }
        return direction;
    }

    protected int GetDirectionY()
    {
        int direction;
        if(PlayerStateMachine.ReusableData.MovementInput.y != 0f )
        {
            direction = PlayerStateMachine.ReusableData.MovementInput.y >0 ? 1: -1;
        }
        else
        {
            direction = 0;
        }
        return direction;
    }

    protected virtual void StartAnimation(int AnimHash)
    {
        PlayerStateMachine.Player.Animator.SetBool(AnimHash,true);
    }
    protected virtual void StopAnimation(int AnimHash)
    {
        PlayerStateMachine.Player.Animator.SetBool(AnimHash,false);
    }

    protected virtual void SetPlayerLayer(string Layer)
    {
        PlayerStateMachine.Player.gameObject.layer = LayerMask.NameToLayer(Layer);
        foreach(Transform child in PlayerStateMachine.Player.gameObject.GetComponentsInChildren<Transform>())
        {
            child.gameObject.layer = LayerMask.NameToLayer(Layer);
        }
    }

    protected virtual void ResetInputVar()
    {
        PlayerStateMachine.ReusableData.ShouldJump = false;
        PlayerStateMachine.ReusableData.ShouldAttack = false;
        PlayerStateMachine.ReusableData.ShouldEdge = false;
        PlayerStateMachine.ReusableData.ShouldDash = false;
        PlayerStateMachine.ReusableData.ShouldSlide = false;
    }

    
    #endregion


    #region ChangeState Methods
    protected virtual void OnIdle()
    {
        if(PlayerStateMachine.ReusableData.IsGrounded && PlayerStateMachine.ReusableData.MovementInput.x == 0f)
        {
            PlayerStateMachine.ChangeState(PlayerStateMachine.IdleState);
        }
    }
    protected virtual void OnJump()
    {
        if((PlayerStateMachine.ReusableData.MovementInput.y >= 0f && PlayerStateMachine.ReusableData.JumpCount <2 
            && PlayerStateMachine.ReusableData.ShouldJump && !PlayerStateMachine.ReusableData.NeedNewStartJump)  )
        {
            PlayerStateMachine.ChangeState(PlayerStateMachine.JumpState);
        }
    }
    protected virtual void OnMove()
    {
        if( !PlayerStateMachine.ReusableData.IsGrounded || PlayerStateMachine.ReusableData.MovementInput.x == 0 || PlayerStateMachine.ReusableData.MovementInput.y < 0f)
        {
            return;
        }
        PlayerStateMachine.ChangeState(PlayerStateMachine.RunState);
    }
    protected virtual void OnFall()
    {
        if( !PlayerStateMachine.ReusableData.IsGrounded && GetPlayerVelocity().y < 0f )
        {
            //Debug.LogError("Fall");
            PlayerStateMachine.ChangeState(PlayerStateMachine.FallState);
        }
    }
    protected virtual void OnCrouch()
    {
        if(PlayerStateMachine.ReusableData.MovementInput.y < 0f && PlayerStateMachine.ReusableData.IsGrounded)
        {
            PlayerStateMachine.ChangeState(PlayerStateMachine.CrouchState);
        }
    }

    protected virtual void OnDash()
    {
        if(PlayerStateMachine.ReusableData.ShouldDash && PlayerStateMachine.ReusableData.MovementInput.y >= 0f)
        {
            PlayerStateMachine.ChangeState(PlayerStateMachine.DashState);
        }
    }
    protected virtual void OnSlide()
    {
        if(PlayerStateMachine.ReusableData.ShouldSlide && PlayerStateMachine.ReusableData.MovementInput.y >= 0f)
        {
            PlayerStateMachine.ChangeState(PlayerStateMachine.SlideState);
        }
    }

    protected virtual void OnEdge()
    {
        if(PlayerStateMachine.ReusableData.IsEdge && !PlayerStateMachine.ReusableData.IsGrounded && PlayerStateMachine.ReusableData.ShouldEdge)
        {
            PlayerStateMachine.ChangeState(PlayerStateMachine.EdgeState);
        }
    }
    protected virtual void OnLadderGrab()
    {
        if(PlayerStateMachine.ReusableData.MovementInput.y > 0f && PlayerStateMachine.ReusableData.IsLadder)
        {
            PlayerStateMachine.ChangeState(PlayerStateMachine.LadderGrabState);
        }
    }
    protected virtual void OnWallSlide()
    {
        if(PlayerStateMachine.ReusableData.IsWallBack || PlayerStateMachine.ReusableData.IsWallFront)
        {
            if(GetPlayerVelocity().y < 0f && PlayerStateMachine.ReusableData.MovementInput.x!=0f)
                PlayerStateMachine.ChangeState(PlayerStateMachine.WallSlideState);
        }
    }
    protected virtual void OnAttack()
    {
        if(PlayerStateMachine.ReusableData.ShouldAttack && Time.time - PlayerStateMachine.ReusableData.TimeAttack >= PlayerSO.AttackStateData.AttackCoolDown)
        {
            PlayerStateMachine.ChangeState(PlayerStateMachine.NomalAttackState);
        }
        else if(PlayerStateMachine.ReusableData.ShouldAttack)
        {
            PlayerStateMachine.ReusableData.ShouldAttack = false;
        }
    }

    protected virtual void OnHit()
    {
        if(PlayerStateMachine.ReusableData.IsAttacked && (Time.time - PlayerStateMachine.ReusableData.TimeHurt > PlayerSO.HitStateData.HurtCoolDown) )
        {
            int dam = PlayerStateMachine.Player.PlayerBodyCollider.DamReceive;
            //Debug.LogError(dam);
            if(PlayerStateMachine.ReusableData.CurrentHealth - dam <= 0f)
            {
                AudioManager.Instance.PlayDeathAudio(PlayerStateMachine.Player.playerAudioSource);
                PlayerStateMachine.ChangeState(PlayerStateMachine.DeathState);
            }
            else
            {
                PlayerStateMachine.ChangeState(PlayerStateMachine.HurtState);
            }
        }
    }
    #endregion

    #region InputActions Callback
    protected virtual void OnDashedStarted(InputAction.CallbackContext context)
    {
        if(Time.time - PlayerStateMachine.ReusableData.TimeDash >= PlayerSO.DashStateData.DashCoolDown && PlayerStateMachine.ReusableData.MovementInput.y >=0f)
            PlayerStateMachine.ReusableData.ShouldDash = true;
    }
    protected virtual void OnSlideStarted(InputAction.CallbackContext context)
    {
        if(Time.time - PlayerStateMachine.ReusableData.TimeSlide >= PlayerSO.GroundedStateData.SlideStateData.SlideCoolDown && PlayerStateMachine.ReusableData.IsGrounded
            && PlayerStateMachine.ReusableData.MovementInput.y >=0f)
        {
            PlayerStateMachine.ReusableData.ShouldSlide = true;
        }
    }
    protected virtual void OnEdgeStarted(InputAction.CallbackContext context)
    {
        PlayerStateMachine.ReusableData.ShouldEdge = true;
    }
    protected virtual void OnEdgeCanceled(InputAction.CallbackContext context)
    {
        PlayerStateMachine.ReusableData.ShouldEdge = false;
    }

    protected virtual void OnAttackStarted(InputAction.CallbackContext context)
    {
        PlayerStateMachine.ReusableData.ShouldAttack = true;
    }

    protected virtual void OnMovementCanceled(InputAction.CallbackContext context)
    {
        PlayerStateMachine.ReusableData.MovementInput = Vector2.zero;
    }

    protected virtual void OnMovementPerformed(InputAction.CallbackContext context)
    {
        PlayerStateMachine.ReusableData.MovementInput = context.ReadValue<Vector2>();
    }
    protected virtual void OnMovementStarted(InputAction.CallbackContext context)
    {
        PlayerStateMachine.ReusableData.MovementInput = context.ReadValue<Vector2>();
        Rotate();
    }

    protected virtual void OnJumpCanceled(InputAction.CallbackContext context)
    {
        //PlayerStateMachine.ReusableData.ShouldJump = false;
    }
    protected virtual void OnJumpStarted(InputAction.CallbackContext context)
    {
        if(PlayerStateMachine.ReusableData.NeedNewStartJump)
        {
            PlayerStateMachine.ReusableData.ShouldJump =true;
            PlayerStateMachine.ReusableData.NeedNewStartJump = false;
        }
        
    }



    #endregion
}
