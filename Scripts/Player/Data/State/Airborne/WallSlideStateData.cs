using UnityEngine;
using System;

[Serializable]
public class WallSlideStateData
{
    [field: SerializeField] public float WallSlideSpeedModifier {get; private set;} = 1f;
}