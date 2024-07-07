using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerCard playerCard;
    public int startingHealth = 20;
    public int startingStamina = 10;
    public Sprite playerCardSprite;

    void Start()
    {
        if (playerCard != null)
        {
            playerCard.Initialize(startingHealth,startingStamina,playerCardSprite);
        }
        else
        {
            Debug.LogError("PlayerCard not assigned");
        }
        
    }
}
