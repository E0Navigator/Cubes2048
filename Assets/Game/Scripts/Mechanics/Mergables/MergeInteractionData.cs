using Game.Mechanics.Interactions;

namespace Game.Mechanics.Mergables
{
    public class MergeInteractionData<TMergable> : BaseInteractionData<TMergable>
    {
        public MergeInteractionData(TMergable interactable, float power) : base(interactable)
        {
            Power = power;
        }

        public float Power { get; }
    }
}