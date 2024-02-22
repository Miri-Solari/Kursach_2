namespace Assets.Scripts
{
    internal interface IFirable : IAffectable, IDamagable
    {
        public bool IsFirable {  get; set; }
        public new void Fire(Damage dmg)
        {
            if (IsFirable)
            TakeDamage(dmg);
        }
    }
}
