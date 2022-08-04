using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    public int time;
    float timer;
    Text myText;

    private void Awake()
    {
        myText = GetComponent<Text>();
    }

    void Start()
    {
        timer = time;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        myText.text = "Time: " + timer.ToString("0.00");
        if(timer <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
