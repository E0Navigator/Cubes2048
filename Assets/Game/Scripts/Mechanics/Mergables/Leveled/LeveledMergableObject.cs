using Game.Mechanics.Pools;
using Zenject;

namespace Game.Mechanics.Mergables.Leveled
{

    public class LeveledMergableObject : MergableObject<LeveledMergableObject>
    {
        public LeveledStateSystem<MergableState> StateSystem { get; private set; }
        public PoolObject PoolObject { get; private set; }

        public override bool CanMerge(LeveledMergableObject mergable)
        {
            return StateSystem.StateId == mergable.StateSystem.StateId && mergable.Rigidbody.velocity.magnitude > Rigidbody.velocity.magnitude;
        }

        [Inject]
        public void Construct(LeveledStateSystem<MergableState> stateSystem, PoolObject poolObject)
        {
            StateSystem = stateSystem;
            PoolObject = poolObject;
        }

    }
}