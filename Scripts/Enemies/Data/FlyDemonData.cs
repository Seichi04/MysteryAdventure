using System;
using UnityEngine;

[Serializable]
public class FlyDemonData
{
    [field: SerializeField][field: Range(0f,10f)] public int Health {get;private set;} = 3;
    [field: SerializeField][field: Range(0f,10f)] public int Attack {get;private set;} = 3;
}