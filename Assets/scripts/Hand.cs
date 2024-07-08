using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public List<Card> cardsInHand = new List<Card>();
    public Transform cardParent;
    public float cardSpacing = 0.8f;

    public void AddCard(Card cardToAdd)
    {
        cardsInHand.Add(cardToAdd);
        cardToAdd.transform.SetParent(cardParent);
        ArrangeCards();
    }

    private void ArrangeCards()
    {
        for (int i = 0; i < cardsInHand.Count; i++)
        {
            Vector3 slot = transform.position 
            + Vector3.right * (i - (cardsInHand.Count - 1) / 2f) * cardSpacing; 
            cardsInHand[i].transform.position = slot; 
        }
    }

}
