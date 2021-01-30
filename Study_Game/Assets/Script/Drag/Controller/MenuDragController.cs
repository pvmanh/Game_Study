using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuDragController : MonoBehaviour
{
    private static readonly string FirstPlay_Name_Box = "FirstPlay_Name_Box";
    private static readonly string Student_Name = "Student_Name";
    private static readonly string Student_Class = "Student_Class";
    private int firstPlayInt;
    public GameObject Game_Data_Main;
    public MenuModel menuData;
    public GameObject Option_btn;
    public GameObject pre_btn;
    public GameObject pre_btn_timeScale;
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
    //Luu ten va lop hoc sinh
    public void SetNamePlayerPrefs()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay_Name_Box);
        if(Game_Data_Main.GetComponent<ObjectArea>() != null)
        {
            if(firstPlayInt == 0)
            {
                PlayerPrefs.SetString(Student_Name, Game_Data_Main.GetComponent<ObjectArea>().objectData.str_name);
                PlayerPrefs.SetString(Student_Class, Game_Data_Main.GetComponent<ObjectArea>().objectData.str_class);
                PlayerPrefs.SetInt(FirstPlay_Name_Box, -1);
            } 
            else if(firstPlayInt == -1)
            {
                PlayerPrefs.SetString(Student_Name, Game_Data_Main.GetComponent<ObjectArea>().objectData.str_name);
                PlayerPrefs.SetString(Student_Class, Game_Data_Main.GetComponent<ObjectArea>().objectData.str_class);
                PlayerPrefs.SetInt(FirstPlay_Name_Box, -1);
            }
        }
        else if(Game_Data_Main.GetComponent<LoadPuzzle>() != null)
        {
            if(firstPlayInt == 0)
            {
                PlayerPrefs.SetString(Student_Name, Game_Data_Main.GetComponent<LoadPuzzle>().puzzleData.str_name);
                PlayerPrefs.SetString(Student_Class, Game_Data_Main.GetComponent<LoadPuzzle>().puzzleData.str_class);
                PlayerPrefs.SetInt(FirstPlay_Name_Box, -1);
            } 
            else if(firstPlayInt == -1)
            {
                PlayerPrefs.SetString(Student_Name, Game_Data_Main.GetComponent<LoadPuzzle>().puzzleData.str_name);
                PlayerPrefs.SetString(Student_Class, Game_Data_Main.GetComponent<LoadPuzzle>().puzzleData.str_class);
                PlayerPrefs.SetInt(FirstPlay_Name_Box, -1);
            }
        }
        else if(Game_Data_Main.GetComponent<Typer>() != null)
        {
            if(firstPlayInt == 0)
            {
                PlayerPrefs.SetString(Student_Name, Game_Data_Main.GetComponent<Typer>().str_name);
                PlayerPrefs.SetString(Student_Class, Game_Data_Main.GetComponent<Typer>().str_class);
                PlayerPrefs.SetInt(FirstPlay_Name_Box, -1);
            } 
            else if(firstPlayInt == -1)
            {
                PlayerPrefs.SetString(Student_Name, Game_Data_Main.GetComponent<Typer>().str_name);
                PlayerPrefs.SetString(Student_Class, Game_Data_Main.GetComponent<Typer>().str_class);
                PlayerPrefs.SetInt(FirstPlay_Name_Box, -1);
            }
        }
        else if(Game_Data_Main.GetComponent<WordDoc>() != null)
        {
            if(firstPlayInt == 0)
            {
                PlayerPrefs.SetString(Student_Name, Game_Data_Main.GetComponent<WordDoc>().str_name);
                PlayerPrefs.SetString(Student_Class, Game_Data_Main.GetComponent<WordDoc>().str_class);
                PlayerPrefs.SetInt(FirstPlay_Name_Box, -1);
            } 
            else if(firstPlayInt == -1)
            {
                PlayerPrefs.SetString(Student_Name, Game_Data_Main.GetComponent<WordDoc>().str_name);
                PlayerPrefs.SetString(Student_Class, Game_Data_Main.GetComponent<WordDoc>().str_class);
                PlayerPrefs.SetInt(FirstPlay_Name_Box, -1);
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
    public void ShowEscButton()
    {
        if(menuData.isMenuActive == false)
        {
            ButtonMenuDrag();
            menuData.isMenuActive = true;
        }
    }
    //vao cai dat with timescale
    public void ButtonMenuOptionTimeScale()
    {
        Time.timeScale = 0;
        menuData.hide_puzzle.SetActive(true);
        menuData.OptionMenu.SetActive(true);
        pre_btn_timeScale.SetActive(true);
        menuData.isMenuActive = true;
        Option_btn.SetActive(false);
    }
    public void InputNameShowOption(TMP_InputField text_name)
    {
        if(text_name.text != "")
        {
            Option_btn.SetActive(true);
        }
    }
    //thoat cai dat with timescale
    public void ButtonExitMenuOptionTimeScale()
    {
        Time.timeScale = 1;
        
        menuData.hide_puzzle.SetActive(false);
        menuData.OptionMenu.SetActive(false);
        pre_btn_timeScale.SetActive(false);
        menuData.isMenuActive = false;
        Option_btn.SetActive(true);
    }
    //vao cai dat
    public void ButtonMenuOption()
    {
        pre_btn.SetActive(true);
        menuData.OptionMenu.SetActive(true);
    }
    //thoat cai dat
    public void ButtonExitMenuOption()
    {
        pre_btn.SetActive(false);
        menuData.OptionMenu.SetActive(false);
    }
    //Xu ly nut thoat quay ve menu chinh
    public void ButtonMenuExit()
    {
        Menu.LoadScene("Main_Menu");
    }
    
}
