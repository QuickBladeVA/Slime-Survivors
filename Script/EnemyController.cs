using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform player; 
    public float speed; 
    public bool isFacingRight; 
    public bool isWalking;
    private int playerhp;
    private float maxTime = 3;
    private float timer = 0;

    private Rigidbody2D rb; 
    private Animator animator;
    private Hp hp;


    public bool blue = false;
    public bool green=false;
    public bool red = false;
    public bool yellow = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hp = this.gameObject.GetComponent<Hp>();
        player = GameManager.Instance.player;
        playerhp = GameManager.Instance.health;


    }

    void Update()
    {
        if (green!=true) { 
        HandleAnimation(); // Handle the enemy's animations.
    }
        if (GameManager.Instance.isGameOver != true && hp.isDead != true)
        {

                if (timer > maxTime)
                {
                    MoveTowardsPlayer(); // Move the enemy towards the player.
                    Flip(); // Flip the enemy's sprite if needed
                }
                timer += Time.deltaTime;
        }
        else
        {
            rb.velocity = new Vector2(0 * speed, 0 * speed); // Set the velocity to move towards the player.
            isWalking = false;
        }
    }

    void MoveTowardsPlayer()
    {
        if (player != null) // Check if the player reference is not null.
        {
            Vector3 direction = player.position - transform.position; // Calculate the direction to the player.
            direction.Normalize(); // Normalize to get a smooth movement.
            rb.velocity = direction * speed; // Set the velocity to move towards the player.
            isWalking = true; 
        }
    }

    void HandleAnimation()
    {
        animator.SetBool("isWalking", isWalking); // Set the "isWalking" in the animator.
    }

    void Flip()
    {
        if (player != null) // Check if the player reference is not null.
        {
            Vector3 direction = player.position - transform.position; // Calculate the direction to the player.
            if ((isFacingRight && direction.x < 0f) || (!isFacingRight && direction.x > 0f))
            {
                isFacingRight = !isFacingRight; // Flip the facing direction.
                Vector3 localScale = transform.localScale; 
                localScale.x *= -1f; 
                transform.localScale = localScale; // Apply the new scale to flip.
            }
        }
    }
}
