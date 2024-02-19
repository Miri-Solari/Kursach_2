using System.Collections.Generic;

namespace Assets.Scripts
{
    internal interface IFrozable : ISlowable, IResistDebuffable
    {
        public void Froze(float sLowMulti, Dictionary<ElemType, float> resDeb)
        {
            Slow(sLowMulti);
            ResistDebuff(resDeb);
        }

        public void FrozeEnd()
        {
            SlowEnd();
            ResistDebuffEnd();
        }
    }
}
