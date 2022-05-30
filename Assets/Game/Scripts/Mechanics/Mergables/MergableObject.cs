using Game.Mechanics.Interactions;
using UnityEngine;
using Zenject;

namespace Game.Mechanics.Mergables
{
    public abstract class MergableObject<TMergable> : MonoBehaviour, IMergable<TMergable>
    {
        public Rigidbody Rigidbody { get; private set; }
        public IInteractionHandler<TMergable, MergeInteractionData<TMergable>> InteractionHandler { get; private set; }
        public IMergingService<MergableObject<TMergable>, TMergable, MergableObject<TMergable>, MergeInteractionData<TMergable>> MergingService { get; private set; }

        [Inject]
        public void Construct(IInteractionHandler<TMergable, MergeInteractionData<TMergable>> interactionHandler,
            IMergingService<MergableObject<TMergable>, TMergable, MergableObject<TMergable>, MergeInteractionData<TMergable>> mergingService,
            Rigidbody rigidbody)
        {
            Rigidbody = rigidbody;
            InteractionHandler = interactionHandler;
            MergingService = mergingService;
            InteractionHandler.OnHandle += InteractionHandler_OnHandle;
        }

        private void InteractionHandler_OnHandle(object sender, MergeInteractionData<TMergable> e)
        {
            if (CanMerge(e.Interactable))
            {
                MergingService.Merge(this, e.Interactable, e);
            }
        }

        public abstract bool CanMerge(TMergable mergable);
    }
}