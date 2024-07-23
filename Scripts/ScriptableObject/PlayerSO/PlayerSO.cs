using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Player", menuName = "Custom/Player")]
public class PlayerSO : ScriptableObject
{
    [field: SerializeField] public int BaseHealth {get;private set;}
    [field: SerializeField] public int BaseShield {get;private set;}
    [field: SerializeField] public AirborneStateData AirborneStateData {get;private set;}
    [field: SerializeField] public GroundedStateData GroundedStateData {get;private set;}
    [field: SerializeField] public AttackStateData AttackStateData {get;private set;}
    [field: SerializeField] public HitStateData HitStateData {get;private set;}
    [field: SerializeField] public DashStateData DashStateData {get;private set;}

    [field: SerializeField] public PlayerAnimationData PlayerAnimationData{get;private set;}
}
