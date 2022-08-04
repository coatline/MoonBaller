using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public Text deathText;
    int highscore;
    public static int total;

    void Start()
    {
        total += Goal.score;

        highscore = PlayerPrefs.GetInt("highscore", 0);

        if (Goal.score > highscore)
        {
            PlayerPrefs.SetInt("highscore", Goal.score);
            highscore = Goal.score;
        }

        deathText.text = "Deaths: " + Player.deaths;
        scoreText.text = "Score: " + Goal.score;
        highScoreText.text = "Highscore: " + highscore;

    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("highscore", highscore);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Player.deaths = 0;
        Goal.score = 0;
    }
}
