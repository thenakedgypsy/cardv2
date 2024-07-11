using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Path Card", menuName = "Cards/Path Card")]
public class PathCardData : ScriptableObject
{
    public string cardTitle;
    public int cardNumber;
    public string cardDescription;
    public string[] choiceTexts;
    public string[] choiceOutcomes;
    public Sprite cardSprite;
    
}
