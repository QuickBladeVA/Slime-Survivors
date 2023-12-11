using UnityEngine;
using UnityEngine.UI;
public class Hp : MonoBehaviour
{
    public Slider hpbar;
    public float hp;
    private float maxTime = 1.5f;
    private float timer = 0;
    private Animator animator;
    public bool isDead;
    private BoxCollider2D box;

    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

        // Set initial HP for the player
        if (this.gameObject.CompareTag("Player"))
        {
            hp = GameManager.Instance.health;
        }
    }

    private void Update()
    {
        HealthBar(); // Update health bar
    }

    public void HealthBar()
    {

        if (this.gameObject.CompareTag("Enemy")&& hp <= 0)
        {
            EnemyController ec = GetComponent<EnemyController>();
            SpriteRenderer sr = this.GetComponent<SpriteRenderer>();

            isDead = true;
            sr.color = new Color (60, 60, 60,0.5f);
            HandleAnimation();
            Destroy(box);

            if (timer > maxTime)
            {
                UpdateKillScore(ec); // Update the kill score based on the enemy type
                Destroy(gameObject);
            }
                
            timer += Time.deltaTime; // Increment the timer
        }


        if (this.gameObject.CompareTag("Player"))
        {
            hp = GameManager.Instance.health;
            hpbar.value = hp;
        }

    }

    private void HandleAnimation()
    {
        animator.SetBool("isDead", isDead); // Set the "isDead" in the animator.
    }

    private void UpdateKillScore(EnemyController ec)
    {
        if (ec.red)
        {
            GameManager.Instance.killScore += 10;
        }
        if (ec.green)
        {
            GameManager.Instance.killScore += 15;
        }
        if (ec.blue)
        {
            GameManager.Instance.killScore += 1;
        }
        if (ec.yellow)
        {
            GameManager.Instance.killScore += 3;
        }
    }
}
