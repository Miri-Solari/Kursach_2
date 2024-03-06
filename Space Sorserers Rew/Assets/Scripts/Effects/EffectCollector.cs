using System.Linq;
using UnityEngine;

public class EffectCollector
{
    private BaseEffect[] _effects;

    // ������ ����� ��������
    public EffectCollector()
    {
        _effects = new BaseEffect[1];
    }
    public void EffectCheck(BaseEffect effect)
    {
        
       Check(effect);
    }

    private void Check(BaseEffect effect)
    {
        EffectType curr = effect._effectType;
        if (_effects[0] == null)
        {
            _effects[0] = effect;
        }
        else
        {
            for (int x = 0; x < _effects.Length; x++)
            {
                Debug.Log($"{x}     {_effects.Length} {_effects[x]}");
                if (_effects[x]._effectType == curr)
                {
                    MonoBehaviour.Destroy(_effects[x].gameObject, 0.01f);
                    _effects[x] = effect;
                }
                else
                {
                    _effects.Append(effect);
                }
            }
        }
    }
}
