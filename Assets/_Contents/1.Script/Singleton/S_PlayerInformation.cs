using System;
using UnityEngine;

public class S_PlayerInformation : Singleton<S_PlayerInformation>
{
    [SerializeField] public int MAX_HP_AMOUNT;

    [HideInInspector] public int hpAmount;
    [HideInInspector] public int coinCount;
    [HideInInspector] public int crystalCount;

    public void Initialize()
    {
        hpAmount = MAX_HP_AMOUNT;
        coinCount = 0;
        crystalCount = 0;
    }

    public int DamageHp(int damage)
    {
        hpAmount -= damage;
        hpAmount = Mathf.Clamp(hpAmount, 0, MAX_HP_AMOUNT);
        return hpAmount;
    }
    public int IncrementCoinCount(int amount = 1)
    {
        coinCount += amount;
        return coinCount;
    }
    public int IncrementCrystalCount(int amount = 1)
    {
        crystalCount += amount;
        return crystalCount;
    }
}
