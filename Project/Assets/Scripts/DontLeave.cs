using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontLeave : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector3(0, 0, 0);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
