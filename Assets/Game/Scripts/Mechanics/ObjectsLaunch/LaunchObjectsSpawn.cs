using Game.Mechanics.Guid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Mechanics.Pools;
using Zenject;
using System;

namespace Game.Mechanics.ObjectsLaunch
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


        public event EventHandler<Rigidbody> OnObjectSpawned;

        public void Spawn()
        {
            StartCoroutine(SpawnCoroutine());
        }
        public IEnumerator SpawnCoroutine()
        {
            yield return new WaitForSeconds(spawnDelay);
            PoolObject poolObj = _manager.GetPoolObject(poolGuid);
            poolObj.transform.position = spawnPosition.position;
            poolObj.transform.rotation = spawnPosition.rotation;
            Rigidbody toSet;
            if (poolObj.TryGetComponent<Rigidbody>(out toSet))
            {
                OnObjectSpawned?.Invoke(this,toSet);
                Debug.Log("Spawned!");
            }

        }
        [Inject]
        private void Construct(PoolManager manager)
        {
            _manager = manager;
        }
    }
}