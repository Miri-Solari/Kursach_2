using System.Collections;
using UnityEngine;

public class BaseEffect : MonoBehaviour
{
    [SerializeField] protected float _time;
    protected EffectType _effectType;
    protected GameObject target;

    protected virtual void Awake()
    {
        target = gameObject.transform.parent.gameObject;
        EffectCollector.EffectCheck();
        StartCoroutine(LifeTime());
    }

     protected IEnumerator LifeTime()
    {
        yield return new WaitForSeconds(_time+0.1f);
        Destroy(gameObject);
    }

    public void MultipleTime(float y)
    {
        _time *= y;
    }
}