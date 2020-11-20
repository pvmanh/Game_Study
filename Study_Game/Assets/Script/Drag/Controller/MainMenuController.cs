using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("Main Menu Setting")]
    public GameObject Main_Menu;
    public GameObject Sub_Menu;
    Animator ZoomIn_Main;
    Animator ZoomIn_Sub;
    float timeDelay = 1f;
    
    public void Awake()
    {
        ZoomIn_Main = Main_Menu.GetComponent<Animator>();
        ZoomIn_Sub = Sub_Menu.GetComponent<Animator>();
    }
    public void EnterSubMenu()
    {
        //StartCoroutine(Menu.WaitAnimation(ZoomIn_Main, Main_Menu, "ZoomIn", timeDelay, 0, false));
        Main_Menu.SetActive(false);

        Sub_Menu.SetActive(true);
        StartCoroutine(Menu.WaitAnimation(ZoomIn_Sub, Sub_Menu, "ZoomOut", timeDelay, 1, true));
    }
    public void EnterOption()
    {

    }
    public void EnterExit()
    {
        Application.Quit();
    }

    public void ReturnMainMenu()
    {
        //StartCoroutine(Menu.WaitAnimation(ZoomIn_Sub, Sub_Menu, "ZoomIn", timeDelay, 0, false));
        Sub_Menu.SetActive(false);

        Main_Menu.SetActive(true);
        StartCoroutine(Menu.WaitAnimation(ZoomIn_Main, Main_Menu, "ZoomOut", timeDelay, 1, true));
    }
}
