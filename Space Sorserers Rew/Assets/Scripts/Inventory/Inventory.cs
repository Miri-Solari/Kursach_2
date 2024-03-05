using System;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] protected GameObject OutLayer;
    [SerializeField] protected GameObject MidLayer;
    [SerializeField] protected GameObject InnLayer;

    public event Action<Inventory> SlotsChange;
    public static Inventory Instance;
    private ElemContainer Elems;
    protected void Awake()
    {
        Instance = this;
        BaseElem[] slots = new BaseElem[3];
        slots[2] = OutLayer.transform.GetComponentInChildren<BaseElem>();
        slots[1] = MidLayer.transform.GetComponentInChildren<BaseElem>();
        slots[0] = InnLayer.transform.GetComponentInChildren<BaseElem>();
        Elems = new ElemContainer(slots);
    }


    public ElemContainer GetSlots()
    {
        return Elems;
    }

    public void SlotIsChange()
    {
        Debug.Log("change");
        SlotsChange?.Invoke(this);
    }


}
