
namespace Assets.Scripts
{
    internal interface ISlowable : IAffectable
    {
        public bool IsSlowable { get; set; }
        public float StartSpeed {  get; set; }
        public new void Slow(float sLowMulti)
        {
            if (IsSlowable)
            {
                StartSpeed = Speed;
                Speed = Speed * (1 - sLowMulti);
            }
        }

        public void SlowEnd()
        {
            if (IsSlowable)
            Speed = StartSpeed;
        }
    }
}
