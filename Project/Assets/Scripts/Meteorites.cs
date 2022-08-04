using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meteorites : MonoBehaviour
{

    Text text;

    void Start()
    {
        text = GetComponent<Text>();
    }

    float x = 1;
    float y = 1;
    void Update()
    {
        if (gameObject != null)
        {
            Time.timeScale = .3f;
            x += Time.deltaTime;
            y += Time.deltaTime * 2;
            transform.localScale = new Vector2(x, y);
        }
        if (x >= 1.3f)
        {
            Time.timeScale = 1;
            Destroy(gameObject);
        }
    }
}
