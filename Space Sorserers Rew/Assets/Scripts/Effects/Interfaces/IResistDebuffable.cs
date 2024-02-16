
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    internal interface IResistDebuffable : IAffectable
    {
        Resistances StartResist { get; set; }
        public new void ResistDebuff(Dictionary<ElemType, float> resDeb)
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
                    Debug.LogWarning("Не суй что попало");
                }
            }
        }

        public void ResistDebuffEnd()
        {
            Resist = StartResist;
        }
    }
}
