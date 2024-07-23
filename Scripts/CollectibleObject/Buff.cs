using UnityEngine;

public class Buff
{
    public BuffEnum type;
    public int AmountBuff;

    public Buff(BuffEnum type, int AmountBuff)
    {
        this.type = type;
        this.AmountBuff = AmountBuff;
    }
}