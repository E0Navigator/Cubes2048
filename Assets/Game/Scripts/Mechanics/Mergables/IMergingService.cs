
using Game.Mechanics.Interactions;
using System;

namespace Game.Mechanics.Mergables
{
    public class BaseMergeData<TMergable1, TMergable2, TResult, TInteractionData>
    {
        public BaseMergeData(TMergable1 mergable1, TMergable2 mergable2, TResult result, TInteractionData interactionData)
        {
            Mergable1 = mergable1;
            Mergable2 = mergable2;
            Result = result;
            InteractionData = interactionData;
        }

        public TMergable1 Mergable1 { get; }
        public TMergable2 Mergable2 { get; }
        public TResult Result { get; }
        public TInteractionData InteractionData { get; }
    }

    public interface IMergingService<TMergable1, TMergable2, TResult, TInteractionData>
        where TMergable1 : IMergable<TMergable2>
        where TInteractionData : BaseInteractionData<TMergable2>
    {
        public event EventHandler<BaseMergeData<TMergable1, TMergable2, TResult, TInteractionData>> OnMerged;
        public BaseMergeData<TMergable1, TMergable2, TResult, TInteractionData> Merge(TMergable1 mergable1, TMergable2 mergable2, TInteractionData interactionData);

        
    }
}