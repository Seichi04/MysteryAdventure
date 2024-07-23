using UnityEngine;
using System;


[Serializable]
public class HitStateData
{
    [field: SerializeField] public Vector2 ForceKnockback {get;set;} = new Vector2(3f,20f);
    [field: SerializeField] public float HurtCoolDown {get;set;} = 0.2f;
    [field: SerializeField] public DeathStateData DeathStateData {get;private set;}
    [field: SerializeField] public HurtStateData HurtStateData {get;private set;} 
}