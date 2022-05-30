using Game.Mechanics.States;

namespace Game.Mechanics.Mergables.Leveled
{
    public class IncreaseStateMergingService : StateMergablesMergingService
    {
        public override void ProcessState(LeveledMergableObject mergable)
        {
            mergable.StateSystem.LevelUpState();
        }
    }
}