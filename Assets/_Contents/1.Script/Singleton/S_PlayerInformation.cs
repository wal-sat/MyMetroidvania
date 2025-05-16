using System;
using UnityEngine;

public class S_PlayerInformation : Singleton<S_PlayerInformation>
{
    [SerializeField] public int MAX_HP_AMOUNT;

    public Action<int> OnHPAmountUpdateCallback;
    public Action<int> OnCoinCountUpdateCallback;
    public Action<int> OnCrystalCountUpdateCallback;

    private int _hpAmount;
    int hpAmount
    {
        get => _hpAmount;
        set
        {
            _hpAmount = Mathf.Clamp(value, 0, MAX_HP_AMOUNT);

            OnHPAmountUpdateCallback(_hpAmount);
        }
    }
    private int _coinCount;
    int coinCount
    {
        get => _coinCount;
        set
        {
            _coinCount = value;
            if (_coinCount < 0) _coinCount = 0;

            OnCoinCountUpdateCallback(_coinCount);
        }
    }
    private int _crystalCount;
    int crystalCount
    {
        get => _crystalCount;
        set
        {
            _crystalCount = value;
            if (_crystalCount < 0) _crystalCount = 0;

            OnCrystalCountUpdateCallback(_crystalCount);
        }
    }

    public void Initialize()
    {
        coinCount = 0;
        crystalCount = 0;
    }

    public int SetMaxHP()
    {
        hpAmount = MAX_HP_AMOUNT;
        return hpAmount;
    }
    public int DamageHp(int damage)
    {
        hpAmount -= damage;
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

    public void SubscribeHPAmountUpdateCallback(Action<int> action, bool isSubscribe = true)
    {
        if (isSubscribe) OnHPAmountUpdateCallback += action;
        else OnHPAmountUpdateCallback -= action;
    }
    public void SubscribeCoinCountUpdateCallback(Action<int> action, bool isSubscribe = true)
    {
        if (isSubscribe) OnCoinCountUpdateCallback += action;
        else OnCoinCountUpdateCallback -= action;
    }
    public void SubscribeCrystalCountUpdateCallback(Action<int> action, bool isSubscribe = true)
    {
        if (isSubscribe) OnCrystalCountUpdateCallback += action;
        else OnCrystalCountUpdateCallback -= action;
    }
}
