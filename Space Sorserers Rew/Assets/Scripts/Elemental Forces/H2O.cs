using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2O : BaseElem
{
    
    private void Awake()
    {
        _elemName = ElemType.H2O;
    }

    public override (Damage, BaseEffect) InnLayer(ElemType midLayer, ElemType outLayer) // логика, когда внутренний слой
    {
        Damage dmg = new();
        dmg.Types[_elemName] += DmgInn;
        switch ((outLayer, midLayer))
        {
            case (ElemType.H2O, ElemType.H2O):
                Effect.MultipleTime(EffectTimeMultiX3);
                dmg.Types[ElemType.H2O] *= DmgMultiX3; 
                break;

            case (ElemType.H2O, ElemType.Kryo):
                Effect.MultipleTime(EffectTimeMultiX2);
                dmg.Types[ElemType.Kryo] += 0.5f * DmgInn; 
                break;

            case (ElemType.H2O, ElemType.Oxy):
                Effect.MultipleTime(EffectTimeMultiX2);
                dmg.Types[ElemType.H2O] += 0.5f * DmgInn; 
                break;

            case (ElemType.H2O, ElemType.Geo):
                dmg.Types[ElemType.H2O] += 0.5f * DmgInn; 
                break;

            case (ElemType.H2O, ElemType.Aero):
                Effect = stun;
                dmg.Types[ElemType.Aero] += DmgInn; 
                break;

            case (ElemType.Kryo, ElemType.H2O):
                dmg.Types[ElemType.Kryo] += DmgInn;
                Effect.MultipleTime(EffectTimeMultiX3); 
                break;

            case (ElemType.Kryo, ElemType.Kryo): 
                Effect.MultipleTime(EffectTimeMultiX2);
                dmg.Types[ElemType.Kryo] += DmgMid;
                break;

            case (ElemType.Kryo, ElemType.Oxy): 
                Effect.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.Kryo, ElemType.Geo): 
                
                break;

            case (ElemType.Kryo, ElemType.Aero):
                Effect = stun;
                Effect.MultipleTime(EffectTimeMultiX2);
                dmg.Types[ElemType.Aero] += 0.5f * DmgInn; 
                break;

            case (ElemType.Geo, ElemType.H2O):
                Effect.MultipleTime(EffectTimeMultiX3); 
                break;

            case (ElemType.Geo, ElemType.Kryo):
                dmg.Types[ElemType.Kryo] += DmgInn;
                Effect.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Oxy):
                Effect.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Geo):
                
                break;

            case (ElemType.Geo, ElemType.Aero):
                Effect = stun;
                dmg.Types[ElemType.Aero] += 0.5f * DmgInn;
                break;

        }
        return (dmg, Effect);
    }

    
}
