using UnityEngine;
using Game.Mechanics.Mergables.Leveled;
using Game.Mechanics.States;
using Game.Mechanics.Mergables;
using Zenject;

namespace Game.Mechanics.Scores
{
    public class MergeLevelScoreProvider
    {
        private ScoreSystem _scoreSystem;
        public IMergingService<MergableObject<LeveledMergableObject>, LeveledMergableObject, MergableObject<LeveledMergableObject>, MergeInteractionData<LeveledMergableObject>> MergingService { get; private set; }


        public MergeLevelScoreProvider(ScoreSystem scoreSystem,
            IMergingService<MergableObject<LeveledMergableObject>, LeveledMergableObject, MergableObject<LeveledMergableObject>, MergeInteractionData<LeveledMergableObject>> mergingService)
        {
            MergingService = mergingService;
            _scoreSystem = scoreSystem;
            MergingService.OnMerged += OnMerged;

        }

        private void OnMerged(object sender, BaseMergeData<MergableObject<LeveledMergableObject>, LeveledMergableObject, MergableObject<LeveledMergableObject>, MergeInteractionData<LeveledMergableObject>> e)
        {
            LeveledMergableObject result = e.Result as LeveledMergableObject;
            MergableState state = result.StateSystem.GetCurrentState();
            _scoreSystem.AddToScore(state.Level);
        }
    }
}