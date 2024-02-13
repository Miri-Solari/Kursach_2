using System;
using System.Collections.Generic;
using UnityEngine;
public struct Resistances
{
    public Dictionary<string, float> Types;

    public Resistances(float pyro = 0, float h2o = 0, float kryo = 0, float oxy = 0, float geo = 0, float aero = 0, float mental = 0)
    {
        Types = new()
        {
            {"Pyro", pyro },
            {"H2O" , h2o },
            {"Kryo", kryo },
            {"Oxy", oxy },
            {"Geo", geo },
            {"Aero", aero },
            {"Mental", mental },
        };
    }

}