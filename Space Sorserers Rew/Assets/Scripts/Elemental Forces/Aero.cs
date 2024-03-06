using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Aero : BaseElem
{
    private void Awake()
    {
        _elemName = ElemType.Aero;
    }

    public override (Damage, BaseEffect) InnLayer(ElemType midLayer, ElemType outLayer) // логика, когда внутренний слой
    {
        Damage dmg = new(pyro: 0);
        dmg.Types[_elemName] += dmgInn;

        switch ((outLayer, midLayer))
        {
            case (ElemType.Pyro, ElemType.Pyro):
                dmg.Types[ElemType.Pyro] += 0.5f * dmgInn;
                break;

            case (ElemType.Pyro, ElemType.Oxy):
                effect = stun;
                break;

            case (ElemType.Pyro, ElemType.Geo):
                dmg.Types[ElemType.Pyro] += 1.5f * dmgInn;
                break;

            case (ElemType.Pyro, ElemType.Aero):
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Pyro):

                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Oxy):
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Geo):

                break;

            case (ElemType.Geo, ElemType.Aero):
                effect.MultipleTime(effectTimeMultiX3);
                break;

            case (ElemType.H2O, ElemType.H2O):
                dmg.Types[ElemType.Aero] += 0.5f * dmgInn;
                effect = stun;
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.H2O, ElemType.Kryo):
                dmg.Types[ElemType.Kryo] += 0.5f * dmgInn;
                dmg.Types[ElemType.Aero] += 0.5f * dmgInn;
                effect = stun;
                break;

            case (ElemType.H2O, ElemType.Oxy):
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.H2O, ElemType.Geo):

                break;

            case (ElemType.H2O, ElemType.Aero):
                dmg.Types[ElemType.Aero] += dmgMultiX3 * dmgInn;
                effect = stun;
                effect.MultipleTime(effectTimeMultiX3);
                break;

            case (ElemType.Kryo, ElemType.H2O):
                dmg.Types[ElemType.Kryo] += dmgInn;
                dmg.Types[ElemType.Aero] += 0.5f * dmgInn;
                effect = stun;
                effect.MultipleTime(effectTimeMultiX3);
                break;

            case (ElemType.Kryo, ElemType.Kryo):

                break;

            case (ElemType.Kryo, ElemType.Oxy):
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Kryo, ElemType.Geo):

                break;

            case (ElemType.Kryo, ElemType.Aero):
                effect.MultipleTime(effectTimeMultiX3);
                break;

            case (ElemType.Geo, ElemType.H2O):
                dmg.Types[ElemType.Aero] += 0.5f * dmgInn;
                effect = stun;
                effect.MultipleTime(effectTimeMultiX3);
                break;

            case (ElemType.Geo, ElemType.Kryo):

                break;

            case (ElemType.Null, ElemType.Pyro):
                dmg.Types[ElemType.Aero] *= dmgMultiX2;
                break;

            case (ElemType.Null, ElemType.H2O):
                dmg.Types[ElemType.Aero] *= dmgMultiX2;
                break;

            case (ElemType.Null, ElemType.Kryo):
                dmg.Types[ElemType.Aero] *= dmgMultiX2;
                break;

            case (ElemType.Null, ElemType.Geo):
                dmg.Types[ElemType.Aero] *= dmgMultiX2;
                break;

            case (ElemType.Null, ElemType.Null):
                dmg.Types[_elemName] *= dmgMultiX2;
                break;

            default:
                Debug.Log("CantFire");
                dmg.Types[_elemName] = 0;
                effect = null;
                break;


        }
        return (dmg, effect);
    }

    
}
