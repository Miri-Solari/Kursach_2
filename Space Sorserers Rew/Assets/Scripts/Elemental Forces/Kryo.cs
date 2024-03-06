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
        dmg.Types[_elemName] += dmgInn;
        switch ((outLayer, midLayer))
        {
            case (ElemType.H2O, ElemType.H2O):
                effect.MultipleTime(effectTimeMultiX3);
                dmg.Types[ElemType.Kryo] += 0.5f * dmgInn;
                break;

            case (ElemType.H2O, ElemType.Kryo):
                effect.MultipleTime(effectTimeMultiX3);
                dmg.Types[ElemType.Kryo] += dmgInn; 
                break;

            case (ElemType.H2O, ElemType.Oxy):
                effect.MultipleTime(effectTimeMultiX2);
                dmg.Types[ElemType.Kryo] += 0.5f * dmgInn; 
                break;

            case (ElemType.H2O, ElemType.Geo):
                dmg.Types[ElemType.Kryo] += 0.5f * dmgInn;
                break;

            case (ElemType.H2O, ElemType.Aero):
                dmg.Types[ElemType.Aero] += 0.5f * dmgInn;
                dmg.Types[ElemType.Kryo] += 0.5f * dmgInn;
                break;

            case (ElemType.Kryo, ElemType.H2O):
                dmg.Types[ElemType.Kryo] += dmgInn;
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Kryo, ElemType.Kryo):
                effect = stun;
                effect.MultipleTime(effectTimeMultiX3 * 1.5f); 
                break;

            case (ElemType.Kryo, ElemType.Oxy):
                effect.MultipleTime(effectTimeMultiX3); 
                break;

            case (ElemType.Kryo, ElemType.Geo):
                dmg.Types[ElemType.Kryo] += 0.5f * dmgInn;
                break;

            case (ElemType.Kryo, ElemType.Aero):
                effect.MultipleTime(effectTimeMultiX2); 
                break;

            case (ElemType.Geo, ElemType.H2O):
                dmg.Types[ElemType.Kryo] += 0.5f * dmgInn;
                effect.MultipleTime(effectTimeMultiX2); 
                break;

            case (ElemType.Geo, ElemType.Kryo):
                dmg.Types[ElemType.Kryo] += 0.5f * dmgInn; 
                effect.MultipleTime(effectTimeMultiX3);
                break;

            case (ElemType.Geo, ElemType.Oxy):
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Geo):

                break;

            case (ElemType.Geo, ElemType.Aero):
                
                break;


            case (ElemType.Null, ElemType.H2O):
                dmg.Types[ElemType.Kryo] *= dmgMultiX2;
                break;

            case (ElemType.Null, ElemType.Kryo):
                dmg.Types[ElemType.Kryo] *= dmgMultiX2;
                effect = stun;
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Null, ElemType.Geo):
                dmg.Types[ElemType.Kryo] *= dmgMultiX2;

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
