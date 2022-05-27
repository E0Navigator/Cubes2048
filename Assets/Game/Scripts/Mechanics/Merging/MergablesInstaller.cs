
using Game.Mechanics.Merging.State;
using UnityEngine;
using Zenject;

namespace Game.Mechanics.Merging 
{
    public class MergablesInstaller : Installer<MergablesInstaller>
    {
        [SerializeField]
        private ScriptableMergableStatesArray mergableStatesInstance;
        public override void InstallBindings()
        {
            Container.Bind<IInteractionHandler<StateMergableObject>>().FromComponentInChildren();
            Container.BindInterfacesAndSelfTo<IncreaseStateMergingSystem>().AsSingle();
            Container.Bind<Renderer>().FromComponentInChildren();
            Container.Bind<MergeLeveledStateSystem>().AsTransient();
            Container.Bind<ScriptableMergableStatesArray>().FromInstance(mergableStatesInstance);
        }
    }

   
}
