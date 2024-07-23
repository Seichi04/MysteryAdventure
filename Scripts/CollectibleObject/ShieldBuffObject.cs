using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBuffObject : MonoBehaviour, IBuff
{
    public int ShieldAmount;

    public Buff GetBuff()
    {
        return new(BuffEnum.ShieldBuff,ShieldAmount);
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
    }
}
