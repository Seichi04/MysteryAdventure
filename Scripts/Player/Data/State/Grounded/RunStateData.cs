using UnityEngine;
using System;

[Serializable]
public class RunStateData
{
    [field: SerializeField][field: Range(1.0f,2.5f)] public float SpeedModifier {get;set;} = 1.0f;
}