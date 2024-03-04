using System.Collections;
using UnityEngine;

public class BaseEffect : MonoBehaviour
{
    [SerializeField] protected float _time;
    public EffectType _effectType { get; protected set; }
    protected GameObject target;


    protected virtual void Awake()
    {
        target = gameObject.transform.parent.gameObject;
        if (EffectCollector.Instance != null ) EffectCollector.Instance.EffectCheck(this);
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


