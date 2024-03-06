using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxy : BaseElem
{
    [SerializeField] ResistDebuff _resistDebuff;
    [SerializeField] float _resistDurationMultiX2;
    private void Awake()
    {
        _elemName = ElemType.Oxy;
    }

    public override (Damage, BaseEffect) InnLayer(ElemType midLayer, ElemType outLayer) // логика, когда внутренний слой
    {
        Damage dmg = new(pyro: 0);
        dmg.Types[_elemName] += dmgInn;
        
        switch ((outLayer, midLayer))
        {
            case (ElemType.Pyro, ElemType.Pyro):

                break;

            case (ElemType.Pyro, ElemType.Oxy):
                _resistDebuff.ResistDurationMulti(_resistDurationMultiX2);
                _resistDebuff.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Pyro, ElemType.Geo):
                dmg.Types[ElemType.Geo] += 0.5f * dmgInn; 
                break;

            case (ElemType.Pyro, ElemType.Aero):
                
                break;

            case (ElemType.Geo, ElemType.Pyro):
                
                break;

            case (ElemType.Geo, ElemType.Oxy):
                _resistDebuff.MultipleTime(effectTimeMultiX2);
                _resistDebuff.ResistDurationMulti(_resistDurationMultiX2);
                break;

            case (ElemType.Geo, ElemType.Geo):

                break;

            case (ElemType.Geo, ElemType.Aero):
                
                break; 

            case (ElemType.H2O, ElemType.H2O):
                _resistDebuff.MultipleTime(effectTimeMultiX2);
                dmg.Types[ElemType.Oxy] += 0.5f * dmgInn;
                break;

            case (ElemType.H2O, ElemType.Kryo):
                dmg.Types[ElemType.Kryo] += 0.5f * dmgInn; 
                break;

            case (ElemType.H2O, ElemType.Oxy):
                _resistDebuff.MultipleTime(effectTimeMultiX2);
                _resistDebuff.ResistDurationMulti(_resistDurationMultiX2);
                break;

            case (ElemType.H2O, ElemType.Geo):
                
                break;

            case (ElemType.H2O, ElemType.Aero):
                dmg.Types[ElemType.Aero] += 0.5f * dmgInn;
                break;

            case (ElemType.Kryo, ElemType.H2O):
                dmg.Types[ElemType.Kryo] += dmgInn;
                break;

            case (ElemType.Kryo, ElemType.Kryo):

                break;

            case (ElemType.Kryo, ElemType.Oxy):
                _resistDebuff.MultipleTime(effectTimeMultiX2);
                _resistDebuff.ResistDurationMulti(_resistDurationMultiX2);
                break;

            case (ElemType.Kryo, ElemType.Geo):
                
                break;

            case (ElemType.Kryo, ElemType.Aero):
                
                break;

            case (ElemType.Geo, ElemType.H2O):

                break;

            case (ElemType.Geo, ElemType.Kryo):

                break;

            case (ElemType.Null, ElemType.Pyro):
                dmg.Types[ElemType.Oxy] *= dmgMultiX2;
                break;

            case (ElemType.Null, ElemType.H2O):
                dmg.Types[ElemType.Oxy] *= dmgMultiX2;
                effect.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Null, ElemType.Kryo):
                dmg.Types[ElemType.Oxy] *= dmgMultiX2;
                break;

            case (ElemType.Null, ElemType.Geo):
                dmg.Types[ElemType.Oxy] *= dmgMultiX2;
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
        effect = _resistDebuff;
        return (dmg, effect);
    }

    
}
