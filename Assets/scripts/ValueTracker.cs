using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueTracker : MonoBehaviour
{
public Sprite[] healthSprites;
private SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void changeSprite(int spriteNumber)
    {
        spriteRenderer.sprite = healthSprites[spriteNumber];    
    }
}
