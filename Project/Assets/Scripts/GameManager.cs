using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager inference;
    public GameObject meteor;
    public Upgrade speedUpgrade;
    public Upgrade pointUpgrade;
    float speedSpawnCooldown = 5;
    float pointSpawnCooldown = 10;
    public Text meteorAttackText;
    public Player player;
    public Player bluplayer;
    //public Text scoreText;
    public Text powerupText;
    public GameObject goal;

    private void Awake()
    {
        

        DontDestroyOnLoad(this);

        if (inference == null)
        {
            inference = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        Time.timeScale = 1;
        done = false;
    }

    bool done;
    void Update()
    {
        var currentScene = SceneManager.GetActiveScene();
        if(currentScene.buildIndex == 1 && !done)
        {
            Instantiate(goal);
            //var newScoreText = Instantiate(scoreText);
            var newPowerupText = Instantiate(powerupText);

            var canvas = FindObjectOfType<Canvas>();
            newPowerupText.transform.SetParent(canvas.transform);
            //newScoreText.transform.SetParent(canvas.transform);


            done = true;
            print("inhere");
            if (Store.equipped)
            {
                Instantiate(bluplayer);
                print("equipped");
            }
            else
            {
                print("unequipped");
                Instantiate(player);
            }
        }

        // gets the current scene 
        //creates array of speed upgrades
        var speedUpgradeCount = GameObject.FindGameObjectsWithTag("Speed");
        //creates array of point upgrades
        var pointUpgradeCount = GameObject.FindGameObjectsWithTag("3Point");

        if (speedSpawnCooldown > 0)
        {
            speedSpawnCooldown -= Time.deltaTime;
        }
        if (pointSpawnCooldown > 0)
        {
            pointSpawnCooldown -= Time.deltaTime;
        }

        if (speedUpgradeCount.Length < 1 && currentScene.buildIndex == 1 && speedSpawnCooldown <= 0)
        {
            Instantiate(speedUpgrade);
            speedSpawnCooldown = 30;
        }

        if (pointUpgradeCount.Length < 1 && currentScene.buildIndex == 1 && pointSpawnCooldown <= 0)
        {
            Instantiate(pointUpgrade);
            pointSpawnCooldown = 30;
        }

        //if (currentScene.buildIndex == 2)
        //{
        //    Menu.difficulty = 0;
        //}

        if (currentScene.buildIndex == 1 /* we are in the game */)
        {
            var meteorCount = GameObject.FindGameObjectsWithTag("Meteor");

            if (meteorCount.Length < Menu.difficulty + 2)
            {
                var chance = Random.Range(1, 40);
                var rand = Random.Range(4, 7);
                if (chance == 5)
                {
                    var mytext = Instantiate(meteorAttackText);
                    var canvas = FindObjectOfType<Canvas>();

                    mytext.transform.SetParent(canvas.transform);
                    //mytext.transform.parent = canvas.transform;

                    for (int i = 0; i < 1 + Menu.difficulty * 4; i++)
                    {
                        Instantiate(meteor);
                        meteor.transform.localScale = new Vector3(rand, rand, rand);
                        meteor.transform.position = new Vector2(Random.Range(-6, 6), Random.Range(5, 7));
                        var meteorRB = meteor.GetComponent<Rigidbody2D>();
                        meteorRB.linearVelocity = new Vector2(0, Random.Range(-20, 0));
                    }
                }

                Instantiate(meteor);
                meteor.transform.localScale = new Vector3(rand, rand, rand);
                meteor.transform.position = new Vector2(Random.Range(-6, 6), 5);
            }
        }

    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(1);
    }
    //var currentScene = SceneManager.GetActiveScene();
    //var currentBuildIndex = currentScene.buildIndex;
    //if (currentBuildIndex < 2)
    //{
    //    SceneManager.LoadScene(currentBuildIndex++);
    //}
    //else
    //{
    //    SceneManager.LoadScene(0);
    //}
}
