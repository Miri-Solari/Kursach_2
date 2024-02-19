using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] protected GameObject[] Slots;

    public static event Action<Inventory> SlotsChange;

    protected void Awake()
    {
        SlotsChange?.Invoke(this);
    }
    public GameObject[] GetSlots()
    {
        return Slots;
    }
}
