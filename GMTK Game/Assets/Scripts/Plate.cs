using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    List<GameObject> currentIngredients;

    // Start is called before the first frame update
    void Start()
    {
        currentIngredients = new List<GameObject>();
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.currentItem != null)
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
    }

    public void removeAllIngredients()
    {
        for (int i = 0; i < currentIngredients.Count - 1; i++)
            currentIngredients.RemoveAt(i);
    }

    public void removeLastIngredient()
    {
        currentIngredients.RemoveAt(currentIngredients.Count - 1);
    }
}
