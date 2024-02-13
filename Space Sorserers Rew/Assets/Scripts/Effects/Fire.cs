using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : BaseEffect
{
    [SerializeField] private float dmg;
    private BaseEnemy _targetEnemy;
    private Damage _giving;
    protected override void Awake()
    {
        _targetEnemy = target.GetComponent<BaseEnemy>();
        _giving = new Damage(pyro: dmg);
        if (_targetEnemy != null)
        {
            InvokeRepeating(nameof(Firing), 0, 1f);
        }
        else Destroy(gameObject);
        base.Awake();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void Firing()
    {
        _targetEnemy.TakeDamage(_giving);
    }
}
