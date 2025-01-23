using UnityEngine;
using Weapon.Application;

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

        private void Start()
        {
            ResolveDependency();
            _rb = GetComponent<Rigidbody2D>();
            _currentSize = new Vector3(_playerData.initialSize, _playerData.initialSize, 1f);
            transform.localScale = _currentSize;

            _currentWeapon = new BubbleWeapon(this);
        }

        private void ResolveDependency()
        {
            _playerData = Resources.Load<PlayerData>("Player/PlayerData");
        }

        private void Update()
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");
            _movement = _movement.normalized;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _currentWeapon.Shoot();
            }
        }

        private void FixedUpdate()
        {
            _rb.velocity = _movement * _playerData.moveSpeed;

            var clampedPosition = new Vector2(
                Mathf.Clamp(_rb.position.x, _playerData.minBounds.x, _playerData.maxBounds.x),
                Mathf.Clamp(_rb.position.y, _playerData.minBounds.y, _playerData.maxBounds.y)
            );

            _rb.position = clampedPosition;
        }
    }
}