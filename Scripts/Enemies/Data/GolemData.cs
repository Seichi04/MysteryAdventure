using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class GolemData
{
    [field: SerializeField][field: Range(0f,100f)] public int Health {get;private set;} = 50;
    
    [field: Header("IdleState")]
    [field: SerializeField][field: Range(0f,20f)] public float SpeedIdle {get;private set;} = 5f;
    [field: SerializeField][field: Range(0f,10f)] public int AttackIdle {get;private set;} = 3;
    [field: SerializeField][field: Range(0f,10f)] public float TimeAttackCoolDown {get;private set;} = 3f;


    [field: Header("ShootState")]
    [field: SerializeField][field: Range(0f,100f)] public float SpeedBullet {get;private set;} = 70f;

    [field: Header("ImmuneState")]
    [field: SerializeField][field: Range(0f,100f)] public float SpeedImmune1 {get; private set;} = 50f;
    [field: SerializeField][field: Range(0f,100f)] public float SpeedImmune2 {get; private set;} = 30f;

    [field: SerializeField][field: Range(0f,100f)] public int AttackImmune {get;private set;} = 5;

    [field: Header("ThornState")]
    [field: SerializeField][field: Range(0f,100f)] public float SpeedThornState {get;private set;} = 50f;
    [field: SerializeField][field: Range(0f,10f)] public float TimeThorne1State {get;private set;} = 1.5f;
    [field: SerializeField][field: Range(0f,10f)] public float TimeThorne2State {get;private set;} = 3f;

    [field: Header("LaserState")]
    [field: SerializeField][field: Range(0f,100f)] public float SpeedLaserState {get;private set;} = 30f;

    [field: Header("Moveset")]
    [field: SerializeField] public List<GolemStateEnum> MoveSet1 {get;private set;}
    [field: SerializeField] public List<GolemStateEnum> MoveSet2 {get;private set;}

}
