using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ObjectPooling
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private uint initPoolSize;
        [SerializeField] private PooledObject objectToPool;

        // store the pooled objects in a collection.

        private Stack<PooledObject> stack;

        private void Start()
        {
            SetUpPool();
        }

        // creates the pool (invoke when the lag is not noticeable)
        private void SetUpPool()
        {
            stack = new Stack<PooledObject>();
            PooledObject instance = null;

            for(int i = 0; i < initPoolSize; i++)
            {
                instance = Instantiate(objectToPool);
                instance.Pool = this;
                instance.gameObject.SetActive(false);
                stack.Push(instance);
            }
        }

        // Returns the first active GameObject from the pool
        public PooledObject GetPooledObject()
        {
            // if the pool is not large enough, instantiate new PooledObjects

            if(stack.Count == 0)
            {
                PooledObject newInstance = Instantiate(objectToPool);
                newInstance.Pool = this;
                return newInstance;
            }

            // otherwise, just grdab the next one from the list
            PooledObject nextInstance = stack.Pop();
            nextInstance.gameObject.SetActive(true);

            return nextInstance;
        }

        internal void ReturnToPool(PooledObject pooledObject)
        {
            stack.Push(pooledObject);
            pooledObject.gameObject.SetActive(false);
        }

    }
}
