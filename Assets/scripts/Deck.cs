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

   bool containsCard(int target, List<int> cardList) //binary search because why not!
   {
       int low = 0;
       int high = cardList.Count - 1;
       while(low <= high)
       {
           int middle = low + high / 2;
           if(cardList[middle] == target)
           {
               return true;
           }
           else
           {
               if(cardList[middle] < target)
               {
                   low = middle + 1;
               }
               if(cardList[middle] > target)
               {
                   high = middle - 1;
               }
           }
       }
       return false;
   }


//IM GOING TO BASH OUT A LOAD OF SORTING FUNCTIONS - most wont be used but its good practice:
    List<int> sortCardsBubble(List<int> cardlist) //** rudimentary sort for now **//** O(n^2)**
    {                                               
        bool swapping = true; //set to true to get things started
        while(swapping)//checks if a swap has been made this loop, if it has, the list is potentially unsorted
        {                                                           //if it happens we go to return
            swapping = false;  //turns it off at the start of the loop as potnetially we are not swapping
            for(int i = 1; i < cardlist.Count; i++) //iterates through our card list once.
            {
            if(cardlist[i-1] > cardlist[i]) //if index to the right is bigger we need to swap the positions 
            {
                int temp = cardlist[i]; //temp variable to hold right position
                cardlist[i] = cardlist[i-1]; //set right position to the left position
                cardlist[i-1] = temp; //set the left position to the temp(previously right) position
                swapping = true; //we have made a swap this iteration so set this to true as the list... 
            }                                                     //was unsorted this pass. Pass again. 
            }
        }
        return cardlist; //return the now sorted list
    }

    List<int> sortCardsMerge(List<int> arr) //O(n log n)? 
    {                                       //realisitcally am i going to be sorting large numbers 
                                            //of cards enough to justify this? no. Was it fun? Yes.
        if(arr.Count < 2)    // single element gets pushed back to previous level
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

    List<int> cardsInsertionSort(List<int> arr) 
                                                
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

    List<int> cardQuickSort(List<int> arr, int low, int high)
    {
        if(low < high)
        {
            int idx = cardPartitionSort(arr,low,high);
            cardQuickSort(arr,low,idx-1);
            cardQuickSort(arr,idx+1,high);
        }
        return arr;
    }

    int cardPartitionSort(List<int> arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low;
        for(int j = low; j < high; j++)
        {
            if(arr[j] < pivot)
            {
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
                i++;
            }
        }
        int temp2 = arr[i];
        arr[i] = arr[high];
        arr[high] = temp2;
        return i;
    }




}
