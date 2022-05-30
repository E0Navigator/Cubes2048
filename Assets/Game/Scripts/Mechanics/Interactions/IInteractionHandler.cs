using System;

namespace Game.Mechanics.Interactions
{
    public class BaseInteractionData<TInteractable>
    {
        public BaseInteractionData(TInteractable interactable)
        {
            Interactable = interactable;
        }

        public TInteractable Interactable { get; private set; }
    }
    public interface IInteractionHandler<TInteractable, TInteractionData>
        where TInteractionData : BaseInteractionData<TInteractable>
    {
        public event EventHandler<TInteractionData> OnHandle;

    }
}