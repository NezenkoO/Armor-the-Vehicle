using UnityEngine;

public class EnemyObjectPoolHolder : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private EnemyType _enemyType;
    [SerializeField] private int _initialSize;

    public EnemyObjectPool Pool { get; private set; }

    private void Awake()
    {
        Pool = new EnemyObjectPool(_enemyFactory, _enemyType, _initialSize);
        Pool.Initialize();
    }
}
