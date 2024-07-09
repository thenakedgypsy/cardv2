using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
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

    bool containsCard(Card target) 
    {
        int low = 0;
        int high = deck.Count() - 1;
        while(low <= high)
        {
            middle = Math.Ceiling((low + high) / 2);
            if(deck[middle] == target)
            {
                return true;
            }
            else
            {
                if(deck[middle] < target)
                {
                    low = middle + 1;
                }
                if(deck[middle] > target)
                {
                    high = middle - 1;
                }
            }
        }
        return false
    }

    void sortCardsBubble() //rudimentary sort for now
    {
        bool swapping = true
        end = deck.Count()
        for(i = 1; i < deck.Count(); i++)
        {
            swapping = false;
            if(deck[i-1] > deck[i])
            {
                temp = deck[i];
                deck[i] = deck[i-1];
                deck[i-1] = temp
                swapping = true
            }    
        }
        return deck
    }

}
