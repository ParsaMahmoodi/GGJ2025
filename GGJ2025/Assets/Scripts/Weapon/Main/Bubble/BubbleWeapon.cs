using UnityEngine;
using Weapon.Application;

namespace Weapon.Main.Bubble
{
    public class BubbleWeapon : IWeapon
    {
        private readonly PlayerManager _playerManager;
        private readonly ObjectPool _bubblePool;

        public BubbleWeapon(PlayerManager playerManager)
        {
            _playerManager = playerManager;
            _bubblePool = new ObjectPool(playerManager.bubblePrefab, 10);
        }

        public void Shoot()
        {
            var bubble = _bubblePool.GetObject();
            bubble.transform.position = _playerManager.shootPoint.position;
            bubble.transform.rotation = _playerManager.shootPoint.rotation;

            var bubbleMovement = bubble.GetComponent<BubbleBullet>();
            if (bubbleMovement != null)
            {
                bubbleMovement.enabled = true;
            }

            bubble.SetActive(true);
        }
    }
}