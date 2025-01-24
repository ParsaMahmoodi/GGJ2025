using System;
using UnityEngine;

namespace Weapon.Main.Bubble
{
    public class BubbleBullet : MonoBehaviour
    {
        public float bubbleShootForce;
        public float duration = 2f;

        private float _elapsedTime = 0f;

        public float enemyScaleFactor = 0.1f;
        private GameObject absorbedEnemy;

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


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogError("INJA");
        bool isEnemyDetected = other.gameObject.GetComponent<SimpleEnemy>() != null;
        Debug.LogError(isEnemyDetected);
        if (absorbedEnemy == null && isEnemyDetected)
        {
            Debug.Log("IFFF");
            absorbedEnemy = other.gameObject;
            AbsorbEnemy(absorbedEnemy);
        }
    }

        void AbsorbEnemy(GameObject enemy)
        {
            enemy.transform.localScale = this.transform.localScale * enemyScaleFactor;

            enemy.transform.position = this.transform.position;
            enemy.transform.SetParent(this.transform);
        }

        void OnBecameInvisible()
        {
            if(absorbedEnemy != null)    
                absorbedEnemy.transform.SetParent(null);
        }
    }
}