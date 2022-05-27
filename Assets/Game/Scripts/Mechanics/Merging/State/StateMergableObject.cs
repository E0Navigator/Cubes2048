namespace Game.Mechanics.Merging.State
{

    public class StateMergableObject : MergableObject<StateMergableObject>
    {
        public object State { get; set; }

        public override bool CanMerge(StateMergableObject mergable)
        {
            return State == mergable.State;
        }
    }
}