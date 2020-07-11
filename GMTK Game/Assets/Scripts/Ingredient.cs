using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string name;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.SetParent(GameObject.Find("IntObjContainer").transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
    }
}
