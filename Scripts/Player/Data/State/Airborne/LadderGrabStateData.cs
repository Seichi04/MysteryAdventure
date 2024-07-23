using UnityEngine;
using System;

[Serializable]
public class LadderGrabStateData 
{
    [field: SerializeField] public float LadderSpeedModifier {get;private set;} = 1f;
    [field: SerializeField] public float AntiGravityForce {get; private set;} = 1f;
}