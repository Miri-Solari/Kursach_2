namespace Assets.Scripts
{
    internal interface IStunable : IAffectable
    {
        public new void Stun()
        {
            CanAttack = false;
            CanMove = false;
        }

        public void StunEnd()
        {
            CanAttack = true;
            CanMove = true;
        }
    }
}
