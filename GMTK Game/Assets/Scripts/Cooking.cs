using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooking : MonoBehaviour
{
    public int undercookTime = 300;
    public int cookTime = 300;
    public int overcookTime = 300;

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
        
    }
}
