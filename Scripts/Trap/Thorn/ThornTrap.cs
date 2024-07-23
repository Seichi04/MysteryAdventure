using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornTrap : MonoBehaviour,IAttackable
{
    public int Attack;
    public int GetAttack()
    {
        return Attack;
    }
}
