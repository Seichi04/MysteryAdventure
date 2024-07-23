using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDamageOrc : MonoBehaviour,IAttackable
{
    public EnemySO EnemySO;
    public int GetAttack()
    {
        return EnemySO.OrcData.Attack;
    }
}
