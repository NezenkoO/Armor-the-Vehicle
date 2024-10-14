public sealed class EnemyContext
{
    public float Scale { get; private set; }
    public float Speed { get; private set; }
    public float RotationSpeed { get; private set; }
    public float Health { get; private set; }
    public int Damage { get; private set; }

    public EnemyContext(float scale, float speed, float rotationSpeed, float health, int damage)
    {
        Scale = scale;
        Speed = speed;
        RotationSpeed = rotationSpeed;
        Health = health;
        Damage = damage;
    }
}
