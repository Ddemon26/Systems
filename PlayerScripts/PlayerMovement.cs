using UnityEngine;
using System.Collections.Generic;
public class PlayerMovement : MonoBehaviour
{    
    [SerializeField] float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // Capture the input from the horizontal and vertical axes
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        // Move the player by applying a velocity, scaled by moveSpeed and Time.fixedDeltaTime
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
