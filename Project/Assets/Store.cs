using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Store : MonoBehaviour
{

    public Text totalPointsText;
    public Text NotEnoughPointsPrefab;
    int totalPoints;
    public Button buyButton;
    Text buyButtonText;

    private void Awake()
    {
        buyButtonText = buyButton.transform.GetComponentInChildren<Text>();
        totalPoints = PlayerPrefs.GetInt("totalPoints", 0);
    }

    void Start()
    {
        totalPoints += Stats.total;
        totalPointsText.text = "Total Points: " + totalPoints;
    }

    int trufal;
    bool bought;

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("trufal", trufal);
        PlayerPrefs.SetInt("totalPoints", totalPoints);
        PlayerPrefs.SetInt("bought", true ? 1 : 0); 
        //PlayerPrefs.SetString("buyButtonText.text", buyButtonText.text);
    }

    private void OnLevelWasLoaded(int level)
    {
        bought = PlayerPrefs.GetInt("bought") == 1 ? true : false;
        if (bought)
        {
            buyButtonText.text = "Equipped";
            equipped = true;
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
    public static bool equipped;

    public void Buy(int price)
    {
        print(bought);

        // if can buy it
        if (!bought && totalPoints >= price)
        {
            totalPoints -= price;
            buyButtonText.text = "Equipped";
            equipped = true;
            bought = true;
        }
        // cannot buy it
        else if (!bought && totalPoints < price)
        {
            var canvas = FindObjectOfType<Canvas>();
            var newText = Instantiate(NotEnoughPointsPrefab);
            newText.transform.SetParent(canvas.transform);
        }
        else if (bought && equipped)
        {
            buyButtonText.text = "Unequipped";
            equipped = false;
        }
        else if (bought && !equipped)
        {
            buyButtonText.text = "Equipped";
            equipped = true;
        }



        //trufal = PlayerPrefs.GetInt("trufal", 0);

        //if (trufal == 0)
        //{
        //    bought = false;
        //}
        //else if (trufal == 1)
        //{
        //    bought = true;
        //}
        ////buyButtonText.text = PlayerPrefs.GetString("buyButtonText.text", "Astro-Helmet:  5pts");
        ////print(buyButtonText.text);

        //if (price <= totalPoints && !bought)
        //{
        //    //buyButtonText.text = PlayerPrefs.GetString("buyButtonText.text", "Astro-Helmet:  5pts");
        //    totalPoints -= price;
        //    totalPointsText.text = "Total Points: " + totalPoints;
        //    bought = true;
        //    buyButtonText = buyButton.transform.GetComponentInChildren<Text>();
        //    buyButtonText.text = "Equipped";
        //    equipped = true;
        //}

        //// if cannot buy it
        //else if (price > totalPoints && !bought)
        //{
        //    //buyButtonText.text = PlayerPrefs.GetString("buyButtonText.text", "Astro-Helmet:  5pts");
        //    print("NOPE!");
        //    var canvas = FindObjectOfType<Canvas>();
        //    var newText = Instantiate(NotEnoughPointsPrefab);
        //    newText.transform.SetParent(canvas.transform);
        //}

        //else if (bought && equipped)
        //{
        //    //buyButtonText.text = PlayerPrefs.GetString("buyButtonText.text", "Astro-Helmet:  5pts");
        //    buyButtonText.text = "Unequipped";
        //    equipped = false;
        //}

        //else if (bought && !equipped)
        //{
        //    //buyButtonText.text = PlayerPrefs.GetString("buyButtonText.text", "Astro-Helmet:  5pts");
        //    buyButtonText.text = "Equipped";
        //    equipped = true;
        //    //var canvas = FindObjectOfType<Canvas>();
        //    //var newText = Instantiate(NotEnoughPointsPrefab);
        //    //newText.text = "Already Bought!";
        //    //newText.transform.SetParent(canvas.transform);
        //}

    }
    //public static bool GetBool(this PlayerPrefs playerPrefs, string key)
    //{
    //    return PlayerPrefs.GetInt(key) == 1;
    //}

    //public static void SetBool(this PlayerPrefs playerPrefs, string key, bool state)
    //{
    //    PlayerPrefs.SetInt(key, state ? 1 : 0);
    //}
}
