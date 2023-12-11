using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Projectile : MonoBehaviour
{
    public Transform target;
    public float speed = 100f;
    private Vector3 projPosition;
    private Rigidbody2D rb;
    private float maxTime = 0.5f;
    private float timer = 0;
    public bool isContact = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        target = GameManager.Instance.player;


    }

    // Update is called once per frame
    void Update()
    {
        if (timer < maxTime)
        {
            Movement();
        }
        timer += Time.deltaTime;
        if (timer > 5)
        {
            Destroy(this.gameObject);
        }
        timer += Time.deltaTime;
        if (isContact == true)
        {
            if (timer > 0.1)
            {
                Destroy(this.gameObject);
            }
            timer += Time.deltaTime;
        }
    void Movement()
        {
            Vector3 direction = target.position - transform.position; // Calculate the direction to the player.
            if (direction != target.position)
            {
                rb.velocity = direction * speed; // Set the velocity to move towards the player.
            }
        }
    }
}
