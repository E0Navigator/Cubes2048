using UnityEngine;

namespace Game.Mechanics.Merging.State
{
    [System.Serializable]
    public class MergableState
    {
        [SerializeField]
        private Material material;

        public Material Material { get => material; }
    }
}
