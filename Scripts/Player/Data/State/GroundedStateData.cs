using System;
using UnityEngine;

[Serializable]
public class GroundedStateData
{
    [field: SerializeField][field: Range(0f,25f)] public float BaseSpeed {get;set;} = 10f;
    [field: SerializeField] public float BaseSlideForce {get; private set;} = 30f;

    [field: SerializeField] public CrouchStateData CrouchStateData {get;private set;}
    [field: SerializeField] public IdleStateData IdleStateData {get; private set;}
    [field: SerializeField] public RunStateData RunStateData {get; private set;}
    [field: SerializeField] public SlideStateData SlideStateData {get; private set;}
}