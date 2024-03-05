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
        dmg.Types[_elemName] += DmgInn;

        switch ((outLayer, midLayer))
        {
            case (ElemType.Pyro, ElemType.Pyro):
                dmg.Types[ElemType.Pyro] += 0.5f * DmgInn;
                break;

            case (ElemType.Pyro, ElemType.Oxy):
                Effect = stun;
                break;

            case (ElemType.Pyro, ElemType.Geo):
                dmg.Types[ElemType.Pyro] += 1.5f * DmgInn;
                break;

            case (ElemType.Pyro, ElemType.Aero):
                Effect.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Pyro):

                Effect.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Oxy):
                Effect.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Geo):

                break;

            case (ElemType.Geo, ElemType.Aero):
                Effect.MultipleTime(EffectTimeMultiX3);
                break;

            case (ElemType.H2O, ElemType.H2O):
                dmg.Types[ElemType.Aero] += 0.5f * DmgInn;
                Effect = stun;
                Effect.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.H2O, ElemType.Kryo):
                dmg.Types[ElemType.Kryo] += 0.5f * DmgInn;
                dmg.Types[ElemType.Aero] += 0.5f * DmgInn;
                Effect = stun;
                break;

            case (ElemType.H2O, ElemType.Oxy):
                Effect.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.H2O, ElemType.Geo):

                break;

            case (ElemType.H2O, ElemType.Aero):
                dmg.Types[ElemType.Aero] += DmgMultiX3 * DmgInn;
                Effect = stun;
                Effect.MultipleTime(EffectTimeMultiX3);
                break;

            case (ElemType.Kryo, ElemType.H2O):
                dmg.Types[ElemType.Kryo] += DmgInn;
                dmg.Types[ElemType.Aero] += 0.5f * DmgInn;
                Effect = stun;
                Effect.MultipleTime(EffectTimeMultiX3);
                break;

            case (ElemType.Kryo, ElemType.Kryo):

                break;

            case (ElemType.Kryo, ElemType.Oxy):
                Effect.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.Kryo, ElemType.Geo):

                break;

            case (ElemType.Kryo, ElemType.Aero):
                Effect.MultipleTime(EffectTimeMultiX3);
                break;

            case (ElemType.Geo, ElemType.H2O):
                dmg.Types[ElemType.Aero] += 0.5f * DmgInn;
                Effect = stun;
                Effect.MultipleTime(EffectTimeMultiX3);
                break;

            case (ElemType.Geo, ElemType.Kryo):

                break;

            case (ElemType.Null, ElemType.Pyro):
                dmg.Types[ElemType.Aero] *= DmgMultiX2;
                break;

            case (ElemType.Null, ElemType.H2O):
                dmg.Types[ElemType.Aero] *= DmgMultiX2;
                break;

            case (ElemType.Null, ElemType.Kryo):
                dmg.Types[ElemType.Aero] *= DmgMultiX2;
                break;

            case (ElemType.Null, ElemType.Geo):
                dmg.Types[ElemType.Aero] *= DmgMultiX2;
                break;

            case (ElemType.Null, ElemType.Null):
                dmg.Types[_elemName] *= DmgMultiX2;
                break;

            default:
                Debug.Log("CantFire");
                dmg.Types[_elemName] = 0;
                Effect = null;
                break;


        }
        return (dmg, Effect);
    }

    
}
