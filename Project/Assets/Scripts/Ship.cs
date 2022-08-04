using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {

    public GameObject ball;
    float originalGravity;

	void Start () {
		
	}
	
	void Update () {
        var balls = GameObject.FindGameObjectsWithTag("Ball");

        if(balls.Length < 2)
        {
            Instantiate(ball);
            ball.transform.position = transform.position + new Vector3(Random.Range(-.5f, .5f), 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var targetRB = collision.gameObject.GetComponent<Rigidbody2D>();
        originalGravity = targetRB.gravityScale;

        targetRB.gravityScale = .1f;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var targetRB = collision.gameObject.GetComponent<Rigidbody2D>();
        targetRB.gravityScale = originalGravity;
    }
}
