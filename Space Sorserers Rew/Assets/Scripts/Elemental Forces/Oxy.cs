using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxy : BaseElem
{
    private void Awake()
    {
        _elemName = "Pyro";
    }

    public override (Damage, BaseEffect) InnLayer() // ������, ����� ���������� ����
    {
        Damage dmg = new();
        BaseEffect effect = new();
        return (dmg, effect);
    }

    public override (Damage, BaseEffect) MidLayer() // ������, ����� ������� ����
    {
        Damage dmg = new();
        BaseEffect effect = new();
        return (dmg, effect);
    }

    public override (Damage, BaseEffect) OutLayer() // ������, ����� ������� ����
    {
        Damage dmg = new();
        BaseEffect effect = new();
        return (dmg, effect);
    }
}
