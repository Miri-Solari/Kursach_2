﻿
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal interface IResistDebuffable : IAffectable
    {
        public bool IsResistDebuffable { get; set; }
        Resistances StartResist { get; set; }
        public void ResistDebuff(Dictionary<ElemType, float> resDeb)
        {
            if (IsResistDebuffable)
            {
                StartResist = Resist;
                foreach (var res in resDeb)
                {
                    if (Resist.Types.ContainsKey(res.Key))
                    {
                        Resist.Types[res.Key] = Resist.Types[res.Key] * (1 - res.Value);
                    }
                    else
                    {
                        Debug.LogWarning("Не суй что попало в резисты");
                    }
                }
            }
        }

        public void ResistDebuffEnd()
        {
            if (IsResistDebuffable)
            Resist = StartResist;
        }
    }
}
