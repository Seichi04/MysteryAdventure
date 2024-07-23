using System;
using UnityEngine;


[Serializable]
public class AttackStateData
{
    [field: SerializeField] public int BaseAttack {get;private set;} = 1;
    [field: SerializeField] public NomalAttackStateData NomalAttackStateData{get;private set;}
    [field: SerializeField] public DashAttackStateData DashAttackStateData{get;private set;}
    [field: SerializeField] public float AttackCoolDown {get;private set;} = 0.12f; 
}