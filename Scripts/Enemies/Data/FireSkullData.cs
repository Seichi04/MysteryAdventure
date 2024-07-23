using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FireSkullData
{
    [field: SerializeField] public int Health {get;private set;} = 10000;
    [field: SerializeField] public float Speed {get;private set;} = 15f;
    [field: SerializeField] public float SpeedLockTarget {get;private set;} = 5f;
    [field: SerializeField] public int Attack {get;private set;} = 100;
    [field: SerializeField] public float TimeReset {get;private set;} = 1f;
    [field: SerializeField] public float TimeDisable {get;private set;} = 2f;
    [field: SerializeField] public float TimeWaitAttack {get;private set;} = 3f;
    [field: SerializeField] public float TimeAttack {get;private set;} = 1f;

}
