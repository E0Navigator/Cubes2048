using System;

namespace Game.Mechanics.Merging
{
    public interface IInteractionHandler<TInteractable>
    {
        public event Action<TInteractable> OnHandle;

    }
}