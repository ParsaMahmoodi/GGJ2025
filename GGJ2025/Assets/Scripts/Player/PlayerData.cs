using UnityEngine;
using UnityEngine.Serialization;

namespace Weapon.Main.Bubble
{
    [CreateAssetMenu(menuName = "Game/Player/Player data", fileName = "NewPlayerData")]
    public class PlayerData : ScriptableObject
    {
        public Vector2 minBounds;
        public Vector2 maxBounds;
        public int maxBubbles = 4;
        public float shrinkFactor = 0.8f;
        public float cooldownTime = 3f;
        public float shrinkDuration = 0.3f;
        public float growDuration = 2f;
        public float moveSpeed = 5f;
        public float initialSize = 1f;
    }
}