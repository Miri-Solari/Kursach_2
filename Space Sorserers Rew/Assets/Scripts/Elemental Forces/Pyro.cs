using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyro : BaseElem
{

    private void Awake()
    {
        _elemName = ElemType.Pyro;
    }

    public override (Damage, BaseEffect) InnLayer(ElemType midLayer, ElemType outLayer) // логика, когда внутренний слой
    {
        Damage dmg = new(pyro:0);
        dmg.Types[_elemName] += dmgInn;
        switch ((outLayer, midLayer))
        {
            case (ElemType.Pyro, ElemType.Pyro):
                effect.MultipleTime(effectTimeMultiX3);
                dmg.Types[ElemType.Pyro] *= dmgMultiX3;
                break;

            case (ElemType.Pyro, ElemType.Oxy):
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Pyro, ElemType.Geo):
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Pyro, ElemType.Aero):
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Pyro):
                effect.MultipleTime(effectTimeMultiX2);
                dmg.Types[ElemType.Pure] = dmgMultiX3*dmgOut;
                break;

            case (ElemType.Geo, ElemType.Oxy):
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Geo):

                break;

            case (ElemType.Geo, ElemType.Aero):
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Null,  ElemType.Pyro):
                dmg.Types[ElemType.Pyro] *= dmgMultiX2;
                break;

            case (ElemType.Null, ElemType.Geo):
                dmg.Types[ElemType.Pure] = dmgMid*dmgMultiX3 - dmgInn;
                break;

            case (ElemType.Null, ElemType.Null):

                break;

            default:
                Debug.Log("CantFire");
                dmg.Types[_elemName] = 0;
                effect = null;
                break;
        }
        Debug.Log(effect.ToString());
        return (dmg, effect);
    }

    
}
