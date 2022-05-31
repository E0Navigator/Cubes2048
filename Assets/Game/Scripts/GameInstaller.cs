using Game.Mechanics.Mergables;
using Game.Mechanics.Pools;
using Game.Mechanics.ObjectsLaunch;
using UnityEngine;
using Zenject;
using Game.Mechanics.Scores;

namespace Game
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField]
        private PoolManager poolManager;

        [SerializeField]
        private LaunchObjectsSystem objectsLauncher;
        [SerializeField]
        private LaunchObjectsSpawn launchObjectsSpawn;
        [SerializeField]
        private ScoreSystem scoreSystem;

        public override void InstallBindings()
        {
            Container.Bind<PoolManager>().FromInstance(poolManager);
            Container.Bind<LaunchObjectsSystem>().FromInstance(objectsLauncher);
            Container.Bind<LaunchObjectsSpawn>().FromInstance(launchObjectsSpawn);
            Container.Bind<ScoreSystem>().FromInstance(scoreSystem);
        }
    }
}