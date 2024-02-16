using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disarm : BaseEffect
{
    private IDisarmable _target;


    protected override void Awake()
    {
        base.Awake();
        _effectType = EffectType.Disarm;
        _target = target.GetComponent<IDisarmable>();
        _target.Disarm();
        StartCoroutine(DisarmEnd());
    }

    IEnumerator DisarmEnd()
    {
        yield return new WaitForSeconds(_time);
        _target.DisarmEnd();
    }

}
