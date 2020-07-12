using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public List<GameObject> currentIngredients;
    public List<String> currentIngredientNames;
    private bool onTrash = false;
    private Vector3 pos;
    public bool badMeat;


    // Start is called before the first frame update
    void Start()
    {
        currentIngredients = new List<GameObject>();
        pos = this.gameObject.transform.position;
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.currentItem == this.gameObject)
        {
            if(onTrash)
            {
                removeAllIngredients();
                badMeat = false;
            }
            else {
                GameManager.instance.currentItem = null;
                MoveToCenter();
            }
        }
        else if (GameManager.instance.currentItem != null)
        {
            if (GameManager.instance.currentItem.tag == "Grilled" || GameManager.instance.currentItem.tag == "Chopped" || GameManager.instance.currentItem.tag == "Condiments")
            {
                GameManager.instance.currentItem.transform.position = this.transform.position;
                GameManager.instance.currentItem.transform.position += new Vector3(0f, .1f * currentIngredients.Count, 0f);
                GameManager.instance.currentItem.transform.SetParent(this.transform);
                currentIngredients.Add(GameManager.instance.currentItem);
                currentIngredientNames.Add(GameManager.instance.currentItem.name);
                if(GameManager.instance.currentItem.tag == "Grilled" && !GameManager.instance.currentItem.GetComponent<Cooking>().cooked)
                {
                    badMeat = true;
                }
                GameManager.instance.currentItem = null;
            }
        }
        else
        {
            GameManager.instance.currentItem = this.gameObject;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "TrashCan")
            onTrash = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (onTrash)
        {
            onTrash = false;
        }
    }

    public void removeAllIngredients()
    {
        for (int i = currentIngredients.Count - 1; i >= 0; i--)
            Destroy(currentIngredients[i]);
        currentIngredients.Clear();
        currentIngredientNames.Clear();
    }

    public void removeLastIngredient()
    {
        currentIngredients.RemoveAt(currentIngredients.Count - 1);
    }

    private void MoveToCenter()
    {
        this.gameObject.transform.position = pos;
    }
}
