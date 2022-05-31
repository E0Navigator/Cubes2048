using Game.Mechanics.Mergables.Leveled;
using Game.Mechanics.ObjectsLaunch;
using UnityEngine;
using Zenject;
using Game.Data;
using System.Collections.Generic;
using Game.Mechanics.Interactions;
using Game.Mechanics.Scores;

namespace Game.Mechanics.Mergables
{
    public class MergablesInstaller : MonoInstaller<MergablesInstaller>
    {
        [SerializeField]
        private ScriptableMergableStatesArray mergableStatesInstance;
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<IInteractionHandler<LeveledMergableObject, MergeInteractionData<LeveledMergableObject>>>().FromComponentsInChildren();
            Container.BindInterfacesAndSelfTo<IncreaseStateMergingService>().AsSingle();
            Container.BindInterfacesAndSelfTo<IEnumerable<MergableState>>().FromInstance(mergableStatesInstance);
            Container.Bind<MergeLevelScoreProvider>().AsSingle().NonLazy();
        }
    }
}
