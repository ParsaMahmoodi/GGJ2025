using System;
using UnityEngine;

namespace Weapon.Main.Bubble
{
    public class BubbleBullet : MonoBehaviour
    {
        public float bubbleShootForce;
        public float duration = 2f;

        private float _elapsedTime = 0f;

        private void OnEnable()
        {
            _elapsedTime = 0;
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            transform.position += transform.right * bubbleShootForce * Time.deltaTime;

            if (_elapsedTime >= duration)
            {
                gameObject.SetActive(false);
            }
        }
    }
}