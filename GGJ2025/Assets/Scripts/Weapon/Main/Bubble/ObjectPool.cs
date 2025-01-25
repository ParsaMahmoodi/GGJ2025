using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Weapon.Main.Bubble
{
    public class ObjectPool
    {
        private readonly GameObject _prefab;
        private readonly List<GameObject> _pool;
        private Transform _poolParent;

        public ObjectPool(GameObject prefab, int initialSize)
        {
            _prefab = prefab;
            _pool = new List<GameObject>(initialSize);
            CreateParent();
            
            for (var i = 0; i < initialSize; i++)
            {
                Instantiate();
            }
        }

        private void CreateParent()
        {
            _poolParent = new GameObject().transform;
            _poolParent.name = $"Pool + {_prefab.name}";
        }

        public GameObject GetObject()
        {
            foreach (var obj in _pool)
            {
                if (!obj.activeInHierarchy)
                {
                    obj.transform.SetParent(_poolParent);
                    
                    obj.transform.position = _prefab.transform.position;
                    obj.transform.rotation = _prefab.transform.rotation;
                    obj.transform.localScale = _prefab.transform.localScale;

                    return obj;
                }
            }

            return Instantiate();
        }


        private GameObject Instantiate()
        {
            var newObject = Object.Instantiate(_prefab);
            newObject.transform.SetParent(_poolParent);
            newObject.SetActive(false);
            _pool.Add(newObject);
            return newObject;
        }

        public List<GameObject> GetSpawns()
        {
            return _pool;
        }
        
    }
}