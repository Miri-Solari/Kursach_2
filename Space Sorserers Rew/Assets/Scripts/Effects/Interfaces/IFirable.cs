namespace Assets.Scripts
{
    internal interface IFirable : IAffectable, IDamagable
    {
        public new void Fire(Damage dmg)
        {
            TakeDamage(dmg);
        }
    }
}
