using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public int MaxHealth;
    public int Health;
    public int MaxShield;
    public int Shield;
    public Vector2 Position;

    public int ColliderMap;

    public string StatusEnemy;
    public string StatusBuff;
    public SaveData(int maxHealth,int health,int maxShield, int shield, Vector2 position)
    {
        MaxHealth = maxHealth;
        Health = health;
        MaxShield = maxShield;
        Shield = shield;
        Position = position;
        StatusEnemy = new string('0',GameManager.Instance.EnemyList.Count);
        StatusBuff = new string('0',GameManager.Instance.BuffList.Count);
    }
    public SaveData()
    {
    }

}