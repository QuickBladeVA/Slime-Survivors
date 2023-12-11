using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    private float maxTime = 1;
    private float timer = 0;
    private SpriteRenderer sr;
    public GameObject UI;
    private Image face;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        face= UI.GetComponent<Image>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleEnemyCollision(collision);
        HandleProjectileCollision(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        HandleContinuousEnemyCollision(collision);
        HandleProjectileCollision(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ResetCollisionVisuals(collision);
    }

    // Handle collision with enemy
    private void HandleEnemyCollision(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Hp hp = collision.GetComponent<Hp>();
            if (hp != null && !hp.isDead)
            {
                sr.color = Color.red;
                face.color = Color.red;
                GameManager.Instance.health -= 1;
            }
        }
    }

    // Handle continuous collision with enemy
    private void HandleContinuousEnemyCollision(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            sr.color = Color.white;
            face.color = Color.white;

            if (timer > maxTime)
            {
                sr.color = Color.red;
                face.color = Color.red;
                GameManager.Instance.health -= 1;
                timer = 0;
            }
            timer += Time.deltaTime;
        }
    }

    // Handle collision with projectile
    private void HandleProjectileCollision(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            sr.color = Color.white;
            Projectile proj = collision.GetComponent<Projectile>();
            Debug.Log("Stay Hit");

            if (timer > 0.1f)
            {
                sr.color = Color.red;
                face.color= Color.red;

                GameManager.Instance.health -= 1;
                proj.isContact = true;
                timer = 0;
            }
            timer += Time.deltaTime;
        }
    }

    // Reset the visual effect of the collision
    private void ResetCollisionVisuals(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Projectile"))
        {
            sr.color = Color.white;
            face.color =Color.white;
        }
    }
}
