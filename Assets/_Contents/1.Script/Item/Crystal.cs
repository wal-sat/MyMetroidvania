using UnityEngine;

public class Crystal : ItemBase
{
    protected override void Get()
    {
        base.Get();

        S_PlayerInformation.instance.IncrementCrystalCount();
    }
}
