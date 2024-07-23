using UnityEngine;
using System;

[Serializable]
public class SlideStateData
{
    [field: SerializeField] public float SlideForceModifier {get; private set;} = 1f;
    [field: SerializeField][field: Range(0f,2f)] public float TimeSlideMin {get;private set;} = 0.1f;
    [field: SerializeField][field: Range(0f,2f)] public float TimeSlideMax {get;private set;} = 0.5f;
    [field: SerializeField][field: Range(0f,2f)] public float SlideCoolDown {get;private set;} = 1f;
}