using Game.Mechanics.Guid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Mechanics.Pools;
using Zenject;

namespace Mechanics.ObjectsLaunch
{
    public class LaunchObjectsSpawn : MonoBehaviour
    {
        [SerializeField]
        private Transform spawnPosition;
        [SerializeField]
        private float spawnDelay;
        [SerializeField]
        private GuidAsset poolGuid;

        private PoolManager _manager;
        private ObjectsLaunchSystem _objectsLaunch;

        private void HandleLaunch()
        {
            Spawn();
        }

        public IEnumerator Spawn()
        {
            yield return new WaitForSeconds(spawnDelay);
            PoolObject poolObj = _manager.GetPoolObject(poolGuid);
            Rigidbody toSet;
            if (poolObj.TryGetComponent<Rigidbody>(out toSet))
            {
                _objectsLaunch.CurrentRigidbody = toSet;
            }

        }
        [Inject]
        private void Construct(PoolManager manager,ObjectsLaunchSystem objectsLaunch)
        {
            _manager = manager;
            _objectsLaunch = objectsLaunch;
            _objectsLaunch.OnLaunch += HandleLaunch;

        }
    }
}