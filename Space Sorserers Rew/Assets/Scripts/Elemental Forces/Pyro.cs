using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyro : BaseElem
{

    private void Awake()
    {
        _elemName = ElemType.Pyro;
    }

    public override (Damage, BaseEffect) InnLayer(ElemType midLayer, ElemType outLayer) // ������, ����� ���������� ����
    {
        Damage dmg = new(pyro:0);
        dmg.Types[_elemName] += DmgInn;
        switch ((outLayer, midLayer))
        {
            case (ElemType.Pyro, ElemType.Pyro):
                Effect.MultipleTime(EffectTimeMultiX3);
                dmg.Types[ElemType.Pyro] *= DmgMultiX3;
                break;

            case (ElemType.Pyro, ElemType.Oxy):
                Effect.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.Pyro, ElemType.Geo):
                Effect.MultipleTime(EffectTimeMultiX3);
                break;

            case (ElemType.Pyro, ElemType.Aero):
                Effect.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Pyro):
                Effect.MultipleTime(EffectTimeMultiX2);
                dmg.Types[ElemType.Pure] = DmgMultiX3*DmgOut;
                break;

            case (ElemType.Geo, ElemType.Oxy):
                Effect.MultipleTime(EffectTimeMultiX2);
                break;

            case (ElemType.Geo, ElemType.Geo):

                break;

            case (ElemType.Geo, ElemType.Aero):
                Effect.MultipleTime(EffectTimeMultiX2);
                break;
        }
        return (dmg, Effect);
    }

    
}
