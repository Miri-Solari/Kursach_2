using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseElem : MonoBehaviour
{
    public string _elemName { get; protected set; } = "el" ;

    public virtual (Damage, BaseEffect) InnLayer()
    {
        Damage dmg = new();
        BaseEffect effect = new();
        return (dmg, effect);
    }

    public virtual (Damage, BaseEffect) MidLayer()
    {
        Damage dmg = new();
        BaseEffect effect = new();
        return (dmg, effect);
    }

    public virtual (Damage, BaseEffect) OutLayer()
    {
        Damage dmg = new();
        BaseEffect effect = new();
        return (dmg, effect);
    }

}
