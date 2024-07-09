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

    bool containsCard(Card target) //binary search because why not
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

    void sortCardsBubble() //rudimentary sort for now - also looks at cards not ints so wont work yet
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

    List<int> sortCardsMerge(List<int> arr) //using a list til cards are able to imliment this
    {                                       //realisitcally am i going to be sorting large numbers 
                                            //of cards enough to justify this? no. Was it fun? Yes.
        if(arr.Count() < 2)                 //O(n log n)?
        {
            return arr;
        }
        int mid = arr.Count / 2;
        List<int> left = arr.GetRange(0, mid);
        List<int> right = arr.GetRange(mid, arr.Count - mid);
        List<int> sortedLeft = sortCardsMerge(left);
        List<int> sortedRight = sortCardsMerge(right);
        List<int> mergedList = cardsMerge(sortedLeft, sortedRight);
        return mergedList;
    }

    List<int> cardsMerge(List<int> left, List<int> right)
    {
        List<int> mergedList = new List<int>();
        int i = 0;
        int j = 0;
        while(i < left.Count && j < right.Count)
        {
            if(left[i] < right[j])
            {
                mergedList.Add(left[i]);
                i++;
            }
            else
            {
                mergedList.Add(right[j]);
                j++;
            }
        }
        while(left.Count > i)
        {
            mergedList.Add(left[i]);
            i++;
        }
        while(right.Count > j)
        {
            mergedList.Add(right[j]);
            j++;
        }
        return mergedList;
    }

    List<int> cardsInsertionSort(List<int> arr) //likely a more realistic sort for the numbers we will be looking at
                                                //O(n^2) worstcase
    {
        for(int i=0;i<arr.Count;i++)
        {
            int j = i;
            while(j>0 && arr[j-1] > arr[j])
            {
                int temp = arr[j];
                arr[j] = arr[j-1];
                arr[j-1] = temp;
                j--;
            }
        }
        return arr;
    }
}
