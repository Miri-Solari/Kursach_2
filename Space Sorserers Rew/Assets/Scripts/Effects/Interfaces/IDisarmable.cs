namespace Assets.Scripts
{
    internal interface IDisarmable : IAffectable
    {
        public bool IsDisarmable {  get; set; }
        public new void Disarm()
        {
            if (IsDisarmable)
            CanAttack = false;
        }

        public void DisarmEnd()
        {
            if (IsDisarmable)
            CanAttack = true;
        }
    }
}
