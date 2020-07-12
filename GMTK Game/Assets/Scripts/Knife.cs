using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    private bool onBoard = false;
    private Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        pos = this.gameObject.transform.position;
    }

    private void OnMouseDown()
    {
        if (GameManager.instance.currentItem == this.gameObject)
        {
            if(!onBoard)
            {
                GameManager.instance.currentItem = null;
                MoveToCenter();
            }
        }
        else
        {
            GameManager.instance.currentItem = this.gameObject;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "BoardSpotRight" || collision.name == "BoardSpotLeft" || collision.name == "BoardSpotMiddle")
        {
            onBoard = true;
        }
        else
        {
            onBoard = false;
        }

        if (Input.GetMouseButtonDown(0) && onBoard)
        {
            if(collision.gameObject.GetComponent<Appliance>().placedItem != null)
            {
                collision.gameObject.GetComponent<Appliance>().placedItem.tag = "Chopped";
            }
        }
    }


    private void MoveToCenter()
    {
        this.gameObject.transform.position = pos;
    }
}
