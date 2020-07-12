using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Plate : MonoBehaviour
{
    List<GameObject> currentIngredients;
    private BoxCollider2D collider;
    private bool onTrash = false;


    // Start is called before the first frame update
    void Start()
    {
        currentIngredients = new List<GameObject>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.currentItem == this.gameObject)
        {
            if(onTrash)
            {
                removeAllIngredients();
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
                GameManager.instance.currentItem.transform.position += new Vector3(0f, .08f * currentIngredients.Count, 0f);
                GameManager.instance.currentItem.transform.SetParent(this.transform);
                currentIngredients.Add(GameManager.instance.currentItem);
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
    }

    public void removeLastIngredient()
    {
        currentIngredients.RemoveAt(currentIngredients.Count - 1);
    }

    private void MoveToCenter()
    {
        this.gameObject.transform.position = new Vector3(1.2f, -4f, 0f);
    }
}
