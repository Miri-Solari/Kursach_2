using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxy : BaseElem
{
    private void Awake()
    {
        _elemName = "Pyro";
    }

    public override (Damage, BaseEffect) InnLayer() // логика, когда внутренний слой
    {
        Damage dmg = new();
        BaseEffect effect = new();
        return (dmg, effect);
    }

    public override (Damage, BaseEffect) MidLayer() // логика, когда средний слой
    {
        Damage dmg = new();
        BaseEffect effect = new();
        return (dmg, effect);
    }

    public override (Damage, BaseEffect) OutLayer() // логика, когда внешний слой
    {
        Damage dmg = new();
        BaseEffect effect = new();
        return (dmg, effect);
    }
}
