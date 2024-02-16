using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wet : BaseEffect
{
    [SerializeField] private float slowDuration;
    [SerializeField] private float resistDuration;
    private IWetable _target;

    protected override void Awake()
    {
        base.Awake();
        _effectType = EffectType.Wet;
        _target = target.GetComponent<IWetable>();
        Resistances temp = new();
        temp.Types[ElemType.Aero] = resistDuration;
        temp.Types[ElemType.Kryo] = resistDuration;
        _target.Wet(slowDuration, temp.Types);
        temp.Types.Clear();
        StartCoroutine(WetEnd());


        IEnumerator WetEnd()
        {
            yield return new WaitForSeconds(_time);
            _target.WetEnd();
        }
    }

}
