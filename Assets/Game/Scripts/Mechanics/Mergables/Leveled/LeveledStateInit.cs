using UnityEngine;
using Zenject;

namespace Game.Mechanics.Mergables.Leveled
{
    public class LeveledStateInit : MonoBehaviour
    {
        [SerializeField]
        private int levelToSet;
        
        private LeveledStateSystem<MergableState> _leveledStateSystem;
        [Inject]
        private void Construct(LeveledStateSystem<MergableState> leveledStateSystem)
        {
            _leveledStateSystem = leveledStateSystem;
        }
        private void Start()
        {
            _leveledStateSystem.SetState(levelToSet);
        }


    }
}