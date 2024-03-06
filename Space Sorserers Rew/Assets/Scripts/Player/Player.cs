using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseUnit, IArmorAffectable
{
    [SerializeField] GameObject _helmet;
    [SerializeField] GameObject _bodyArmor;
    [SerializeField] private bool _isEffectApply;


    public bool IsApplyEffect { get => _isEffectApply; set => _isEffectApply = value; }
    public EffectResist Resist { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public Resistances GetResistance()
    {
        return _resistances;
    }

    public float GetHP()
    {
        return HP;
    }

    public void EquipHelmet(GameObject helmet)
    {
        _helmet = helmet;
    }

    public void EquipBodyArmor(GameObject bodyArmor)
    {
        _bodyArmor = bodyArmor;
    }


}
