using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerReusableData
{
    //Input
    public Vector2 MovementInput {get;set;}
    public bool ShouldDash {get;set;} = false;
    public bool ShouldAttack {get; set;} = false;
    public bool ShouldJump {get;set;} = false;
    public bool NeedNewStartJump {get;set;} = true;
    public bool ShouldSlide {get;set;} = false;
    public bool ShouldEdge {get;set;} = false;

    //trigger
    public bool IsGrounded {get;set;}
    public bool IsWallFront {get;set;}
    public bool IsWallBack {get;set;}
    public bool IsWallTop {get;set;}
    public bool IsEdge {get;set;}
    public bool IsRight {get;set;} = true;
    public bool IsLadder {get;set;} = false;

    public bool IsAttacked {get;set;} = false;

    // fuction var
    public int JumpCount {get;set;} = 0;


    //movement
    public float CurrentSpeedModifier {get;set;} = 1f;
    public float CurrentJumpForceModifier {get; set;} = 1f;
    public float CurrentFallSpeedModifier {get;set;} = 1f;
    public float CurrentDashForceModifier {get;set;} = 1f;
    public float CurrentSlideForceModifier {get;set;} = 1f;
    public float CurrentLadderSpeedModifier {get;set;} = 1f;
    public float CurrentWallSlideSpeedModifier {get;set;} = 1f;


    //attack
    public int CurrentAttackModifier {get;set;} =1;

    //time var
    public float TimeDash {get;set;}
    public float TimeSlide {get;set;}
    public float TimeHurt { get; set; } = 0f;
    public float TimeAttack {get;set;} = 0f;


    public int MaxHealth {get;set;} =100;
    public int MaxShield {get;set;} = 0;
    public int CurrentHealth {get;set;} =100;
    public int CurrentShield {get;set;} = 0;
    public int DirectionKnockback {get;set;} = -1;
    



}
