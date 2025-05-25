using UnityEngine;

public class Coin : ItemBase
{
    protected override void Get()
    {
        base.Get();

        S_PlayerInformation.Instance.IncrementCoinCount();
    }
}
