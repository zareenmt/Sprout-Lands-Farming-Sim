using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Collectible[] collectibleItems;
    private Dictionary<CollectibleType, Collectible> _collectibleItemsDict = new Dictionary<CollectibleType, Collectible>();

    private void Awake()
    {
        foreach (Collectible item in collectibleItems)
        {
            AddItem(item);
        }
    }

    private void AddItem(Collectible item)
    {
        if (!_collectibleItemsDict.ContainsKey(item.type))
        {
            _collectibleItemsDict.Add(item.type,item);
        }
    }

    public Collectible GetItemByType(CollectibleType type)
    {
        if (_collectibleItemsDict.ContainsKey(type))
        {
            return _collectibleItemsDict[type];
        }

        return null;
    }
}
