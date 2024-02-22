namespace Assets.Scripts
{
    internal interface IStunnable : IAffectable
    {
        public bool IsStunnable { get; set; }
        public new void Stun()
        {
            if (IsStunnable)
            {
                CanAttack = false;
                CanMove = false;
            }
        }

        public void StunEnd()
        {
            if (!IsStunnable)
            {
                CanAttack = true;
                CanMove = true;
            }
        }
    }
}
