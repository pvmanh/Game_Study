using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuDragController : MonoBehaviour
{
    public MenuModel menuData;
    //hien bang nhap ten khi ten rong
    void Start()
    {
        if(menuData.info_surrender != null)
            menuData.ZoomIn_alert_end = menuData.info_surrender.GetComponent<Animator>();

        menuData.ZoomIn_menu_drag = menuData.menu_drag.GetComponent<Animator>();

        menuData.isMenuActive = false;
    }
    //xu ly hien menu khi bam Esc
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
    //Hien bang nhap ten
    public void ButtonSurrender()
    {
        Menu.SetActiveMenuTrue(menuData.hide_puzzle, menuData.info_surrender);
        StartCoroutine(Menu.WaitAnimation(menuData.ZoomIn_alert_end, menuData.info_surrender, "isAlert", menuData.timeDelay, 1, true)); 
    }
    //Xu ly hien bang nhap ten => hien da disable
    public void ButtonSurrenderYes()
    {
        menuData.PlayerNamePanel.SetActive(true);
    }
    //xu ly thoat thong bao
    public void ButtonSurrenderNo()
    {
        Menu.SetActiveMenuFalse(menuData.hide_puzzle, menuData.info_surrender);
    }
    //Hien menu chon => pause
    public void ButtonMenuDrag()
    {
        Menu.SetActiveMenuTrue(menuData.hide_puzzle, menuData.menu_drag);
        StartCoroutine(Menu.WaitAnimation(menuData.ZoomIn_menu_drag, menuData.menu_drag, "isMenu", menuData.timeDelay, 1, true));
    }
    //Xu ly tat menu chon
    public void ButtonMenuPrev()
    {
        Menu.SetActiveMenuFalse(menuData.hide_puzzle, menuData.menu_drag);
        menuData.isMenuActive = false;

    }
    //vao cai dat
    public void ButtonMenuOption()
    {
        menuData.OptionMenu.SetActive(true);
    }
    //thoat cai dat
    public void ButtonExitMenuOption()
    {
        menuData.OptionMenu.SetActive(false);
    }
    //Xu ly nut thoat quay ve menu chinh
    public void ButtonMenuExit()
    {
        Menu.LoadScene("Main_Menu");
    }
    
}
