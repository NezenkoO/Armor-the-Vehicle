namespace GamePlay
{
    public sealed class ProjectileContext
    {
        public float Speed { get; private set; }
        public float Damage { get; private set; }
        public float MaxAge { get; private set; }

        public ProjectileContext(float speed, float damage, float maxAge)
        {
            Speed = speed;
            Damage = damage;
            MaxAge = maxAge;
        }
    }
}
