using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal interface IWetable : ISlowable, IResistDebuffable
    {
        public bool IsWetable { get; set; }
        public void Wet(float sLowMulti, Dictionary<ElemType, float> resDeb)
        {
            if (IsWetable)
            {
                Slow(sLowMulti);
                ResistDebuff(resDeb);
            }
        }

        public void WetEnd()
        {
            if (IsWetable)
            {
                SlowEnd();
                ResistDebuffEnd();
            }
        }
    }
}
