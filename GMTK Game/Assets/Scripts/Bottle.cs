using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
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
            GameManager.instance.currentItem = this.gameObject;
            Debug.Log("Made it");
        } else if (GameManager.instance.currentItem == this.gameObject && GetComponent<BoxCollider2D>().IsTouching(GameObject.Find("Plate").GetComponent<BoxCollider2D>()))
        {

        }
    }
}
