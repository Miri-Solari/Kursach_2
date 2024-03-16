using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Action Equip;
    public Action UnEquip;
    public bool IsFilled { get; private set; } = false;
    public ItemType ItemType = ItemType.All;
    private bool ItIsArmorSlot;

    private void Awake()
    {
        IsFilled = transform.GetComponentInChildren<SlotsItem>() != null;
        ItIsArmorSlot = ItemType == ItemType.Body || ItemType == ItemType.Legs || ItemType == ItemType.Head || ItemType == ItemType.Boots || ItemType == ItemType.Hand;
    }

    public void Fill()
    {
        IsFilled = true;
        if (ItIsArmorSlot && Equip != null)
        {
            Equip.Invoke();
        }
    }

    public void Clear()
    {
        IsFilled = false;
        if (ItIsArmorSlot && Equip != null)
        {
            UnEquip.Invoke();
        }
    }
    

    public bool CanPutInto(ItemType other)
    {
        if (ItemType == ItemType.All)
        {
            return true;
        }
        return ItemType == other;
    }

}
