using UnityEngine;
using DG.Tweening; // Import DOTween
using Weapon.Application;
using Unity.VisualScripting;
using System;

namespace Weapon.Main.Bubble
{
    public class PlayerManager : MonoBehaviour
    {
        public GameObject bubblePrefab;
        public Transform shootPoint;

        private IWeapon _currentWeapon;
        private Rigidbody2D _rb;
        private Vector2 _movement;
        private Vector3 _currentSize;
        private float _health;
        private PlayerData _playerData;
        
        private Health _playerHealth;
        private Damageable _damageable;


        private int _bubblesShot;
        private bool _isCoolingDown;
        private Vector3 _originalScale;
        private Vector2 _velocity;
        private Vector2 _currentPosition;

        public AudioSource audioSource;
        public AudioClip die_1;
        public AudioClip die_2;

        public Action OnDieAction;

        private bool isAlive = true;

        private void Start()
        {
            ResolveDependency();
            _rb = GetComponent<Rigidbody2D>();
            _originalScale = new Vector3(_playerData.initialSize, _playerData.initialSize, 1f);
            _currentSize = _originalScale;
            transform.localScale = _currentSize;

            _currentWeapon = new BubbleWeapon(this);
        }

        private void ResolveDependency()
        {
            _playerData = Resources.Load<PlayerData>("Player/PlayerData");
            _playerHealth = this.GetComponent<Health>();
            _damageable = this.GetComponent<Damageable>();
            audioSource = this.GetComponent<AudioSource>();
            _playerHealth.OnDie += OnDie;
        }

        private void Update()
        {
            if (isAlive)
            {
                _movement.x = Input.GetAxisRaw("Horizontal");
                _movement.y = Input.GetAxisRaw("Vertical");
                _movement = _movement.normalized;

                if (Input.GetKeyDown(KeyCode.Space) && CanShoot())
                {
                    ShootBubble();
                }
            }
        }

        private void FixedUpdate()
        {
            _velocity = Vector2.Lerp(_velocity, _movement * _playerData.moveSpeed, 0.05f);

            _currentPosition = _rb.position + _velocity * Time.fixedDeltaTime;

            var clampedPosition = new Vector2(
                Mathf.Clamp(_currentPosition.x, _playerData.minBounds.x, _playerData.maxBounds.x),
                Mathf.Clamp(_currentPosition.y, _playerData.minBounds.y, _playerData.maxBounds.y)
            );

            _rb.MovePosition(clampedPosition);
        }

        private bool CanShoot()
        {
            return !_isCoolingDown && _bubblesShot < _playerData.maxBubbles;
        }

        private void ShootBubble()
        {
            _currentWeapon.Shoot();
            _bubblesShot++;

            var newScale = transform.localScale * _playerData.shrinkFactor;
            transform.DOScale(newScale, _playerData.shrinkDuration).SetEase(Ease.InOutSine);

            if (_bubblesShot >= _playerData.maxBubbles)
            {
                StartCooldown();
            }
        }

        private void StartCooldown()
        {
            _isCoolingDown = true;

            Invoke(nameof(ResetShooting), _playerData.cooldownTime);
        }

        private void ResetShooting()
        {
            _bubblesShot = 0;

            transform.DOScale(_originalScale, _playerData.growDuration).SetEase(Ease.OutBounce);

            _isCoolingDown = false;
        }
    
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                _damageable.InflictDamage(1, false, collision.gameObject);
                
                Debug.Log(_playerHealth.GetRatio());
                
                collision.gameObject.SetActive(false);
            }
        }   
    
        void OnDie()
        {
            OnDieAction?.Invoke();

            Stop();

            audioSource.clip = die_1;
            audioSource.Play();
            
            Invoke(nameof(OnDie2), die_1.length);
        }

        void OnDie2()
        {
            audioSource.clip = die_2;
            audioSource.Play();
        }
    
        void Stop()
        {
            isAlive = false;
        }
    }
}