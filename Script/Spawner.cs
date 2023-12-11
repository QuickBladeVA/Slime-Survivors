using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawn;
    public float maxTime = 1;
    private float timer = 0;
    public float range = 0;
    public bool isAttacking;


    void Update()
    {
        //Checks for Game Over
        if (GameManager.Instance.isGameOver != true)
        {
            if (this.gameObject.CompareTag("Enemy"))
            {
                EnemyController ec = this.gameObject.GetComponent<EnemyController>();
                if (ec.green == true)
                {
                    Animator animator = this.gameObject.GetComponent<Animator>();
                    animator.SetBool("isAttacking", isAttacking);
                }
                if (timer < maxTime)
                {
                    isAttacking = true;
                }
                if (timer > maxTime)
                {
                    //Spawns the object in random within the range
                    GameObject gameSpawn = Instantiate(spawn);
                    gameSpawn.transform.position = transform.position + new Vector3(Random.Range(-range, range), Random.Range(-range, range), 0);
                    isAttacking = false;
                    timer = 0;
                }

                timer += Time.deltaTime;
            }
            else
            {
                if (timer > maxTime)
                {
                    //Spawns the object in random within the range
                    GameObject gameSpawn = Instantiate(spawn);
                    gameSpawn.transform.position = transform.position + new Vector3(Random.Range(-range, range), Random.Range(-range, range), 0);
                    timer = 0;
                }
                timer += Time.deltaTime;

            }

        }
        else
        {
            if (this.gameObject.CompareTag("Enemy"))
            {
                EnemyController ec = this.gameObject.GetComponent<EnemyController>();
                if (ec.green == true)
                {
                    Animator animator = this.gameObject.GetComponent<Animator>();
                    animator.SetBool("isAttacking", isAttacking);
                    isAttacking = false;
                }
            }

        }
    }
}