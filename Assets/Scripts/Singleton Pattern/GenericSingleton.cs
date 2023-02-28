using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Singleton_Pattern
{
    public class GenericSingleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;
        public  static T Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));

                    if (instance == null) SetUpInstance();
                }

                return instance;
            }
        }

        public virtual void Awake()
        {
            RemoveDuplicates();
        }

        private static void SetUpInstance()
        {
            instance = (T)FindObjectOfType(typeof(T));

            if(instance == null)
            {
                GameObject obj = new GameObject();
                obj.name = typeof(T).Name;
                instance = obj.AddComponent<T>();
                DontDestroyOnLoad(obj);
            }
        }

        private void RemoveDuplicates()
        {
            if (instance == null)
            {
                instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else Destroy(gameObject);
        }
    }
}