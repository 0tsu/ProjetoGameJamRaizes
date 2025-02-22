using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D player;
    private Vector2 movement;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        player.velocity = new Vector2(movement.x * speed, player.velocity.y);
    }
}