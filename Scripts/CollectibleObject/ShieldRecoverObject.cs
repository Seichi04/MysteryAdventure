using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRecoverObject : MonoBehaviour, IBuff
{
    public int ShieldAmount;
    public Buff GetBuff()
    {
        return new(BuffEnum.ShieldRecover,ShieldAmount);
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
    }
}
