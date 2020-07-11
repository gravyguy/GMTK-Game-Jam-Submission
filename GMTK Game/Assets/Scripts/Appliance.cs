using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Appliance refers to stationary kitchen fixtures that can have food places on them, but cannot be moved themselves
/// </summary>
public class Appliance : MonoBehaviour
{
    string type;
    static List<string> possibleTypes = new List<string>();
    //GameObject cur

    // Start is called before the first frame update
    void Start()
    {
        possibleTypes.Add("grill");
        possibleTypes.Add("choppingBoard");
        if (possibleTypes.Contains(type))
            Debug.LogError("Invalid Appliance Type: " + type);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (type == "grill")
            return;
    }
}
