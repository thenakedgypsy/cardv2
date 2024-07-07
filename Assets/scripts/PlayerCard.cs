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
    private bool isDragging = false;
    private Vector2 dragOffset;

    [Header("UI ELEMENTS")]
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI staminaText;

    private Vector3 healthTextOffset;
    private Vector3 staminaTextOffset;

    private void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        healthTextOffset = healthText.transform.position - transform.position;
        staminaTextOffset = staminaText.transform.position - transform.position;
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
        healthText.text = $"{health}";
        staminaText.text = $"{stamina}";
    }

        private void UpdateUIPosition()
    {
            healthText.transform.position = transform.position + healthTextOffset;
            staminaText.transform.position = transform.position + staminaTextOffset;
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
        }
    }

        private void LateUpdate()
        {
            UpdateUIPosition();
        }

}
