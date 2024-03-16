using Assets.Scripts;
using System;
using UnityEngine;

public abstract class BaseArmor : MonoBehaviour
{
    [Serializable]
    public struct Res // считывание сопротивлений с инспектора
    {
        public ElemType name;
        public float value;
    }
    [SerializeField] protected Res[] _resistanceArray;

    protected Resistances _resistances = new Resistances(pyro: 1);
    [SerializeField] protected ArmorEffect _armorEffect;

    public abstract void GiveEffect(IArmorAffectable targetArmor, IResistable targetResist);

}
