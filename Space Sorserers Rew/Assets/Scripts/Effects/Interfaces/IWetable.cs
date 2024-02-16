using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal interface IWetable : ISlowable, IResistDebuffable
    {
        public void Wet(float sLowMulti, Dictionary<ElemType, float> resDeb)
        {
            Slow(sLowMulti);
            ResistDebuff(resDeb);
        }

        public void WetEnd()
        {
            SlowEnd();
            ResistDebuffEnd();
        }
    }
}
