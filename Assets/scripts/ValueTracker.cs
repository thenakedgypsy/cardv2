using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueTracker : MonoBehaviour
{
public Sprite[] valueSprites;
private SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void changeSprite(int spriteNumber)
    {
        spriteRenderer.sprite = valueSprites[spriteNumber];    
    }
}
