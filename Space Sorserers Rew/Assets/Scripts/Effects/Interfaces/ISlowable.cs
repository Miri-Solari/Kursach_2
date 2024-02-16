
namespace Assets.Scripts
{
    internal interface ISlowable : IAffectable
    {
        public float StartSpeed {  get; set; }
        public new void Slow(float sLowMulti)
        {
            StartSpeed = Speed;
            Speed = Speed * (1 - sLowMulti);  
        }

        public void SlowEnd()
        {
            Speed = StartSpeed;
        }
    }
}
