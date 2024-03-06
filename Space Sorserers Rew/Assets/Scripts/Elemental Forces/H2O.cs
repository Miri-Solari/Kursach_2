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
        Damage dmg = new(pyro: 0);
        dmg.Types[_elemName] += dmgInn;
        switch ((outLayer, midLayer))
        {
            case (ElemType.H2O, ElemType.H2O):
                effect.MultipleTime(effectTimeMultiX3);
                dmg.Types[ElemType.H2O] *= dmgMultiX3; 
                break;

            case (ElemType.H2O, ElemType.Kryo):
                effect.MultipleTime(effectTimeMultiX2);
                dmg.Types[ElemType.Kryo] += 0.5f * dmgInn; 
                break;

            case (ElemType.H2O, ElemType.Oxy):
                effect.MultipleTime(effectTimeMultiX2);
                dmg.Types[ElemType.H2O] += 0.5f * dmgInn; 
                break;

            case (ElemType.H2O, ElemType.Geo):
                dmg.Types[ElemType.H2O] += 0.5f * dmgInn; 
                break;

            case (ElemType.H2O, ElemType.Aero):
                effect = stun;
                dmg.Types[ElemType.Aero] += dmgInn; 
                break;

            case (ElemType.Kryo, ElemType.H2O):
                dmg.Types[ElemType.Kryo] += dmgInn;
                effect.MultipleTime(effectTimeMultiX3); 
                break;

            case (ElemType.Kryo, ElemType.Kryo): 
                effect.MultipleTime(effectTimeMultiX2);
                dmg.Types[ElemType.Kryo] += dmgMid;
                break;

            case (ElemType.Kryo, ElemType.Oxy): 
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Kryo, ElemType.Geo): 
                
                break;

            case (ElemType.Kryo, ElemType.Aero):
                effect = stun;
                effect.MultipleTime(effectTimeMultiX2);
                dmg.Types[ElemType.Aero] += 0.5f * dmgInn; 
                break;

            case (ElemType.Geo, ElemType.H2O):
                effect.MultipleTime(effectTimeMultiX3); 
                break;

            case (ElemType.Geo, ElemType.Kryo):
                dmg.Types[ElemType.Kryo] += dmgInn;
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Oxy):
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Geo):
                
                break;

            case (ElemType.Geo, ElemType.Aero):
                effect = stun;
                dmg.Types[ElemType.Aero] += 0.5f * dmgInn;
                break;


            case (ElemType.Null, ElemType.H2O):
                dmg.Types[ElemType.H2O] *= dmgMultiX2;
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Null, ElemType.Kryo):
                dmg.Types[ElemType.H2O] *= dmgMultiX2;
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Null, ElemType.Geo):
                dmg.Types[ElemType.H2O] *= dmgMultiX2;
                effect.MultipleTime(effectTimeMultiX2);
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
