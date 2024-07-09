using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PathCard : MonoBehaviour
{
    public PathCardData data;
    new public string name;
    public int cardNumber;
    public string cardActivateText;
    //public string[] choiceTexts;
    //public string[] choiceOutcomes;
    void Start()
    {
         name = data.cardTitle;
         cardActivateText = data.cardDescription;
       //  cardNumber = data.cardNumber;
        // choiceTexts = data.choiceTexts;
    }

    

}
