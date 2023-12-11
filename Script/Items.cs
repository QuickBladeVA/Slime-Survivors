using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        //Health Potion
        if (collision.gameObject.tag == "Heal")
        {
            
            GameManager.Instance.health += 2;
            Destroy(collision.gameObject);

        }
        //Cursed Orb
        if (collision.gameObject.tag == "Orb")
        {
            GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject Enemy in Enemies)
            {
                //GameObject.Destroy(Enemy);
                Hp hp = Enemy.GetComponent<Hp>();
                hp.hp = 0;

            }
            Destroy(collision.gameObject);
        }
    }
}
