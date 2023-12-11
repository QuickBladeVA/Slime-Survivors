using UnityEngine;

public class Despawn : MonoBehaviour
{
    public EnemyController Controller;
    public Hp hp;
    public float despawn;
    private float timer = 0;

    void Start()
    {
        Controller = GetComponent<EnemyController>();
        hp = GetComponent<Hp>();
    }

    void Update()
    {
        DespawnLogic();
    }

    void DespawnLogic()
    {
        // Check if the enemy is of type green and handle despawning
        if (Controller.green)
        {
            if (timer > despawn)
            {
                // Ensure there's an HP script and the entity isn't dead before despawning
                if (hp != null && !hp.isDead)
                {
                    hp.hp = 0; // Set the HP to 0 to trigger the death process
                }
                timer = 0; // Reset the timer
            }
            timer += Time.deltaTime; // Increment the timer
        }
    }
}
