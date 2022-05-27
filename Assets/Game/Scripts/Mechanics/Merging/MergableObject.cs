using UnityEngine;
using Zenject;

namespace Game.Mechanics.Merging
{
    public abstract class MergableObject<TMergable> : MonoBehaviour, IMergable<TMergable>
    {
        public IInteractionHandler<TMergable> InteractionHandler { get; private set; }
        public IMergingService<MergableObject<TMergable>, TMergable, MergableObject<TMergable>> MergingService { get; private set; }

        [Inject]
        public void Construct(IInteractionHandler<TMergable> interactionHandler, IMergingService<MergableObject<TMergable>, TMergable, MergableObject<TMergable>> mergingService)
        {
            InteractionHandler = interactionHandler;
            MergingService = mergingService;
            InteractionHandler.OnHandle += InteractionHandler_OnHandle;
        }

        private void InteractionHandler_OnHandle(TMergable obj)
        {
            if (CanMerge(obj))
            {
                MergingService.Merge(this, obj);
            }
        }

        public abstract bool CanMerge(TMergable mergable);
    }
}