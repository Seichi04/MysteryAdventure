using UnityEngine;
using System;

[Serializable]
public class IdleStateData
{
    [field: SerializeField] public float SpeedModifier {get; private set;} = 0f;
}