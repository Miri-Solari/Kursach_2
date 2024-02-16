using System.Collections.Generic;

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
                s += Types[res.Key] * (1 - res.Value);
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
        if (x.Types[ElemType.Pure] == 0)
        {
            foreach (var dmg in x.Types)
            {
                x.Types[dmg.Key] += y.Types[dmg.Key];
            }
        }
        else
        {
            foreach (var dmg in x.Types)
            {
                if (dmg.Key != ElemType.Pure)
                x.Types[dmg.Key] = 0;
            }
        }
        return x;
        
    }

    public static Damage operator *(Damage x, float y)
    {
        foreach (var dmg in x.Types)
        {
            x.Types[dmg.Key] *= y;
        }
        return x;
    }

}