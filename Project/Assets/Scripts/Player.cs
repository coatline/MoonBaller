using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour
{
    public Text powerups;
    Animator animator;
    //public Text scoreText;
    public float moveSpeed;
    Rigidbody2D rb;
    bool canJump;
    public float jumpHeight;
    public static int deaths;
    public bool notmoving;
    float speedCooldown;
    bool doneSpeed = true;
    bool _3PointDone = true;
    float _3PointCooldown;
    SpriteRenderer sr;
    public Sprite newHelmet;
    Animation blueAni;

    void Awake()
    { 
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    bool added = false;
    bool added_2 = false;
    void Update()
    {
        if (Store.equipped)
        {
            sr.sprite = newHelmet;
            //animator = blueAni;
        }
        else
        {
            sr.sprite = sr.sprite;
        }

        if (!doneSpeed)
        {
            if (!_3PointDone)
            {
                powerups.text += "\n";
                if(powerups.text == "3 Pointers\n\nSpeed Up")
                {
                    powerups.text = "3 Pointers\nSpeed up";
                }
            }

            if (!added)
            {
                added = true;
                powerups.text += "Speed Up";
            }
        }
        else if (!_3PointDone && doneSpeed)
        {
            powerups.text = "3 Pointers";
        }
        else
        {
            powerups.text = "";
        }

        if (!_3PointDone)
        {
            if (!doneSpeed)
            {
                powerups.text += "\n";
                if (powerups.text == "Speed Up\n\n3 Pointers")
                {
                    powerups.text = "Speed Up\n3 Pointers";
                }
            }

            if (!added_2)
            {
                added_2 = true;
                powerups.text += "3 Pointers";
            }
        }
        else if(!doneSpeed && _3PointDone)
        {
            powerups.text = "Speed Up";
        }
        else
        {
            powerups.text = "";
        }

        if (speedCooldown > 0)
        {
            speedCooldown -= Time.deltaTime;
            doneSpeed = false;
        }
        else if (speedCooldown <= 0 && !doneSpeed)
        {
            //no more speed+
            moveSpeed -= 50;
            jumpHeight -= 25;
            speedCooldown = 0;
            doneSpeed = true;
        }
        if (_3PointCooldown > 0)
        {
            _3PointCooldown -= Time.deltaTime;
            _3PointDone = false;
        }
        else if (_3PointCooldown <= 0 && !_3PointDone)
        {
            //no more 3pointss
            _3PointCooldown = 0;
            Goal.pointType = 2;
            _3PointDone = true;
        }

        transform.rotation = Quaternion.identity;

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && canJump)
        {
            canJump = false;
            Vector3 force = new Vector3(0, jumpHeight, 0);
            rb.AddForce(force);
        }
        else if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
            var vel = rb.velocity;
            vel.x = -moveSpeed * Time.deltaTime;
            notmoving = false;
            rb.velocity = vel;
            var sp = GetComponent<SpriteRenderer>();
            if (canJump)
            {
                animator.enabled = true;
            }

            sp.flipX = true;
        }
        else if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            var vel = rb.velocity;
            vel.x = moveSpeed * Time.deltaTime;
            rb.velocity = vel;
            notmoving = false;
            var sp = GetComponent<SpriteRenderer>();
            sp.flipX = false;
            if (canJump)
            {
                animator.enabled = true;
            }
        }
        else
        {
            animator.enabled = false;
            var vel = rb.velocity;
            vel.x = 0;
            rb.velocity = vel;
            notmoving = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);

        if (collision.gameObject.CompareTag("Moon") || collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Blockade"))
        {
            canJump = true;
        }
        else if (collision.gameObject.CompareTag("Meteor") && transform.position.y < 4)
        {
            rb.velocity = new Vector2(0, 0);
            transform.position = new Vector3(7, 4, 0);
            //if (Goal.score > 0)
            //{
            //    Goal.score--;
            //    scoreText.text = "Score: " + Goal.score;
            //}
            deaths++;
            if (!doneSpeed)
            {
                doneSpeed = true;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Speed"))
        {
            speedCooldown = 10;
            moveSpeed += 50;
            jumpHeight += 25;
            Destroy(collision.gameObject);
            doneSpeed = false;
        }
        else if (collision.gameObject.CompareTag("3Point"))
        {
            _3PointCooldown = 20;
            Destroy(collision.gameObject);
            _3PointDone = false;
            Goal.pointType = 3;
            print("Chef Curry!");
        }
    }
}
