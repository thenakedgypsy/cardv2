using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCard : MonoBehaviour
{
    public string cardName;
    public int health;
    public int stamina;
    public SpriteRenderer spriteRenderer;
    public ValueTracker healthBar;
    public GameObject staminaBar;
    private bool isDragging = false;
    private Vector2 dragOffset;



    private void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateUI();
    }

    public void Initialize(int startingHealth, int startingStamina, Sprite cardSprite)
    {
        health = startingHealth;
        stamina = startingStamina;
        spriteRenderer.sprite = cardSprite;

        UpdateUI();
    }

    private void UpdateUI()
    {
        healthBar.changeSprite(health);

    }



        void OnMouseDown()
    {
        isDragging = true;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragOffset = (Vector2)transform.position - mousePosition;
        Debug.Log("Mouse Down: Dragging Started");
    }

        void OnMouseUp()
    {
        isDragging = false;
        Debug.Log("Mouse Up: Dragging Stopped");
    }

        private void Update()
    {
        if (isDragging)
        {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition + dragOffset;
        Debug.Log("Dragging: " + (mousePosition + dragOffset));
        UpdateUI();
        }
    }


}
