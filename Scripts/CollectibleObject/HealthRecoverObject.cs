using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRecoverObject : MonoBehaviour, IBuff
{
    public int HealthAmount;
    public Buff GetBuff()
    {
        return new(BuffEnum.HealthRecover, HealthAmount);
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
    }
}
