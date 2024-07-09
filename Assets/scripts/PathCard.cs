using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCardActual : MonoBehaviour
{
    public PathCardData data;
    public string name;
    public string cardDescription;
    public string[] choiceTexts;
    //public string[] choiceOutcomes;
    void Start()
    {
         name = data.cardTitle;
         cardDescription = data.cardDescription;
         choiceTexts = data.choiceTexts;
    }


}
