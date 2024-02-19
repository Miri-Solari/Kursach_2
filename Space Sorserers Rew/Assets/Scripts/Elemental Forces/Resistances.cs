using System;
using System.Collections.Generic;
using UnityEngine;
public struct Resistances
{
    public Dictionary<ElemType, float> Types;

    public Resistances(float pyro = 0, float h2o = 0, float kryo = 0, float oxy = 0, float geo = 0, float aero = 0, float mental = 0)
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

    public static Resistances operator *(Resistances x, float y)
    {
        Resistances result = new(pyro:0) ;
        foreach(var dmg in x.Types)
        {
            result.Types[dmg.Key] = x.Types[dmg.Key] * y;
        }
        return result;
    }

}