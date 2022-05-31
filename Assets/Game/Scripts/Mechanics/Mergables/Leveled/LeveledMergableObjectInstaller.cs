
using Game.Mechanics.Interactions;
using Game.Mechanics.Mergables.Leveled;
using UnityEngine;
using Zenject;
using Game.Mechanics.Pools;

namespace Game.Mechanics.Mergables.Leveled
{
    public class LeveledMergableObjectInstaller : MonoInstaller<LeveledMergableObjectInstaller>
    {
        [SerializeField]
        private Renderer renderer;

        [SerializeField]
        private Rigidbody rigidbody;

        [SerializeField]
        private PoolObject poolObject;

        [SerializeField]
        private MergableLeveledStateSystem stateSystem;

        public override void InstallBindings()
        {
            Container.Bind<LeveledStateSystem<MergableState>>().To<MergableLeveledStateSystem>().FromInstance(stateSystem);
            Container.Bind<Renderer>().FromInstance(renderer);
            Container.Bind<Rigidbody>().FromInstance(rigidbody);
            Container.Bind<PoolObject>().FromInstance(poolObject);
        }

        private void OnValidate()
        {
            renderer ??= GetComponentInChildren<Renderer>();
            rigidbody ??= GetComponent<Rigidbody>();
            poolObject ??= GetComponent<PoolObject>();
            stateSystem ??= GetComponent<MergableLeveledStateSystem>();
        }
    }
}
