using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerAnimationData
{
    [field: SerializeField] private string EdgeString = "IsEdge";
    [field: SerializeField] private string WallSlideString = "IsWallSlide";
    [field: SerializeField] private string JumpString = "IsJump";
    [field: SerializeField] private string FallString = "IsFall";
    [field: SerializeField] private string LadderGrabString = "IsLadderGrab";
    [field: SerializeField] private string IdleString = "IsIdle";
    [field: SerializeField] private string RunString = "IsRun";
    [field: SerializeField] private string SlideString = "IsSlide";
    [field: SerializeField] private string CrouchString = "IsCrouch";
    [field: SerializeField] private string NomalAttackString = "IsNomalAttack";
    [field: SerializeField] private string DashAttackString ="IsDashAttack";
    [field: SerializeField] private string HurtString = "IsHurt";
    [field: SerializeField] private string DeathString ="IsDeath";


    [field: SerializeField] private string DashString = "IsDash";
    [field: SerializeField] private string GroundedString = "IsGrounded";
    [field: SerializeField] private string AirborneString ="IsAirborne";
    [field: SerializeField] private string AttackString = "IsAttack";
    [field: SerializeField] private string HitString = "IsHit";


    public int EdgeStringHash {get;private set;}
    public int WallSlideStringHash {get;private set;}
    public int JumpStringHash {get;private set;} 
    public int FallStringHash {get;private set;}
    public int LadderGrabStringHash {get;private set;} 
    public int IdleStringHash {get;private set;}
    public int RunStringHash {get;private set;} 
    public int SlideStringHash {get;private set;} 
    public int CrouchStringHash {get;private set;} 
    public int NomalAttackStringHash {get;private set;}
    public int DashAttackStringHash {get;private set;}
    public int HurtStringHash {get; private set;}
    public int DeathStringHash {get;private set;}

    public int DashStringHash {get;private set;} 
    public int GroundedStringHash {get;private set;}
    public int AirborneStringHash {get;private set;}
    public int AttackStringHash {get;private set;}
    public int HitStringHash {get;private set;}


    public void Initialize()
    {
        EdgeStringHash = Animator.StringToHash(EdgeString);
        WallSlideStringHash = Animator.StringToHash(WallSlideString);
        JumpStringHash = Animator.StringToHash(JumpString);                                         
        FallStringHash = Animator.StringToHash(FallString);
        LadderGrabStringHash = Animator.StringToHash(LadderGrabString);
        IdleStringHash = Animator.StringToHash(IdleString);
        RunStringHash = Animator.StringToHash(RunString);
        DashStringHash = Animator.StringToHash(DashString);
        SlideStringHash = Animator.StringToHash(SlideString);
        CrouchStringHash = Animator.StringToHash(CrouchString);
        NomalAttackStringHash = Animator.StringToHash(NomalAttackString);
        HurtStringHash = Animator.StringToHash(HurtString);
        DeathStringHash = Animator.StringToHash(DeathString);

        DashAttackStringHash = Animator.StringToHash(DashAttackString);
        GroundedStringHash = Animator.StringToHash(GroundedString);
        AirborneStringHash = Animator.StringToHash(AirborneString);
        AttackStringHash = Animator.StringToHash(AttackString);
        HitStringHash = Animator.StringToHash(HitString);

    }
}
