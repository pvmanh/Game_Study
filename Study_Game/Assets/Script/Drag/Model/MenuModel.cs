using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MenuModel 
{
    [Header("Main Menu Setting")]
    public GameObject menu_drag;
    public GameObject hide_puzzle;
    public GameObject info_surrender;
    public GameObject PlayerNamePanel;
    //public GameObject alert_end;
    public Animator ZoomIn_menu_drag;
    public Animator ZoomIn_alert_end;
    public float timeDelay = 1f;
    public bool isMenuActive;
}
