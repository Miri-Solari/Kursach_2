using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class BaseEnemy : MonoBehaviour // восприятие эффектов и получение урона в лицо
{
    public bool CanAttack { private set; get; } = true;
    public bool CanMove { private set; get; } = true;
    public float speed = 1f;
    [Serializable]
    public struct Res
    {
        public string name;
        public float value;
    }
    [SerializeField] Res[] _resistanceArray;
    protected Resistances _resistances;
    [SerializeField] protected float HP = 100;

    private void Awake()
    {
        foreach (var res in _resistanceArray)
        {
            _resistances.Types[res.name] = res.value;
        }
    }

    public void TakeDamage(Damage dmg)
    {
        HP -= dmg.DamageToHP(_resistances);
    }

    
}
