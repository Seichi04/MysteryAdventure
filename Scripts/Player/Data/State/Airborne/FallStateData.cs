using UnityEngine;
using System;

[Serializable]
public class FallStateData
{
    [field: SerializeField] public float FallSpeedModifier {get; private set;} = 1f;
    [field: SerializeField] public float SpeedModifier {get; private set;} = 1f;
    
}