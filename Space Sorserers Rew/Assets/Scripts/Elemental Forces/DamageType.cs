using System.Collections.Generic;
using UnityEngine;

public struct Damage
{
    public Dictionary<ElemType, float> Types;

    public Damage(float pyro = 0, float h2o = 0, float kryo = 0, float oxy = 0, float geo = 0, float aero = 0, float mental = 0, float pure = 0)
    {
        Types = new()
        {
            {ElemType.Pyro, pyro },
            {ElemType.H2O , h2o },
            {ElemType.Kryo, kryo },
            {ElemType.Oxy, oxy },
            {ElemType.Geo, geo },
            {ElemType.Aero, aero },
            {ElemType.Mental, mental },
            {ElemType.Pure, pure }
        };
    }

    public float DamageToHP(Resistances resistances)
    {
        float s = 0;
        if (Types[ElemType.Pure] == 0)
        {
            foreach (var res in resistances.Types)
            {
                s += Types[res.Key] * (1 - res.Value/100);
                
            }
            
        }
        else
        {
            s = Types[ElemType.Pure];
        }
        return s;
    }

    public static Damage operator +(Damage x, Damage y)
    {
        Damage result = new(pyro:0);
        if (x.Types[ElemType.Pure] == 0)
        {
            
            foreach (var dmg in x.Types)
            {
                result.Types[dmg.Key] = x.Types[dmg.Key] + y.Types[dmg.Key];
            }
        }
        else
        {
            foreach (var dmg in x.Types)
            {
                if (dmg.Key != ElemType.Pure)
                result.Types[dmg.Key] = 0;
            }
            result.Types[ElemType.Pure] = x.Types[ElemType.Pure];
        }
        return result;
        
    }

    public static Damage operator *(Damage x, float y)
    {
        Damage result = new(pyro: 0);
        foreach (var dmg in x.Types)
        {
            result.Types[dmg.Key] = x.Types[dmg.Key] * y;
        }
        return result;
    }

}