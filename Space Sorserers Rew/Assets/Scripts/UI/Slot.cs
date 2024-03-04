using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Slot : MonoBehaviour
{
    public bool IsFilled { get; private set; } = false;
    [SerializeField] private ItemType _itemType = ItemType.All;
    public ItemType ItemType { get => _itemType; private set => _itemType = value; }

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


    public bool CheckForAccordance(ItemType item)
    {
        if (ItemType == ItemType.All)
        {
            return true;
        }
        else
            return ItemType == item;
    }

}
