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
        if (GameManager.instance.currentItem == null)
        {
            GameManager.instance.currentItem = this.gameObject;

        }
        else if(!onBoard && GameManager.instance.currentItem == this.gameObject)
        {
            GameManager.instance.currentItem = null;
            MoveToCenter();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cutting Board")
        {
            onBoard = true;
        }
        if (Input.GetMouseButtonDown(0) && collision.gameObject.tag == "Cutting Board")
        {
            if(collision.gameObject.GetComponent<Appliance>().placedItem != null)
            {
                collision.gameObject.GetComponent<Appliance>().placedItem.tag = "Chopped";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (onBoard)
        {
            onBoard = false;
        }
    }


    private void MoveToCenter()
    {
        this.gameObject.transform.position = pos;
    }
}
