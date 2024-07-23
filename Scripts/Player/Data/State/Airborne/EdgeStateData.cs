using System;
using UnityEngine;

[Serializable]
public class EdgeStateData
{
    [field: SerializeField] public float AntiGravityForce {get; private set;} = 1f;
}