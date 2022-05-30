using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game.Mechanics.Pools
{
    public class Pool : MonoBehaviour
    {
        [SerializeField]
        private List<PoolObject> originalObjects;
        [SerializeField]
        private int capacity;
        [SerializeField]
        private GameObject container;

        private Queue<PoolObject> objectQueue = new Queue<PoolObject>();

        public Queue<PoolObject> ObjectQueue 
        { 
            get => objectQueue; 
            set => objectQueue = value; 
        }
        public DiContainer Container { get; private set; }

        protected void Initialize()
        {
            for (int i = 0; i < capacity; i++)
            {
                CreatePoolObject();
            }
        }

        public void  Push(PoolObject poolObject)
        {
            poolObject.transform.SetParent(container.transform);
            ObjectQueue.Enqueue(poolObject);


        }
        public PoolObject Pull()
        {
            if (ObjectQueue.Count == 0)
            {
                CreatePoolObject();
            }
            PoolObject objectToReturn = ObjectQueue.Dequeue();
            objectToReturn.Activate();
            return objectToReturn;

        }
        private void CreatePoolObject()
        {
            int randomIndex = Random.Range(0, originalObjects.Count);
            PoolObject randomObjectToSpawn = originalObjects[randomIndex];
            PoolObject spawned = Container.InstantiatePrefabForComponent<PoolObject>(randomObjectToSpawn, container.transform);
            spawned.Initialize(this);
            spawned.Push();
        }

        private void Awake()
        {
            Initialize();
            
        }

        [Inject]
        public void Construct(DiContainer container)
        {
            Container = container;
        }
    }
}

