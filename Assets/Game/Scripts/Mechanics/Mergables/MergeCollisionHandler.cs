using Game.Mechanics.Interactions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Mechanics.Mergables
{

    public class MergeCollisionHandler<TMergable> : CollisionHandler<TMergable, MergeInteractionData<TMergable>>
    {
        [SerializeField]
        private float minImpulseToHandle = 2;

        public override MergeInteractionData<TMergable> CreateInteractionData(Collision collision, TMergable handled)
        {
            return new MergeInteractionData<TMergable>(handled, collision.impulse.magnitude);
        }

        protected override void Handle(Collision collision, TMergable handled)
        {
            float impulse = collision.impulse.magnitude;
            if (impulse > minImpulseToHandle)
            {
                base.Handle(collision, handled);
            }
        }
    }
}