using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : BaseEffect
{
    private IStunnable _target;


    protected override void Awake()
    {
        base.Awake();
        _effectType = EffectType.Stun;
        _target = target.GetComponent<IStunnable>();
        _target.Stun();
        StartCoroutine(StunEnd());
    }

    IEnumerator StunEnd()
    {
        yield return new WaitForSeconds(_time);
        _target.StunEnd();
    }

}
