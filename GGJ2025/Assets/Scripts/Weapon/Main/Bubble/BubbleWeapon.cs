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
        }
    }
}