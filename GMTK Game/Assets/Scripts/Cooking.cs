using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    public GameObject ingredient;
    public bool cooked = false;
    public int undercookTime = 90;
    public int cookTime = 180;
    public int overcookTime = 270;

    private int cookPercentage = 0;

    private SpriteRenderer spriteRenderer;

    public Sprite undercookSprite;
    public Sprite cookedSprite;
    public Sprite overcookSprite;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cookPercentage > overcookTime)
        {
            spriteRenderer.sprite = overcookSprite;
            cooked = false;
        }
        else if (cookPercentage > cookTime)
        {
            spriteRenderer.sprite = cookedSprite;
            cooked = true;
        }
        else if (cookPercentage > undercookTime)
        {
            spriteRenderer.sprite = undercookSprite;
            cooked = false;
        }
    }

    public void Cook()
    {
        cookPercentage++;
    }
}
