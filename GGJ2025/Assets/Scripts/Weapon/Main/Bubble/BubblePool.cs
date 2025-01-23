using System.Collections.Generic;
using UnityEngine;

namespace Weapon.Main.Bubble
{
    public class BubblePool
    {
        private readonly GameObject _bubblePrefab;
        private readonly List<GameObject> _pool;

        public BubblePool(GameObject bubblePrefab, int initialSize)
        {
            _bubblePrefab = bubblePrefab;
            _pool = new List<GameObject>(initialSize);

            for (var i = 0; i < initialSize; i++)
            {
                var bubble = Object.Instantiate(bubblePrefab);
                bubble.SetActive(false);
                _pool.Add(bubble);
            }
        }

        public GameObject GetBubble()
        {
            foreach (var bubble in _pool)
            {
                if (!bubble.activeInHierarchy)
                {
                    return bubble;
                }
            }

            var newBubble = Object.Instantiate(_bubblePrefab);
            newBubble.SetActive(false);
            _pool.Add(newBubble);
            return newBubble;
        }
    }
}