public class EnemyObjectPool : ObjectPool<Enemy>, IEnemyReclaimer
{
    private EnemyFactory _enemyFactory;
    private EnemyType _enemyType;

    public EnemyObjectPool(EnemyFactory enemyFactory, EnemyType enemyType, int initialSize)
        : base(() => enemyFactory.Get(enemyType), initialSize)
    {
        _enemyFactory = enemyFactory;
        _enemyType = enemyType;
    }

    public override Enemy Get()
    {
        var enemy = base.Get();
        enemy.ResetEnemy();
        return enemy;
    }

    protected override Enemy AddObjectToPool()
    {
        Enemy enemy = _enemyFactory.Get(_enemyType);
        enemy.EnemyReclaimer = this;
        enemy.gameObject.SetActive(false);
        _pool.Add(enemy);
        return enemy;
    }
}