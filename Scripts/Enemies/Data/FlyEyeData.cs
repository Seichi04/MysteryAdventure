using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FlyEyeData 
{
    [field: SerializeField][field: Range(0f,10f)] public int Health {get;private set;} = 3;
    [field: SerializeField][field: Range(0f,10f)] public float Speed {get;private set;} = 4;
    [field: SerializeField][field: Range(0f,10f)] public int Attack {get;private set;} = 1;
    
}
