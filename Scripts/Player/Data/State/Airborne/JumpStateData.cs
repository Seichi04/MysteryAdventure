using UnityEngine;
using System;


[Serializable]
public class JumpStateData 
{
    [field: SerializeField] public float JumpForceModifier {get; private set;} = 1f;
    [field: SerializeField] public float SpeedModifier {get; private set;} = 1f;
}