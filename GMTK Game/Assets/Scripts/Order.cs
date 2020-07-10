using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Order : MonoBehaviour
{
    public float timeOfInitialization;
    public string orderType;
    public List<string> requiredIngredients;

    public float cutoffForFullPoints;
    public float cutoffForPartialPoints;

    // Start is called before the first frame update
    void Start()
    {
        timeOfInitialization = Time.timeSinceLevelLoad;
        determineOrder();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void determineOrder()
    {
        Random r = new Random();
        int rInt = r.Next(0, 4);
        if (rInt == 0)
        {
            orderType = "salad";

        }

    }

    public int CompleteOrder()
    {
        int points = 0;

        float timeToMake = Time.time - timeOfInitialization;
        if (timeToMake < cutoffForFullPoints)
            points += 50;
        if (timeToMake < cutoffForPartialPoints)
            points += 50 * (int)Math.Round(timeToMake / cutoffForFullPoints);

        return points;
    }
}
