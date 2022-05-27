
namespace Game.Mechanics.Merging.State
{
    public abstract class StateMergablesMergingService : IMergingService<StateMergableObject, StateMergableObject, StateMergableObject>
    {
        public StateMergableObject Merge(StateMergableObject mergable1, StateMergableObject mergable2)
        {
            ProcessState(mergable1);
            return mergable1;
        }

        public abstract void ProcessState(StateMergableObject mergable);
    }
}