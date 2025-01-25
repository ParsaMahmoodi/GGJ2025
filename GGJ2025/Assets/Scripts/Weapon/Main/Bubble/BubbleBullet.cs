using System;
using System.Numerics;
using UnityEngine;

namespace Weapon.Main.Bubble
{
    public class BubbleBullet : MonoBehaviour
    {
        public float bubbleShootForce;
        public float duration = 16f;

        private float _elapsedTime = 0f;

        public float enemyScaleFactor = 0.2f;
        private GameObject absorbedEnemy;
        private GameManager gameManager;

        private void OnEnable()
        {
            _elapsedTime = 0;
        }

        void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (absorbedEnemy == null)
                transform.position += transform.right * bubbleShootForce * Time.deltaTime;

            if (_elapsedTime >= duration)
            {

                if (absorbedEnemy != null)
                {
                    gameManager.IncreaseScore(10);

                    absorbedEnemy.GetComponent<Enemy>().shouldMove = true;
                    absorbedEnemy.transform.SetParent(null);
                    absorbedEnemy = null;
                }

                gameObject.SetActive(false);
            }
        }


        void OnTriggerEnter2D(Collider2D other)
        {

            var enem = other.gameObject.GetComponent<Enemy>();
            bool isEnemyDetected = enem != null;

            if (absorbedEnemy == null && isEnemyDetected)
            {
                enem.shouldMove = false;
                absorbedEnemy = other.gameObject;
                AbsorbEnemy(absorbedEnemy);
            }
        }

        void AbsorbEnemy(GameObject enemy)
        {
            enemy.transform.localScale = this.transform.localScale * enemyScaleFactor;

            enemy.transform.localPosition = UnityEngine.Vector2.zero;
            enemy.transform.SetParent(this.transform);
            var x = enemy.GetComponent<RectTransform>();
            x.anchoredPosition = UnityEngine.Vector2.zero;
        }
    }
}