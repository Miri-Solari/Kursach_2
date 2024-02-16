using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : BaseEffect
{
    [SerializeField] private float dmg;
    private IFirable _target;
    private Damage _giving;
    protected override void Awake()
    {
        base.Awake();
        _effectType = EffectType.Fire;
        _target = target.GetComponent<IFirable>();
        _giving = new Damage(pyro: dmg);
        if (_target != null)
        {
            InvokeRepeating(nameof(Firing), 0, 1f);
        }
        else Destroy(gameObject);
    }

    private void Firing()
    {
        _target.TakeDamage(_giving);
    }
}
