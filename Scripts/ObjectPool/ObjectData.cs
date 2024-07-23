using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectData
{
    [field: SerializeField] public GameObject GameObjectPrefab {get;private set;}
    [field: SerializeField] public string NameGameObjectPrefab {get;private set;}
    [field: SerializeField] public int AmountToPool {get;private set;}
}
