using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.position.y <= -1 && rb.linearVelocity.y < -5 || collision.gameObject.CompareTag("Moon"))
        {
            Destroy(gameObject);
        }
        //if (collision.gameObject.CompareTag("Moon"))
        //{
        //    Destroy(gameObject);
        //}
    }
}
