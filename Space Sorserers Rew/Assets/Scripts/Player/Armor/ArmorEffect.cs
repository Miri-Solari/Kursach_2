using System;
using UnityEngine;

public class ArmorEffect : MonoBehaviour
{
    [Serializable]
    public struct ResEff // считывание сопротивлений с инспектора
    {
        public EffectType name;
        public float value;
    }
    [SerializeField] ResEff[] _resistanceArray;

    private EffectResist _effect;

    private void Awake()
    {
        _effect = new(fire:0);
        foreach(var item in _resistanceArray)
        {
            _effect.res[item.name] = item.value;
        }
    }
    public void ApplyEffect(IArmorAffectable unit)
    {
        if (unit.IsApplyEffect)
        {
            unit.Resist += _effect;
        }
    }
}
