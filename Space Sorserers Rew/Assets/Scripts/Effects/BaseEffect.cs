using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEffect : MonoBehaviour
{
    [SerializeField] private float _time;
    protected GameObject target;

    protected virtual void Awake()
    {
        target = gameObject.transform.parent.gameObject;
        EffectCollector.EffectCheck();
    }

    protected virtual void FixedUpdate()
    {
        _time -= Time.deltaTime;
        if (_time <= 0)
        {
            Destroy(gameObject);
        }
    }
}