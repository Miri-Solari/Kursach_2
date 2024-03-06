using System.Collections;
using UnityEngine;

public class BaseEffect : MonoBehaviour
{
    [SerializeField, Range(1, 10)] protected float _time;
    public EffectType _effectType { get; protected set; }
    protected GameObject target;
    private float _baseTime = 0;


    protected virtual void Awake()
    {
        _baseTime = _time;
        target = gameObject.transform.parent.gameObject;
        EffectCollector collector = target.GetComponent<BaseUnit>().GetEffectCollector();
        if (collector != null ) collector.EffectCheck(this);
        IEffectResistible temp = target.GetComponent<IEffectResistible>();
        if (temp!= null)
        {
            _time *= temp.Resist.res[_effectType]/100f;
        }
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