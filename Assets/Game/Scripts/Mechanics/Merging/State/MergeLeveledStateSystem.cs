using System.Collections.Generic;
using UnityEngine;

namespace Game.Mechanics.Merging.State
{
    public class MergeLeveledStateSystem : LeveledStateSystem<MergableState>
    {
        [SerializeField]
        private Renderer _renderer;

        
        public MergeLeveledStateSystem(Renderer renderer, IEnumerable<MergableState> stateCollection) : base(stateCollection)
        {
            _renderer = renderer;
        }

        public override void SetState(MergableState state)
        {
            _renderer.material = state.Material;
        }
    }
}
