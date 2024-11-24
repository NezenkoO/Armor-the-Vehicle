using GamePlay;
using GamePlay.Enemies;
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
            Container.Bind<EnemyFactory>().FromScriptableObject(_enemyFactory).AsSingle();
        }
    }
}