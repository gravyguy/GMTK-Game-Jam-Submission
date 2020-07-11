using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodContainer : MonoBehaviour
{
    public GameObject foodToCreate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.currentItem == null)
        {
            GameManager.instance.currentItem = Instantiate(foodToCreate);
            Debug.Log("Made it");
        }
    }
}
