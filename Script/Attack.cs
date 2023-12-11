using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Attack : MonoBehaviour
{
    public GameObject player;
    public float speed = 1f;
    public float xOffset = 5f; // X offset
    public float yOffset = 0f; // Y offset
    public bool isAttackAvail = true;
    public bool isAttacking = false;
    public float offset = 8f;


    private Vector3 attackPosition;
    private SpriteRenderer sr;
    private float maxcd = 1f;
    private float cd = 1;
    private float maxdur = 2f;
    private float dur = 0;
    private float timer = 0;
    private Animator animator;
    private Transform target;




    private void Start()
    {
        target = player.transform;
        sr = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component.
        animator = GetComponent<Animator>(); // Get the SpriteRenderer component.
        xOffset = offset;
        yOffset = 0f;
        this.gameObject.transform.eulerAngles = new Vector3(0, 0, -90);

    }

    private void Update()
    {


        if (GameManager.Instance.isGameOver != true)
        {
            animator.SetBool("isAttacking", isAttacking);

            HandleInput();
            AttackAim();
            if (!isAttacking)
            {

                sr.color = new Color(255, 255, 255);
                if (cd >= maxcd)
                {
                    Debug.Log("Attack Ready");
                    if (Input.GetKey(KeyCode.Space))
                    {
                        sr.color = new Color(0, 255, 0);
                        isAttacking = true;
                        cd = 0;
                    }
                }
                else
                {
                    cd += Time.deltaTime;
                    sr.color = new Color(255, 0, 0);
                    Debug.Log("On Cooldown");
                    Debug.Log(cd);
                }
            }
            else
            {
                if (dur >= maxdur)
                {

                    Debug.Log("Attack Ended");
                    isAttacking = false;
                    dur = 0;
                }
                else
                {
                    dur += Time.deltaTime;
                }
            }
        }
        else
        {
            isAttacking = false;
            sr.color = new Color(255, 255, 255);
        }
    }

    private void HandleInput()
    {
        //LEFT

        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
        {
            xOffset = -offset;
            yOffset = 0f;
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 90);

        }

        //RIGHT

        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        {
            xOffset = offset;
            yOffset = 0f;
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 270);

        }

        //TOP

        if (Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.UpArrow))
        {
            yOffset = offset;
            xOffset = 0f;
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);


        }

        //BOTTOM

        if (Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.DownArrow))
        {
            yOffset = -offset;
            xOffset = 0f;
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 180);

        }
     

        //TOP_LEFT
        if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))||(Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow)))
        {
            xOffset = -offset + 2;
            yOffset = offset - 2;
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 45);
        }
        //BOTTOM_LEFT
        if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))|| (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow)))
        {
            xOffset = -offset+2;
            yOffset = -offset+2;
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, 135);
        }
        //TOP_RIGHT
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W)|| (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow)))
        {
            yOffset = offset-2;
            xOffset = offset-2;
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, -45);
        }
        //BOTTOM_RIGHT
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S)|| (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow)))
        {
            yOffset = -offset + 2;
            xOffset = offset - 2;
            this.gameObject.transform.eulerAngles = new Vector3(0, 0, -135);
        }
    }

    private void AttackAim()
    {
        attackPosition.z = 0;
        attackPosition.x = target.position.x + xOffset; // Apply X offset
        attackPosition.y = target.position.y + yOffset; // Apply Y offset

        Vector3 Position = attackPosition;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, Position, speed * Time.deltaTime); // Corrected the time calculation
        transform.position = smoothedPosition;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        attack(collision);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (timer > 1f)
        {
            attack(collision);
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        attack(collision);
    }

    private void attack(Collider2D collision) 
    {
        if (isAttacking == true)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Hp hp = collision.GetComponent<Hp>();
                hp.hp -= 1;
            }
        }
    }

}

