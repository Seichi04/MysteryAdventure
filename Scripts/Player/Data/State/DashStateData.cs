using UnityEngine;
using System;

[Serializable]
public class DashStateData
{
    [field: SerializeField] public float BaseDashForce {get; private set;} = 30f;
    [field: SerializeField] public float DashForceModifier {get; private set;} = 1f;
    [field: SerializeField][field: Range(0f,2f)] public float TimeDash {get;private set;} = 0.5f;
    [field: SerializeField][field: Range(0f,2f)] public float DashCoolDown {get;private set;} = 1f;
}