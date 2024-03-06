using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geo : BaseElem
{
    [SerializeField] private Slow _slow;
    [SerializeField] private float _slowDurationMultiWet;
    [SerializeField] private float _slowDurationMultiX2;
    [SerializeField] private float _slowDurationMultiX3;
    private void Awake()
    {
        _elemName = ElemType.Geo;
    }

    public override (Damage, BaseEffect) InnLayer(ElemType midLayer, ElemType outLayer) // логика, когда внутренний слой
    {
        Damage dmg = new(pyro:0);
        dmg.Types[_elemName] += dmgInn;

        switch ((outLayer, midLayer))
        {
            case (ElemType.Pyro, ElemType.Pyro):
                dmg.Types[ElemType.Pure] = (dmgMid + dmgOut) * dmgMultiX3;
                _slow.MultipleTime(0f);
                break;

            case (ElemType.Pyro, ElemType.Oxy):

                break;

            case (ElemType.Pyro, ElemType.Geo):
                _slow.SlowDurationMulti(_slowDurationMultiX2);
                break;

            case (ElemType.Pyro, ElemType.Aero):

                break;

            case (ElemType.Geo, ElemType.Pyro):
                _slow.MultipleTime(0f);
                dmg.Types[ElemType.Pyro] += dmgInn;
                break;

            case (ElemType.Geo, ElemType.Oxy):

                break; 

            case (ElemType.Geo, ElemType.Geo):
                dmg.Types[ElemType.Geo] += dmgInn;
                _slow.SlowDurationMulti(_slowDurationMultiX3);
                _slow.MultipleTime(effectTimeMultiX3);
                break;

            case (ElemType.Geo, ElemType.Aero):
                _slow.MultipleTime(effectTimeMultiX2); 
                break;

            case (ElemType.H2O, ElemType.H2O):
                _slow.MultipleTime(effectTimeMultiX3);
                _slow.SlowDurationMulti(_slowDurationMultiWet);
                break;

            case (ElemType.H2O, ElemType.Kryo):
                dmg.Types[ElemType.Kryo] += 0.5f * dmgInn;
                _slow.MultipleTime(effectTimeMultiX2);
                _slow.SlowDurationMulti(_slowDurationMultiWet);
                break;

            case (ElemType.H2O, ElemType.Oxy):

                break;

            case (ElemType.H2O, ElemType.Geo): 
                _slow.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.H2O, ElemType.Aero):
                dmg.Types[ElemType.Aero] += 0.5f * dmgInn; 
                break;

            case (ElemType.Kryo, ElemType.H2O):
                dmg.Types[ElemType.Kryo] += dmgInn; 
                break;

            case (ElemType.Kryo, ElemType.Kryo):
                _slow.SlowDurationMulti(_slowDurationMultiX2);
                break;

            case (ElemType.Kryo, ElemType.Oxy):
                _slow.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Kryo, ElemType.Geo):
                _slow.SlowDurationMulti(_slowDurationMultiX3);
                _slow.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Kryo, ElemType.Aero):

                break;

            case (ElemType.Geo, ElemType.H2O):
                _slow.MultipleTime(effectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Kryo):
                _slow.MultipleTime(effectTimeMultiX2); 
                break;

            case (ElemType.Null, ElemType.Pyro):
                dmg.Types[ElemType.Pure] = dmgMid * dmgMultiX3 - dmgInn;
                break;

            case (ElemType.Null, ElemType.H2O):
                dmg.Types[ElemType.Geo] *= dmgMultiX2;
                break;

            case (ElemType.Null, ElemType.Kryo):
                dmg.Types[ElemType.Pure] = dmgMid * dmgMultiX2;
                effect = stun;
                break;

            case (ElemType.Null, ElemType.Geo):
                dmg.Types[ElemType.Geo] *= dmgMultiX2;
                effect = stun;
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
        effect = _slow;
        return (dmg, effect);
    }

    
}
