using DG.Tweening;
using UnityEngine;

namespace Weapon.Main.Bubble
{
    public class BubbleAnimation : MonoBehaviour
    {
        public float upDownDistance = 0.5f;
        public float upDownDuration = 1.5f;

        private Vector2 _startPosition;

        private void OnEnable()
        {
            var position = transform.localPosition;
            _startPosition = new Vector2(position.x, position.y);

            StartBubbleAnimation();
        }

        private void StartBubbleAnimation()
        {
            transform.DOLocalMoveY(_startPosition.y + upDownDistance, upDownDuration)
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }
}