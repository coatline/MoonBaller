using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    int totalPoints;
    //public Text ptsTxt;
    public GameManager gameManagerPrefab;
    public static int difficulty = 2;
    public GameObject meteorite;

    void Start()
    {
        var GameManagers = FindObjectOfType<GameManager>();
        if (GameManagers == null)
        {
            Instantiate(gameManagerPrefab);
            //print("gamemanager is created");
        }
        //totalPoints += Goal.score;

        //ptsTxt.text = "Total Points: " + totalPoints;
    }

    void Update()
    {
        //var currentScene = SceneManager.GetActiveScene();
        //if (currentScene.buildIndex == 2)
        //{
        //    totalPoints += Goal.score;

        //    ptsTxt.text = "Total Points: " + totalPoints;
        //}
    }

    public void ChooseDifficulty(int level)
    {
        difficulty = level;
        print("level is:" + level);
        print("difficulty is:" + difficulty);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Store()
    {
        SceneManager.LoadScene(3);
    }
}
