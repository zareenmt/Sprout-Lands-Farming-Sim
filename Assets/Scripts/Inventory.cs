using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Inventory 
{
    [System.Serializable]
    public class Slot
    {
        public CollectibleType type;
        public Sprite icon;
        public int count; //how many items in slot
        public int maxAllowed; //maximum allowed

        public Slot()
        {
            type = CollectibleType.NONE;
            count = 0;
            maxAllowed = 99;
        }

        public bool CanAddItem()
        {
            if (count < maxAllowed)
            {
                return true;
            }

            return false;
        }

        public void AddItem(Collectible item)
        {
            type = item.type;
            icon = item.icon;
            count += 1;
        }
    }

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots)
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(Collectible item)
    {
        foreach (Slot slot in slots)
        {
            if (slot.type == item.type && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            }
        }

        foreach (Slot slot in slots)
        {
            if (slot.type == CollectibleType.NONE)
            {
                slot.AddItem(item);
                return;
            }
        }
    }
}
