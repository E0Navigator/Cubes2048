using UnityEngine;

namespace Game.Mechanics.Mergables
{
    [System.Serializable]
    public class MergableState
    {
        [SerializeField]
        private Material material;
        [SerializeField]
        private int level;

        public Material Material { get => material; }
        public int Level { get => level;}
    }
}
