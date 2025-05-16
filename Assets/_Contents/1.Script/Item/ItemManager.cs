using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class ItemManager : MonoBehaviour
{
    private List<ItemBase> _items = new List<ItemBase>();

    public void Register(ItemBase item)
    {
        if (!_items.Contains(item)) _items.Add(item);
    }

    [Button]
    public void Initialize()
    {
        foreach (var item in _items)
        {
            item.Initialize();
        }
    }
}
