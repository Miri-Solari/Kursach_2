using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow : BaseEffect
{
    [SerializeField] private float slowDuration;
    private ISlowable _target;


    protected override void Awake()
    {
        base.Awake();
        _effectType = EffectType.Slow;
        _target = target.GetComponent<ISlowable>();
        _target.Slow(slowDuration);
        StartCoroutine(SlowEnd());
    }


    private IEnumerator SlowEnd()
    {
        yield return new WaitForSeconds(_time);
        _target.SlowEnd();
    }

}
