using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BaseElem : MonoBehaviour
{
    [SerializeField] protected Stun stun;
    [SerializeField] protected float dmgInn;
    [SerializeField] protected float dmgMid;
    [SerializeField] protected float dmgOut;
    [SerializeField] protected float effectTimeMultiX2;
    [SerializeField] protected float effectTimeMultiX3;
    [SerializeField] protected float dmgMultiX2;
    [SerializeField] protected float dmgMultiX3;
    [SerializeField] protected BaseEffect effect;
    public ElemType _elemName { get; protected set; }

    private void Start()
    {
        effect = Instantiate(effect);
        stun = Instantiate(stun);
    }

    public virtual (Damage, BaseEffect) InnLayer(ElemType midLayer, ElemType outLayer)
    {
        Damage dmg = new(pyro: 0);
        BaseEffect effect = new();
        return (dmg, effect);
    }

    public virtual Damage MidLayer()
    {
        Damage dmg = new(pyro: 0);
        dmg.Types[_elemName] += dmgMid;
        return dmg;
    }

    public virtual Damage OutLayer()
    {
        Damage dmg = new(pyro: 0);
        dmg.Types[_elemName] += dmgOut;
        return dmg;
    }

}
