using Game.Mechanics.Guid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Mechanics.Pools
{
    [System.Serializable]
    public class PoolInstance
    {
        [SerializeField]
        private GuidAsset guidAsset;

        [SerializeField]
        private Pool pool;

        public GuidAsset Guid 
        { 
            get => guidAsset; 
            private set => guidAsset = value; 
        }

        public Pool Pool 
        { 
            get => pool; 
            private set => pool = value; 
        }
    }

    public class PoolManager : MonoBehaviour
    {   
        [SerializeField]
        private List<PoolInstance> poolInstances;
        
        public PoolObject GetPoolObject(GuidAsset guidAsset)
        {
            PoolInstance poolInstance = poolInstances.Find(x => x.Guid == guidAsset);
            PoolObject poolObject = null;
            if (poolInstance!=null && poolInstance.Pool)
            {
                poolObject = poolInstance.Pool.Pull();
            }
            return poolObject;
        }
        public bool CheckPool(GuidAsset guidAsset)
        {
            PoolInstance poolInstance = poolInstances.Find(x => x.Guid == guidAsset);
            if (poolInstance != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
