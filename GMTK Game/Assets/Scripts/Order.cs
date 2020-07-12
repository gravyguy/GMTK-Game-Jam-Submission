using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class Order : MonoBehaviour
{
    public float defaultBurgerTime = 10f;
    //public float defaultSaladTime = 20f;
    public int burgerRarity = 70;
    public int chickenRarity = 20;
    public int veggieRarity = 10;
    public int maxIngredients = 5;
    public bool onPlate;
    public Plate plateToUse;
    public Text pointsText;

    private BoxCollider2D collider;
    [SerializeField]
    private float cutoffForLifeLoss;
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
        pointsText = GameObject.Find("CurrentPoints").GetComponent<Text>();
        cutoffForLifeLoss = 30f;
        collider = GetComponent<BoxCollider2D>();
        onPlate = false;
        timeOfInitialization = Time.timeSinceLevelLoad;
        determineOrder();

        orderNumber.text = "Order #" + GameManager.instance.orderNumber;
        if (orderType == "salad")
            orderTypeText.text = "salad";
        else if (requiredIngredients[0] == "Burger")
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
        if ((Time.time - timeOfInitialization) > cutoffForLifeLoss && GameManager.instance != null)
        {
            GameManager.instance.livesLeft -= 1;
            GameManager.instance.livesText.text = "" + GameManager.instance.livesLeft;
            GameManager.instance.checkIfGameOver();
            GameManager.instance.currentOrders.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
    }

    private void determineOrder()
    {
        Random r = new Random();
        int rInt = r.Next(0, 4);
        //if (rInt == 0)
        //    createSaladOrder();
        //else
        createBurgerOrder();

        //foreach (string item in requiredIngredients)
        //{
        //    Debug.Log(item);
        //}
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
            requiredIngredients.Add("Burger");
        else if (rInt < burgerRarity + chickenRarity)
            requiredIngredients.Add("Chicken");
        else
            requiredIngredients.Add("Veggie");

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
        Random r = new Random();
        int rInt = r.Next(1, 6);
        AudioManagerScript.PlaySound("orderup" + rInt);

        int totalIngredients = 0;
        int orderPoints = 0;
        int ingredientDiff = 0;

        float timeToMake = Time.time - timeOfInitialization;
        if (timeToMake < cutoffForLifeLoss)
        {
            orderPoints += (int)Math.Round(10 * (cutoffForLifeLoss / (timeToMake + 5)));
        }

        Plate plate = GameObject.Find("Plate").GetComponent<Plate>();
        int numWrongIngredients = 0;
        for (int i = 0; i < requiredIngredients.Count; i++)
        {
            if(plate.currentIngredientNames.Contains(requiredIngredients[i] + "(Clone)"))
            {
                totalIngredients++;
                orderPoints += 5;
                Debug.Log("Scored " + requiredIngredients[i]);
            } else
            {
                orderPoints -= 5;
                numWrongIngredients++;
            }
        }
        if (plate.currentIngredientNames.Contains("BottomBun(Clone)"))
        {
            orderPoints += 5;
            totalIngredients++;
            Debug.Log("Scored Bottom Bun");
        }
        if (plate.currentIngredientNames.Contains("TopBun(Clone)"))
        {
            orderPoints += 5;
            totalIngredients++;
            Debug.Log("Scored Top Bun");
        }
        if (plate.badMeat)
        {
            orderPoints -= 10;
            Debug.Log("Penalized for bad meat");
        }

        ingredientDiff = Math.Abs(totalIngredients - plate.currentIngredientNames.Count);
        orderPoints -= 5;

        if (numWrongIngredients > 1)
        {
            orderPoints -= 10;
            GameManager.instance.livesLeft -= 1;
            GameManager.instance.livesText.text = "" + GameManager.instance.livesLeft;
            GameManager.instance.checkIfGameOver();
        }

        //Debug.Log(orderPoints);


        GameObject.FindObjectOfType<Plate>().removeAllIngredients();

        GameManager.instance.points += orderPoints;
        pointsText.text = ("Score: " + GameManager.instance.points);

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
