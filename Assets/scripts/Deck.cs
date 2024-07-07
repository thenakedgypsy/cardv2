using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public GameObject cardPrefab;
    public Transform deckPosition;
    public Hand playerHand;

    void Start()
    {
        InitializeDeck();
        //ShuffleDeck();
        Draw();
        Draw();
        Draw();
        
    }

    // 
    void InitializeDeck()
    {
        for (int i = 0; i < 10; i++){
            GameObject cardObject = Instantiate(cardPrefab, transform);
            Card aCard = cardObject.GetComponent<Card>();
            aCard.cardName = $"Card {i + 1}";
            aCard.description = $"This is card number {i + 1}";
            deck.Add(aCard);
            
        }   
    }

    public void Draw()
    {
        if (deck.Count > 0)
        {
            Card drawnCard = deck[0];
            deck.RemoveAt(0);
            drawnCard.gameObject.SetActive(true);
            MoveCardToHand(drawnCard);
        }
       
    }

    public void MoveCardToHand(Card card)
    {
        
        playerHand.AddCard(card);
        card.DisplayInfo();

    }



}
