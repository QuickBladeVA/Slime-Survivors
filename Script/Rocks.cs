using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Projectile proj = collision.GetComponent<Projectile>();
            proj.isContact = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Projectile proj = collision.GetComponent<Projectile>();
            proj.isContact = true;
        }
    }

}
