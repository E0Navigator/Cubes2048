
using Game.Mechanics.Interactions;
using Game.Mechanics.Mergables.Leveled;
using Game.Mechanics.States;
using Mechanics.ObjectsLaunch;
using UnityEngine;
using Zenject;

namespace Game.Mechanics.Mergables
{
    public class MergablesInstaller : MonoInstaller<MergablesInstaller>
    {
        [SerializeField]
        private ScriptableMergableStatesArray mergableStatesInstance;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<IInteractionHandler<LeveledMergableObject, MergeInteractionData<LeveledMergableObject>>>().FromComponentInChildren();
            Container.BindInterfacesAndSelfTo<IncreaseStateMergingService>().AsSingle();
            Container.Bind<Renderer>().FromComponentInChildren();
            Container.Bind<Rigidbody>().FromComponentSibling();
            Container.BindInterfacesAndSelfTo<ScriptableMergableStatesArray>().FromInstance(mergableStatesInstance);
            Container.Bind<LeveledStateSystem<MergableState>>().FromComponentSibling();
        }
    }

   
}
