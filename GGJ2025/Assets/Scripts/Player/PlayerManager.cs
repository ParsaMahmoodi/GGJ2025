using UnityEngine;
using Weapon.Application;
using Weapon.Main.Bubble;

public class PlayerManager : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 minBounds;
    public Vector2 maxBounds;

    private IWeapon _currentWeapon;

    public float initialSize = 1f;
    public float sizeReductionPerShot = 0.1f;
    public float minSize = 0.5f;
    public GameObject bubblePrefab;
    public Transform shootPoint;
    public float bubbleShootForce;
    public int Health;

    private Rigidbody2D _rb;
    private Vector2 _movement;
    private Vector3 _currentSize;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _currentSize = new Vector3(initialSize, initialSize, 1f);
        transform.localScale = _currentSize;

        _currentWeapon = new BubbleWeapon(this);
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
        _rb.velocity = _movement * moveSpeed;

        var clampedPosition = new Vector2(
            Mathf.Clamp(_rb.position.x, minBounds.x, maxBounds.x),
            Mathf.Clamp(_rb.position.y, minBounds.y, maxBounds.y)
        );

        _rb.position = clampedPosition;
    }
}