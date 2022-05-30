using Game.Mechanics.Mergables;
using Game.Mechanics.Pools;
using Mechanics.ObjectsLaunch;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameInstaller : MonoInstaller<GameInstaller>
    {
        [SerializeField]
        private PoolManager poolManager;

        [SerializeField]
        private ObjectsLaunchSystem objectsLauncher;

        public override void InstallBindings()
        {
            Container.Bind<PoolManager>().FromInstance(poolManager);
            Container.Bind<ObjectsLaunchSystem>().FromInstance(objectsLauncher);

        }
    }
}