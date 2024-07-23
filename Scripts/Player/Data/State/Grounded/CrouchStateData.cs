using UnityEngine;
using System;

[Serializable]
public class CrouchStateData
{
    [field: SerializeField] public float SpeedModifier {get; private set;} = 0f;
}