using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LizardData
{
    [field: SerializeField][field: Range(0f,10f)] public int Health {get;private set;} = 3;
    [field: SerializeField][field: Range(0f,10f)] public float Speed {get;private set;} = 4f;
    [field: SerializeField][field: Range(0f,10f)] public int Attack {get;private set;} = 2;
}
