using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseElem : MonoBehaviour
{
    [SerializeField] protected Stun stun;
    [SerializeField] protected float DmgInn;
    [SerializeField] protected float DmgMid;
    [SerializeField] protected float DmgOut;
    [SerializeField] protected float EffectTimeMultiX2;
    [SerializeField] protected float EffectTimeMultiX3;
    [SerializeField] protected float DmgMultiX2;
    [SerializeField] protected float DmgMultiX3;
    [SerializeField] protected BaseEffect Effect;
    public ElemType _elemName { get; protected set; }

    public virtual (Damage, BaseEffect) InnLayer(ElemType midLayer, ElemType outLayer)
    {
        Damage dmg = new();
        BaseEffect effect = new();
        return (dmg, effect);
    }

    public virtual Damage MidLayer()
    {
        Damage dmg = new();
        dmg.Types[_elemName] += DmgMid;
        return dmg;
    }

    public virtual Damage OutLayer()
    {
        Damage dmg = new();
        dmg.Types[_elemName] += DmgOut;
        return dmg;
    }

}
