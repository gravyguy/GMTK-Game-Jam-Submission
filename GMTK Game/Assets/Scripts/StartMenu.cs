using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject manager;

    // Start is called before the first frame update
    void Awake()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void beginGame()
    {
        manager.SetActive(true);
        GameObject.Find("StartMenu").SetActive(false);
    }
}
