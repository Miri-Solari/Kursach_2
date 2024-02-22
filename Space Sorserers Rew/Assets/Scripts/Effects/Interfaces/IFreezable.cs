using System.Collections.Generic;

namespace Assets.Scripts
{
    internal interface IFreezable : ISlowable, IResistDebuffable
    {
        public bool IsFreezable { get; set; }
        public void Froze(float sLowMulti, Dictionary<ElemType, float> resDeb)
        {
            if (IsFreezable)
            {
                Slow(sLowMulti);
                ResistDebuff(resDeb);
            }
        }

        public void FrozeEnd()
        {
            if (IsFreezable)
            {
                SlowEnd();
                ResistDebuffEnd();
            }
        }
    }
}
