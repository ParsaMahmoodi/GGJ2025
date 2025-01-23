using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 2.4f;

    public Vector2 minBounds;
    public Vector2 maxBounds;

    public Vector2 movement;

    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        movement = movement.normalized;
    }

    void FixedUpdate()
    {
        rigidbody.velocity = movement * moveSpeed;
        
        rigidbody.position = new Vector2(
            Mathf.Clamp(rigidbody.position.x, minBounds.x, maxBounds.x),
            Mathf.Clamp(rigidbody.position.y, minBounds.y, maxBounds.y)
        );
    }
}