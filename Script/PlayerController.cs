using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb; 
    public float speed; 
    public bool isFacingRight; 
    public bool isWalking;
    public int Health;

    private Animator animator; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component.
        animator = GetComponent<Animator>(); // Get the Animator component.

    }

    void Update()
    {
        HandleAnimation(); // Handle animations.
        if (GameManager.Instance.isGameOver != true) 
        { 
            Movement(); // Handle player movement.
            Flip(); // Flip the player's sprite
        }
    }

    void Movement() 
    {
        float horizontal = Input.GetAxis("Horizontal"); // Get horizontal input.
        float vertical = Input.GetAxis("Vertical"); // Get vertical input.
        isWalking = horizontal != 0 || vertical != 0; // Check if the player is walking.
    }

    void FixedUpdate()
    {
        if (GameManager.Instance.isGameOver != true)
        {
            float horizontal = Input.GetAxis("Horizontal"); // Get horizontal input.
            float vertical = Input.GetAxis("Vertical"); // Get vertical input.
            rb.velocity = new Vector2(horizontal * speed, vertical * speed); // Apply velocity to the Rb.
        }
        else 
        {
            rb.velocity = new Vector2(0 * speed, 0 * speed); // Apply velocity to the Rb.
        }
    }

    void HandleAnimation()
    {
        animator.SetBool("isWalking", isWalking); // Set the "isWalking" in the animator.
    }

    void Flip()
    {
        float horizontal = Input.GetAxis("Horizontal"); // Get horizontal input.

        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f)) 
        {
            isFacingRight = !isFacingRight; // Flip the facing direction.
            Vector2 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale; // Apply the new scale to flip.
        }
    }



}
