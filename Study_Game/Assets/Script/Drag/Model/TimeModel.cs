using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class TimeModel 
{
    [Header("Timer Puzzle Setting")]
    public TextMeshProUGUI txt_time;
    [HideInInspector] public float hour;
    [HideInInspector] public float minute;
    [HideInInspector] public float second;
    [HideInInspector] public float timeToDisplay;
    [HideInInspector] public string timegget;
}
