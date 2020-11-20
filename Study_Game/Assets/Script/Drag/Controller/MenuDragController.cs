using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuDragController : MonoBehaviour
{
    public PuzzleModel puzzleData;
    public MenuModel menuData;

    void Start()
    {
        menuData.ZoomIn_alert_end = menuData.info_surrender.GetComponent<Animator>();
        menuData.ZoomIn_menu_drag = menuData.menu_drag.GetComponent<Animator>();
        menuData.isMenuActive = false;
    }

    void Update()
    {
        if(menuData.isMenuActive == false)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                ButtonMenuDrag();
                menuData.isMenuActive = true;
            }
        }
    }

    public void ButtonRandom()
    {
        Puzzle.RandomPuzzlePosition(puzzleData);
    }

    public void ButtonSurrender()
    {
        Menu.SetActiveMenuTrue(menuData.hide_puzzle, menuData.info_surrender);
        StartCoroutine(Menu.WaitAnimation(menuData.ZoomIn_alert_end, menuData.info_surrender, "isAlert", menuData.timeDelay, 1, true)); 
    }
    public void ButtonSurrenderYes()
    {
        menuData.PlayerNamePanel.SetActive(true);
    }
    public void ButtonSurrenderNo()
    {
        Menu.SetActiveMenuFalse(menuData.hide_puzzle, menuData.info_surrender);
    }
    public void ButtonMenuDrag()
    {
        Menu.SetActiveMenuTrue(menuData.hide_puzzle, menuData.menu_drag);
        StartCoroutine(Menu.WaitAnimation(menuData.ZoomIn_menu_drag, menuData.menu_drag, "isMenu", menuData.timeDelay, 1, true));
    }
    public void ButtonMenuPrev()
    {
        Menu.SetActiveMenuFalse(menuData.hide_puzzle, menuData.menu_drag);
        menuData.isMenuActive = false;

    }
    public void ButtonMenuExit()
    {
        Menu.LoadScene("Main_Menu");
    }
    
}
