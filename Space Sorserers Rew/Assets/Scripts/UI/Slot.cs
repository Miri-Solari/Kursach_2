using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool IsFilled { get; private set; } = false;
    public ItemType ItemType = ItemType.All;

    private void Awake()
    {
        IsFilled = transform.GetComponentInChildren<SlotsItem>() != null;
    }

    public void Fill()
    {
        IsFilled = true;
    }

    public void Clear()
    {
        IsFilled = false;
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
