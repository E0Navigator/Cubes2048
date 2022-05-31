using System.Collections.Generic;
using UnityEngine;

namespace Game.Mechanics.Mergables.Leveled
{
    public class MergableLeveledStateSystem : LeveledStateSystem<MergableState>
    {
        [SerializeField]
        private Renderer _renderer;

        public override void SetState(MergableState state)
        {
            _renderer.material = state.Material;
        }
    }
}
