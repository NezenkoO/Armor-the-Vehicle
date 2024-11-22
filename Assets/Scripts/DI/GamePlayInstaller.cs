using GamePlay;
using GamePlay.Enemy;
using UnityEngine;
using Zenject;

namespace GamePlay
{
    public class GamePlayInstaller : MonoInstaller
    {
        [SerializeField] private ZombieViewContent zombieViewContent;
        [SerializeField] private EnemyFactory _enemyFactory;

        public override void InstallBindings()
        {
            Container.Bind<ZombieViewContent>().FromScriptableObject(zombieViewContent).AsSingle();
            Container.QueueForInject(_enemyFactory);
        }
    }
}