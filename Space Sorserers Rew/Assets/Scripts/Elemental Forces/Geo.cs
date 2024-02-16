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
        Damage dmg = new();
        dmg.Types[_elemName] += DmgInn;

        switch ((outLayer, midLayer))
        {
            case (ElemType.Pyro, ElemType.Pyro):
                dmg.Types[ElemType.Pure] = (DmgMid + DmgOut) * DmgMultiX3;
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
                dmg.Types[ElemType.Pyro] += DmgInn;
                break;

            case (ElemType.Geo, ElemType.Oxy):

                break; 

            case (ElemType.Geo, ElemType.Geo):
                dmg.Types[ElemType.Geo] += DmgInn;
                _slow.SlowDurationMulti(_slowDurationMultiX3);
                _slow.MultipleTime(EffectTimeMultiX3);
                break;

            case (ElemType.Geo, ElemType.Aero):
                _slow.MultipleTime(EffectTimeMultiX2); 
                break;

            case (ElemType.H2O, ElemType.H2O):
                _slow.MultipleTime(EffectTimeMultiX3);
                _slow.SlowDurationMulti(_slowDurationMultiWet);
                break;

            case (ElemType.H2O, ElemType.Kryo):
                dmg.Types[ElemType.Kryo] += 0.5f * DmgInn;
                _slow.MultipleTime(EffectTimeMultiX2);
                _slow.SlowDurationMulti(_slowDurationMultiWet);
                break;

            case (ElemType.H2O, ElemType.Oxy):

                break;

            case (ElemType.H2O, ElemType.Geo): 
                _slow.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.H2O, ElemType.Aero):
                dmg.Types[ElemType.Aero] += 0.5f * DmgInn; 
                break;

            case (ElemType.Kryo, ElemType.H2O):
                dmg.Types[ElemType.Kryo] += DmgInn; 
                break;

            case (ElemType.Kryo, ElemType.Kryo):
                _slow.SlowDurationMulti(_slowDurationMultiX2);
                break;

            case (ElemType.Kryo, ElemType.Oxy):
                _slow.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.Kryo, ElemType.Geo):
                _slow.SlowDurationMulti(_slowDurationMultiX3);
                _slow.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.Kryo, ElemType.Aero):

                break;

            case (ElemType.Geo, ElemType.H2O):
                _slow.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Kryo):
                _slow.MultipleTime(EffectTimeMultiX2); 
                break;

        }
        Effect = _slow;
        return (dmg, Effect);
    }

    
}
