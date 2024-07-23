using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class OrcData
{
    [field: SerializeField][field: Range(0f,10f)] public int Health {get;private set;} = 2;
    [field: SerializeField][field: Range(0f,10f)] public float Speed {get;private set;} = 2.5f;
    [field: SerializeField][field: Range(0f,10f)] public float ChaseSpeed {get;private set;} = 4f;
    [field: SerializeField][field: Range(0f,10f)] public int Attack {get;private set;} = 2;
    [field: SerializeField][field: Range(0f,10f)] public int AttackCooldown {get;private set;} = 2;


}
