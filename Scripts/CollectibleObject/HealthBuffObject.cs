using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBuffObject : MonoBehaviour, IBuff
{
    public int HealthAmount;
    public Buff GetBuff()
    {
        return new(BuffEnum.HealthBuff, HealthAmount);
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
    }
}
