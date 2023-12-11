using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Bush : MonoBehaviour
{
    private float maxTime = 0.005f;
    private float timer = 0;
    private SpriteRenderer sr;
    private float savespeed;
    private EnemyController ec;

    //When Colliding with the bush slows speed pf both player and slime
    private void OnTriggerEnter2D(Collider2D collision)
    {
	    if (collision.gameObject.tag=="Player")
	    {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.speed = 8;
	    }

        if (collision.gameObject.tag == "Enemy")
        {
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            if (enemy.blue == true)
            {
                enemy.speed = 6;
            }
            if (enemy.red == true)
            { 
            enemy.speed = 4;
            }   
	        
	    }
    }

    //Continues slow while in bush, Timer is there to stop the slow when exit 
    private void OnTriggerStay2D(Collider2D collision)
    {
    	if (collision.gameObject.tag=="Player")
    	{
		    PlayerController player = collision.gameObject.GetComponent<PlayerController>();
		    player.speed = 10;
        	if (timer > maxTime)
        	{
	    	    player.speed = 8;
            	timer = 0;
        	}
        	timer += Time.deltaTime;
	    }

    	if (collision.gameObject.tag=="Enemy")
    	{
		    EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            if (enemy.blue == true)
            {
                enemy.speed = 8;
            }
            if (enemy.red == true)
            {
                enemy.speed = 6;
            }
            if (timer > maxTime)
        	{
                if (enemy.blue == true)
                {
                    enemy.speed = 6;
                }
                if (enemy.red == true)
                {
                    enemy.speed = 4;
                }
                timer = 0;
        	}
        	timer += Time.deltaTime;
	    }
    }
    //removes the slow for player and slime
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
	    {
		    PlayerController player = collision.gameObject.GetComponent<PlayerController>();
		    player.speed = 10;
	    }
        if (collision.gameObject.tag == "Enemy")
        {
		    EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            if (enemy.blue == true)
            {
                enemy.speed = 8;
            }
            if (enemy.red == true)
            {
                enemy.speed = 6;
            }
        }
    }

}
