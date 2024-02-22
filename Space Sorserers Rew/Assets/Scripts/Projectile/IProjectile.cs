using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Projectile
{
    internal interface IProjectile
    {
        public BaseEffect ContainEffect { get; set; }
        public Damage ContainDamage { get; set; }
        
        public void EffectSet(BaseEffect effect)
        {
            ContainEffect = effect;
        }

        public void DamageSet(Damage damage)
        {
            ContainDamage = damage;
        }

        public virtual void Trigger(Collision target)
        {
            if (target.gameObject.GetComponent<BaseUnit>() != null)
            {
               
                MonoBehaviour.Instantiate(ContainEffect, target.transform);
                target.gameObject.GetComponent<IDamagable>().TakeDamage(ContainDamage);
            }
        }
    }
}
