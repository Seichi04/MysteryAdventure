using System;
using UnityEngine;

[Serializable]
public class AirborneStateData
{
    [field: SerializeField][field: Range(5f,20f)] public float BaseJumpForce {get;set;} = 10f;
    [field: SerializeField] public float BaseFallSpeed {get;private set;} = 5f;
    [field: SerializeField][field: Range(5f,20f)] public float BaseLadderSpeed {get;set;} = 15f;
    [field: SerializeField] public float BaseWallSlideSpeed {get;private set;} = 5f;

    
    [field: SerializeField] public EdgeStateData EdgeStateData {get;private set;}
    [field: SerializeField] public FallStateData FallStateData {get;private set;}
    [field: SerializeField] public JumpStateData JumpStateData {get;private set;}
    [field: SerializeField] public LadderGrabStateData LadderGrabStateData{get;private set;}
    [field: SerializeField] public WallSlideStateData WallSlideStateData {get; private set;}
}