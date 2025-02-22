using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of movement

    private Rigidbody2D player;
    private Vector2 movement;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input for left and right movement
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        // Apply movement
        player.velocity = new Vector2(movement.x * speed, player.velocity.y);
    }
}