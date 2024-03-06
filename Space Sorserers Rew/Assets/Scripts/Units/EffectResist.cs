using System;
using System.Collections.Generic;

public struct EffectResist
{
    public Dictionary<EffectType, float> res;
    public EffectResist(float fire = 0, float froze = 0, float disarm = 0, float ResDeb = 0, float slow = 0, float stun = 0, float wet = 0)
    {
        res = new Dictionary<EffectType, float>()
        {
            {EffectType.Fire, fire },
            {EffectType.Froze, froze },
            {EffectType.Disarm, disarm },
            {EffectType.ResDeb, ResDeb },
            {EffectType.Slow, slow },
            {EffectType.Stun, stun },
            {EffectType.Wet, wet },
        };

    }

    public static EffectResist operator +(EffectResist x, EffectResist y)
    {
        EffectResist result = new EffectResist(fire:0);
        foreach(EffectType item in Enum.GetValues(typeof(EffectType)))
        {
            result.res[item] = x.res[item] + y.res[item];
        }
        return result;
    }
}