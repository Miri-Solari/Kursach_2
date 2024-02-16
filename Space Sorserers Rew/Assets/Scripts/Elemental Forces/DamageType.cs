using System.Collections.Generic;

public struct Damage
{
    public Dictionary<ElemType, float> Types;

    public Damage(float pyro = 0, float h2o = 0, float kryo = 0, float oxy = 0, float geo = 0, float aero = 0, float mental = 0)
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
        };
    }

    public float DamageToHP(Resistances resistances)
    {
        float s = 0;
        foreach (var res in resistances.Types)
        {
            s += Types[res.Key] * (1 - res.Value);
        }
        return s;
    }

}