using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunControl : MonoBehaviour
{
    public GameObject topBun;
    public GameObject bottomBun;

    private Plate plate;
    private void Start()
    {
        plate = GameObject.Find("Plate").GetComponent<Plate>();
    }

    private void Update()
    {
        if (plate.currentIngredientNames.Contains("BottomBun(Clone)"))
        {
            GetComponent<FoodContainer>().foodToCreate = topBun;
        }
        else
        {
            GetComponent<FoodContainer>().foodToCreate = bottomBun;
        }
    }
}
