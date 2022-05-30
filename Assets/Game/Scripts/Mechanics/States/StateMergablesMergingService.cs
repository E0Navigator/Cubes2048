using Game.Mechanics.Mergables;
using Game.Mechanics.Mergables.Leveled;
using System;

namespace Game.Mechanics.States
{
    public class StateMergablesMergeData : BaseMergeData<MergableObject<LeveledMergableObject>, LeveledMergableObject, MergableObject<LeveledMergableObject>, MergeInteractionData<LeveledMergableObject>>
    {
        public StateMergablesMergeData(LeveledMergableObject mergable1, LeveledMergableObject mergable2, LeveledMergableObject result,
            MergeInteractionData<LeveledMergableObject> interactionData)
            : base(mergable1, mergable2, result, interactionData)
        {
        }
    }

    public abstract class StateMergablesMergingService : IMergingService<MergableObject<LeveledMergableObject>, LeveledMergableObject, MergableObject<LeveledMergableObject>,
        MergeInteractionData<LeveledMergableObject>>
    {
        public event EventHandler<BaseMergeData<MergableObject<LeveledMergableObject>, LeveledMergableObject, MergableObject<LeveledMergableObject>, MergeInteractionData<LeveledMergableObject>>> OnMerged;

        public abstract void ProcessState(LeveledMergableObject mergable);

        public BaseMergeData<MergableObject<LeveledMergableObject>, LeveledMergableObject, MergableObject<LeveledMergableObject>, MergeInteractionData<LeveledMergableObject>> Merge(MergableObject<LeveledMergableObject> mergable1, LeveledMergableObject mergable2, MergeInteractionData<LeveledMergableObject> interactionData)
        {
            LeveledMergableObject selfMergable = mergable1 as LeveledMergableObject;
            ProcessState(selfMergable);
            var mergeData = new StateMergablesMergeData
                (selfMergable, mergable2, selfMergable, interactionData);
            OnMerged?.Invoke(this, mergeData);
            return mergeData;
        }
    }
}