using Assets.Scripts;
using UnityEngine;

public class Froze: BaseEffect
{
    [SerializeField] private float slowDuration;
    [SerializeField] private float resistDuration;
    private IFreezable _target;

    protected override void Awake()
    {
        base.Awake();
        _effectType = EffectType.Froze;
        _target = target.GetComponent<IFreezable>();
        Resistances temp = new();
        temp.Types[ElemType.Pyro] = resistDuration + 1;
        temp.Types[ElemType.Geo] = resistDuration;
        _target.Froze(slowDuration, temp.Types);
        temp.Types.Clear();
    }



}
