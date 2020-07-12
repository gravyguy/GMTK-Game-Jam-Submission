using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Burner : MonoBehaviour
{
    public Sprite grillOn;
    public Sprite grillOff;
    public bool stateOn = false;
    public Appliance grill;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        ChangeGrillState();
    }

    /// <summary>
    /// Turns the grill on or off
    /// </summary>
    public void ChangeGrillState()
    {
        if (stateOn)
        {
            Debug.Log("Grill Off");
            stateOn = false;
            spriteRenderer.sprite = grillOff;
            grill.heatOn = false;
           
        }
        else
        {
            Debug.Log("Grill On");
            stateOn = true;
            spriteRenderer.sprite = grillOn;
            grill.heatOn = true;
        }
    }
}
