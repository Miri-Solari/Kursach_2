using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool IsFilled { get; private set; } = false;
    [SerializeField] public ItemType ItemType { get; private set; } = ItemType.All;

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


}
