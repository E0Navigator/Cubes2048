using System;
using UnityEngine;

namespace Game.Mechanics.Merging
{
    public abstract class CollisionHandler<TInteractable> : MonoBehaviour, IInteractionHandler<TInteractable>
    {
        public event Action<TInteractable> OnHandle;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out TInteractable handled))
            {
                Handle(collision, handled);
            }
        }

        protected virtual void Handle(Collision collision, TInteractable handled)
        {
            OnHandle?.Invoke(handled);
        }
    }
}