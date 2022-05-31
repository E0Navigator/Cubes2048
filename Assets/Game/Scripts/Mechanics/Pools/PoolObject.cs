using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Mechanics.Pools
{
    public class PoolObject : MonoBehaviour
    {

        private Pool pool;

        public Pool Pool
        {
            get => pool;
            private set => pool=value;
        }

        public virtual void Push()
        {
            pool?.Push(this);
            Deactivate();
        }

        public virtual void Activate()
        {
            gameObject.SetActive(true);
        }

        public virtual void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public virtual void Initialize(Pool pool)
        {
            Pool = pool;
        }
    }
}