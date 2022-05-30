using UnityEngine;

namespace Game.Mechanics.States
{
    [System.Serializable]
    public class MergableState
    {
        [SerializeField]
        private Material material;

        public Material Material { get => material; }
    }
}
