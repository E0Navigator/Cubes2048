using System;
using UnityEngine;

namespace Game.Mechanics.Interactions
{
    public abstract class CollisionHandler<TInteractable, TInteractionData> : MonoBehaviour, IInteractionHandler<TInteractable, TInteractionData>
        where TInteractionData : BaseInteractionData<TInteractable>
    {
        public event EventHandler<TInteractionData> OnHandle;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out TInteractable handled))
            {
                Handle(collision, handled);
            }
        }

        protected virtual void Handle(Collision collision, TInteractable handled)
        {
            TInteractionData interactionData = CreateInteractionData(collision, handled);
            OnHandle?.Invoke(handled, interactionData);
        }

        public abstract TInteractionData CreateInteractionData(Collision collision, TInteractable handled);
    }
}