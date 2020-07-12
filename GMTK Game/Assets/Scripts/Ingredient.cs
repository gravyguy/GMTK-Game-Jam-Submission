using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string name;
    private SpriteRenderer spriteRenderer;

    public Sprite choppedSprite;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(GameObject.FindGameObjectWithTag("IntObjContainer").transform);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.tag == "Chopped")
        {
            spriteRenderer.sprite = choppedSprite;
        }
    }

    private void OnMouseDown()
    {

    }
}
