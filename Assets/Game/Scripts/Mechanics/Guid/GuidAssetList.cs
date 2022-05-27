using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Mechanics.Guid;

namespace Game.Mechanics.Guid
{
    [System.Serializable]
    public class GuidAssetList
    {
        [SerializeField]
        private List<GuidAsset> guidAssets;
        private HashSet<GuidAsset> guidSet;
        public List<GuidAsset> GuidAssets
        {
            get
            {
                return guidAssets;
            }
        }

        public HashSet<GuidAsset> GuidSet { get => (guidSet == null) ? guidSet = CreateHashSet() : guidSet; }
        private HashSet<GuidAsset> CreateHashSet()
        {
            HashSet<GuidAsset> guidHash = new HashSet<GuidAsset>(guidAssets);


            return guidHash;
        }

        public bool IsSubsetOf(GuidAssetList compareTo)
        {
            return GuidSet.IsSubsetOf(compareTo.GuidSet);
        }

    }
}