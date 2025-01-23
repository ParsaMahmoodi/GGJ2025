using UnityEngine;

namespace Weapon.Main.Bubble
{
    [CreateAssetMenu(menuName = "Game/Player/Player data", fileName = "NewPlayerData")]
    public class PlayerData : ScriptableObject
    {
        public Vector2 minBounds;
        public Vector2 maxBounds;
        public float moveSpeed = 5f;
        public float bubbleShootForce;
        public float initialSize = 1f;
        public float sizeReductionPerShot = 0.1f;
        public float minSize = 0.5f;
        public float initialHealth;
    }
}