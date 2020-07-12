using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Random = System.Random;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;

public class GameManager : MonoBehaviour
{
    public int points;
    public int orderNumber;
    public int livesLeft;

    public static GameManager instance = null;
    // Dictionaries to store possible ingredients for each order and their likelihood (100 means always a component, 0 means never).
    public Dictionary<string, int> possibleBurgerIngredients = new Dictionary<string, int>();
    public Dictionary<string, int> possibleSaladIngredients = new Dictionary<string, int>();
    public GameObject orderPrefab;
    public List<GameObject> currentOrders;
    public GameObject currentItem;

    public int maxTimeBetweenGhosts;
    public int minTimeBetweenGhosts;
    // Gives player 20 seconds of time to prepare
    private double timeOfNextGhost = 20f;
    private double timeBetweenGhosts = 10f;

    private double timeOfNextOrder = 0f;
    private double timeBetweenOrders = 2f;

    // Boolean that determines if a ghost event was successfully completed
    private bool ghostEventSuccess = false;

    // List of possible methods the game manager can call when choosing a ghost event
    private List<Action> possibleGhostEvents = new List<Action>();

    private void Awake()
    {
        //this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        livesLeft = 5;
        points = 0;
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        // Add all possible burger ingredients to the list
        possibleBurgerIngredients.Add("Cheese", 70);
        possibleBurgerIngredients.Add("Lettuce", 60);
        possibleBurgerIngredients.Add("Tomato", 50);
        possibleBurgerIngredients.Add("Onions", 40);
        possibleBurgerIngredients.Add("Pickles", 30);
        possibleBurgerIngredients.Add("Ketchup", 70);
        possibleBurgerIngredients.Add("Mustard", 30);
        possibleBurgerIngredients.Add("SecretSauce", 50);

        // Add all possible salad ingredients to the list
        possibleSaladIngredients.Add("chicken", 55);
        possibleSaladIngredients.Add("tomato", 80);
        possibleSaladIngredients.Add("onions", 65);
        possibleSaladIngredients.Add("croutons", 90);
        possibleSaladIngredients.Add("ranch", 100);
        possibleSaladIngredients.Add("secret sauce", 20);

        // Add all possible ghost actions to the list
        possibleGhostEvents.Add(changeHeat);
        possibleGhostEvents.Add(moveMeat);
        possibleGhostEvents.Add(changeLabels);
        possibleGhostEvents.Add(clogCondiments);
        possibleGhostEvents.Add(rotVegetable);
        possibleGhostEvents.Add(reverseOrders);

        //currentItem = GameObject.Find("GrillHead");
    }



    // Update is called once per frame
    void Update()
    {
        if (currentItem != null)
        {
            currentItem.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentItem.transform.position += new Vector3(0f, 0f, 10f);
        }

        // Handles random ghost events
        if (Time.time > timeOfNextGhost)
        {
            timeOfNextGhost += timeBetweenGhosts;
            ghostEvent();
            // Calculating time before next ghost event:
            Random r = new Random();
            timeBetweenGhosts = 5 + r.NextDouble() * 10;
        }

        // Handles addition of new orders
        if (Time.time > timeOfNextOrder && currentOrders.Count < 5)
        {
            orderNumber++;
            timeOfNextOrder += timeBetweenOrders;
            GameObject newOrder = Instantiate(orderPrefab);
            newOrder.transform.SetParent(GameObject.FindGameObjectWithTag("IntObjContainer").transform);
            currentOrders.Add(newOrder);
            repositionOrders();
        }
    }

    public void checkIfGameOver()
    {
        if (livesLeft <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void repositionOrders()
    {
        for (int i = 0; i < currentOrders.Count; i++)
        {
            //Checks if not holding an order
            if(GameManager.instance.currentItem != currentOrders[i])
            currentOrders[i].transform.position = new Vector3(5f, 2.1f, 0f) + new Vector3((float)(-2.5f * (currentOrders.Count - i - 1)), 0, 0);
        }
    }

    /// <summary>
    /// Chooses a random ghost event to trigger. Repeats until successful
    /// </summary>
    private void ghostEvent()
    {

        Random r = new Random();
        ghostEventSuccess = false;

        while (!ghostEventSuccess)
        {
            // Chooses a random event in the list
            possibleGhostEvents[r.Next(0, possibleGhostEvents.Count - 1)]();
        }

        ghostEventSuccess = true;
    }

    /// <summary>
    /// Randomly changes the heat on one of the grills
    /// </summary>
    private void changeHeat()
    {
        // Will return false if there is not meat on the grill
        if (false)
        {
            return;
        }

        //DO STUFF HERE

        ghostEventSuccess = true;
        return;
    }

    /// <summary>
    /// Moves one of the meats on the grill to a different burner
    /// </summary>
    private void moveMeat()
    {

        // Will return false if there is no meat on the grill
        if (false)
        {
            return;
        }

        // DO STUFF HERE

        ghostEventSuccess = true;
        return;
    }

    /// <summary>
    ///  Switches labels in the condiment section
    /// </summary>
    private void changeLabels()
    {
        // DO STUFF HERE

        ghostEventSuccess = true;
        return;
    }

    /// <summary>
    ///  Causes the condiment bottle to squeeze unnaturally next time the player picks one up
    /// </summary>
    private void clogCondiments()
    {
        // DO STUFF HERE

        ghostEventSuccess = true;
        return;
    }

    /// <summary>
    ///  Chooses a random vegetable to be rotten the next time the player picks it up
    /// </summary>
    private void rotVegetable()
    {
        // DO STUFF HERE

        ghostEventSuccess = true;
        return;
    }

    /// <summary>
    ///  Causes all order tickets to appear upsideown
    /// </summary>
    private void reverseOrders()
    {
        // Will return false if there is no orders currently to flip
        if (false)
        {
            return;
        }

        ghostEventSuccess = true;
        return;
    }
}










