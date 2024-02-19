namespace Assets.Scripts
{
    internal interface IDisarmable : IAffectable
    {
        public new void Disarm()
        {
            CanAttack = false;
        }

        public void DisarmEnd()
        {
            CanAttack = true;
        }
    }
}
