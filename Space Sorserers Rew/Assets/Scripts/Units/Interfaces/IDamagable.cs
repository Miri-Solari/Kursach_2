


using UnityEngine;
namespace Assets.Scripts
{
    internal interface IDamagable : IResistable
    {
        public float HP { get; set; }

        public void TakeDamage(Damage dmg)
        {

            HP -= dmg.DamageToHP(Resist);
        }
    }
}
