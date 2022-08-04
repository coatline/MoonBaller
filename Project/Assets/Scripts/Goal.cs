using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Text scoreText;
    public static int score;
    public static int pointType = 2;

    void Start()
    {
        var canvas = FindObjectOfType<Canvas>();
        scoreText = Instantiate(scoreText);
        scoreText.transform.SetParent(canvas.transform);
        scoreText.rectTransform.anchoredPosition = new Vector3(70, 130,0);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //jim lake jr.
        if (collider.gameObject.CompareTag("Ball"))
        {
            score += pointType;
            scoreText.text = "Score: " + score;
            Destroy(collider.gameObject);
        }
    }
}
