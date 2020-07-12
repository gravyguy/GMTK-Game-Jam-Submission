using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    public GameObject ingredient;

    public int undercookTime = 900;
    public int cookTime = 1800;
    public int overcookTime = 2700;

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
            spriteRenderer.sprite = overcookSprite;
        else if (cookPercentage > cookTime)
            spriteRenderer.sprite = cookedSprite;
        else if (cookPercentage > undercookTime)
            spriteRenderer.sprite = undercookSprite;
    }

    public void Cook()
    {
        Debug.Log("Cooking");
        cookPercentage++;
    }
}
