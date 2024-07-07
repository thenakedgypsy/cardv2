using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{

    public string cardName;
    public string description;

    public virtual void DisplayInfo() //display card details in log
    {
        Debug.Log($"Cardname: {cardName} \n Description: {description}");
    }

    public virtual void Activate() // potentially override this for card activations?
    {
        Debug.Log($"{cardName} Activated");
    }


}
