using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kryo : BaseElem
{
    private void Awake()
    {
        _elemName = ElemType.Kryo;
    }

    public override (Damage, BaseEffect) InnLayer(ElemType midLayer, ElemType outLayer) // логика, когда внутренний слой
    {
        Damage dmg = new(pyro: 0);
        dmg.Types[_elemName] += DmgInn;
        switch ((outLayer, midLayer))
        {
            case (ElemType.H2O, ElemType.H2O):
                Effect.MultipleTime(EffectTimeMultiX3);
                dmg.Types[ElemType.Kryo] += 0.5f * DmgInn;
                break;

            case (ElemType.H2O, ElemType.Kryo):
                Effect.MultipleTime(EffectTimeMultiX3);
                dmg.Types[ElemType.Kryo] += DmgInn; 
                break;

            case (ElemType.H2O, ElemType.Oxy):
                Effect.MultipleTime(EffectTimeMultiX2);
                dmg.Types[ElemType.Kryo] += 0.5f * DmgInn; 
                break;

            case (ElemType.H2O, ElemType.Geo):
                dmg.Types[ElemType.Kryo] += 0.5f * DmgInn;
                break;

            case (ElemType.H2O, ElemType.Aero):
                dmg.Types[ElemType.Aero] += 0.5f * DmgInn;
                dmg.Types[ElemType.Kryo] += 0.5f * DmgInn;
                break;

            case (ElemType.Kryo, ElemType.H2O):
                dmg.Types[ElemType.Kryo] += DmgInn;
                Effect.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.Kryo, ElemType.Kryo):
                Effect = stun;
                Effect.MultipleTime(EffectTimeMultiX3 * 1.5f); 
                break;

            case (ElemType.Kryo, ElemType.Oxy):
                Effect.MultipleTime(EffectTimeMultiX3); 
                break;

            case (ElemType.Kryo, ElemType.Geo):
                dmg.Types[ElemType.Kryo] += 0.5f * DmgInn;
                break;

            case (ElemType.Kryo, ElemType.Aero):
                Effect.MultipleTime(EffectTimeMultiX2); 
                break;

            case (ElemType.Geo, ElemType.H2O):
                dmg.Types[ElemType.Kryo] += 0.5f * DmgInn;
                Effect.MultipleTime(EffectTimeMultiX2); 
                break;

            case (ElemType.Geo, ElemType.Kryo):
                dmg.Types[ElemType.Kryo] += 0.5f * DmgInn; 
                Effect.MultipleTime(EffectTimeMultiX3);
                break;

            case (ElemType.Geo, ElemType.Oxy):
                Effect.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Geo):

                break;

            case (ElemType.Geo, ElemType.Aero):
                
                break;

        }
        return (dmg, Effect);
    }

    
}
