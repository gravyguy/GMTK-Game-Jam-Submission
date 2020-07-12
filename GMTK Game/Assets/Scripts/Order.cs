using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Order : MonoBehaviour
{
    public float defaultBurgerTime = 30f;
    public float defaultSaladTime = 20f;
    public int burgerRarity = 70;
    public int chickenRarity = 20;
    public int veggieRarity = 10;
    public int maxIngredients = 5;
    public bool onPlate;

    private BoxCollider2D collider;

    public float cutoffForFullPoints;
    public float timeOfInitialization;
    public string orderType;
    public List<string> requiredIngredients = new List<string>();

    public TextMesh orderNumber;
    public TextMesh orderTypeText;
    public TextMesh ingredient1;
    public TextMesh ingredient2;
    public TextMesh ingredient3;
    public TextMesh ingredient4;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        onPlate = false;
        timeOfInitialization = Time.timeSinceLevelLoad;
        determineOrder();

        orderNumber.text = "Order #" + GameManager.instance.currentOrders.Count;
        if (orderType == "salad")
            orderTypeText.text = "salad";
        else if (requiredIngredients[0] == "burger")
            orderTypeText.text = "burger";
        else
            orderTypeText.text = requiredIngredients[0] + " burger";

        if (requiredIngredients.Count > 1)
            ingredient1.text = "-" + requiredIngredients[1];

        if (requiredIngredients.Count > 2)
            ingredient2.text = "-" + requiredIngredients[2];

        if (requiredIngredients.Count > 3)
            ingredient3.text = "-" + requiredIngredients[3];

        if (requiredIngredients.Count > 4)
            ingredient4.text = "-" + requiredIngredients[4];

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void determineOrder()
    {
        Random r = new Random();
        int rInt = r.Next(0, 4);
        //if (rInt == 0)
        //    createSaladOrder();
        //else
        createBurgerOrder();

        foreach (string item in requiredIngredients)
        {
            Debug.Log(item);
        }
    }

    private void createSaladOrder()
    {
        orderType = "salad";
        requiredIngredients.Add("lettuce");

        // Determine additional ingredients
        Random r = new Random();
        int rInt;

        foreach (KeyValuePair<string, int> entry in GameManager.instance.possibleSaladIngredients)
        {
            if (requiredIngredients.Count < maxIngredients)
            {
                rInt = r.Next(0, 100);
                if (rInt < entry.Value)
                    requiredIngredients.Add(entry.Key);
            }
        }
    }

    private void createBurgerOrder()
    {
        orderType = "burger";

        // Determine what burger to use
        Random r = new Random();
        int rInt = r.Next(0, 100);

        if (rInt < burgerRarity)
            requiredIngredients.Add("burger");
        else if (rInt < burgerRarity + chickenRarity)
            requiredIngredients.Add("chicken");
        else
            requiredIngredients.Add("veggie");

        // Determine additional ingredients
        foreach (KeyValuePair<string, int> entry in GameManager.instance.possibleBurgerIngredients)
        {
            if (requiredIngredients.Count < maxIngredients)
            {
                rInt = r.Next(0, 100);
                if (rInt < entry.Value)
                    requiredIngredients.Add(entry.Key);
            }
        }
    }

    public void CompleteOrder()
    {
        int orderPoints = 0;

        float timeToMake = Time.time - timeOfInitialization;
        if (timeToMake < cutoffForFullPoints)
            orderPoints += 50;
        else
            orderPoints += 50 * (int)Math.Round(timeToMake / cutoffForFullPoints);

        GameObject.FindObjectOfType<Plate>().removeAllIngredients();

        GameManager.instance.points += orderPoints;
        GameManager.instance.currentOrders.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Plate")
            onPlate = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (onPlate)
        {
            onPlate = false;
        }
    }

    private void OnMouseDown()
    {
        if(GameManager.instance.currentItem == null)
        {
            GameManager.instance.currentItem = this.gameObject;
        }
        else if(GameManager.instance.currentItem == this.gameObject)
        {
            if (onPlate)
            {
                CompleteOrder();
            }

            else {
                GameManager.instance.currentItem = null;
                GameManager.instance.repositionOrders();
            }
        }
    }
}
