using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int maxTimeBetweenGhosts;
    public int minTimeBetweenGhosts;

    // Gives player 20 seconds of time to prepare
    private double timeOfNextGhost = 20f;
    private double timeBetweenGhosts = 10f;

    // Dictionaries to store possible ingredients for each order and their likelihood (100 means always a component, 0 means never).
    private Dictionary<string, int> possibleBurgerIngredients;
    private Dictionary<string, int> possibleSaladIngredients;



    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        possibleBurgerIngredients.Add("bun", 100);
        possibleBurgerIngredients.Add("burger", 70);
        possibleBurgerIngredients.Add("chicken", 20);
        possibleBurgerIngredients.Add("veggie", 20);
        possibleBurgerIngredients.Add("cheese", 70);
        possibleBurgerIngredients.Add("lettuce", 60);
        possibleBurgerIngredients.Add("tomato", 50);
        possibleBurgerIngredients.Add("onions", 40);
        possibleBurgerIngredients.Add("ketchup", 70);
        possibleBurgerIngredients.Add("mustard", 30);
    }



    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeOfNextGhost)
        {
            timeOfNextGhost += timeBetweenGhosts;
            ghostEvent();
            // Calculating time before next ghost event:
            Random r = new Random();
            timeBetweenGhosts = 5 + r.NextDouble() * 10;
        }
    }

    private void ghostEvent()
    {

    }

    // Make a number of functions that represent different ghost actions, then call on at random
}










