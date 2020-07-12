using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

/// <summary>
/// Appliance refers to stationary kitchen fixtures that can have food places on them, but cannot be moved themselves
/// </summary>
public class Appliance : MonoBehaviour
{
    // The current item on this appliance
    private GameObject placedItem;


    public string type;
    public bool heatOn;
    static List<string> possibleTypes = new List<string>();
    //GameObject cur

    // Start is called before the first frame update
    void Start()
    {
        possibleTypes.Add("grill");
        possibleTypes.Add("choppingBoard");
        if (!possibleTypes.Contains(type))
            Debug.LogError("Invalid Appliance Type: " + type);

    }

    // Update is called once per frame
    void Update()
    {
        if(heatOn && placedItem != null)
        {
            placedItem.GetComponent<Cooking>().Cook();
        }
    }

    private void OnMouseDown()
    {
        switch (type)
        {
            case "grill":
                if (GameManager.instance.currentItem != null && GameManager.instance.currentItem.tag == "Grilled" && placedItem == null)
                {
                    GameManager.instance.currentItem.transform.position = this.transform.position;
                    placedItem = GameManager.instance.currentItem;
                    GameManager.instance.currentItem = null;
                }
                else if (placedItem != null && GameManager.instance.currentItem == null)
                {
                    GameManager.instance.currentItem = placedItem;
                    placedItem = null;
                }
                break;

            case "choppingBoard":
                break;
        }


        
    }
}
