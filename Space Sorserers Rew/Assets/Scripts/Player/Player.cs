using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BaseUnit, IArmorAffectable // отслеживает статы и передаёт их другим
{
    [SerializeField] Armor _helmet;
    [SerializeField] Armor _bodyArmor;
    [SerializeField] Armor _hands;
    [SerializeField] Armor _legs;
    [SerializeField] Armor _boots;
    [SerializeField] private bool _isEffectApply;
    private EffectResist _effectResist;
    private EffectResist _startEffectResist;


    public bool IsApplyEffect { get => _isEffectApply; set => _isEffectApply = value; }
    public EffectResist Resist { get => _effectResist; set => _effectResist = value; }

    public Resistances GetResistance()
    {
        return _resistances;
    }

    public float GetHP()
    {
        return HP;
    }

    protected override void Awake()
    {
        base.Awake();
        _effectResist = new EffectResist(fire: 0);
        _startEffectResist = _effectResist;
    }

    public void EquipHelmet(Armor helmet)   {_helmet = helmet; _helmet.GiveEffect(this, this); }
    public void EquipArmor(Armor bodyArmor)  {_bodyArmor = bodyArmor; _bodyArmor.GiveEffect(this, this); }
    public void EquipHands(Armor hands)  {_hands = hands; _hands.GiveEffect(this, this); }
    public void EquipLegs(Armor legs)   {_legs = legs; _legs.GiveEffect(this, this); }
    public void EquipBoots(Armor boots) {_boots = boots; _boots.GiveEffect(this, this); }


    public void UnEquipHelmet() { _helmet = null; ResetResist(); }
    public void UnEquipArmor() { _bodyArmor = null; ResetResist(); }
    public void UnEquipHand() { _hands = null; ResetResist(); }
    public void UnEquipLegs() { _legs = null; ResetResist(); }
    public void UnEquipBoots() { _boots = null; ResetResist(); }

    public void ResetResist()
    {
        _resistances = _startResist;
        _effectResist = _startEffectResist;
        if(_bodyArmor != null) EquipArmor(_bodyArmor); //порядок важен
        if(_legs != null) EquipLegs(_legs);
        if(_helmet != null) EquipHelmet(_helmet);
        if(_hands != null) EquipHands(_hands);
        if(_boots != null) EquipBoots(_boots);
    }
}
