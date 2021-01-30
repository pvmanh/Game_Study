using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MainMenuController : MonoBehaviour
{
    private static readonly string FirstPlay_Name_Box = "FirstPlay_Name_Box";
    public TMP_InputField Name_input;
    public GameObject Title_Game;
    [Header("Main Menu Setting")]
    public GameObject Main_Menu;
    public GameObject Name_Box;
    public GameObject Sub_Menu;
    public GameObject Option_Menu;
    public GameObject Rank_Menu;
    public GameObject Info;
    Animator ZoomIn_Main;
    Animator ZoomIn_Name_Box;
    Animator ZoomIn_Sub;
    Animator ZoomIn_Option;
    Animator ZoomIn_Info;
    Animator ZoomIn_Rank;
    float timeDelay = 1f;
    public Sprite SprSelected;
    public GameObject Parent_Menu_Title;
    public GameObject Parent_Menu_Sub_Selected;
    public int indexScene;
    public GameObject LoadingSceneObj;
    LoadingScene iLoading;
    public List<Image> Menu_Title_Selected;
    public List<GameObject> Menu_Sub_Selected;
    public List<GameObject> Menu_Sub_Child_Selected;
    //Xu ly thong tin lan dau
    public void Awake()
    {   
        Time.timeScale = 1;
        iLoading = LoadingSceneObj.GetComponent<LoadingScene>();

        ZoomIn_Main = Main_Menu.GetComponent<Animator>();
        ZoomIn_Name_Box = Name_Box.GetComponent<Animator>();
        ZoomIn_Sub = Sub_Menu.GetComponent<Animator>();
        ZoomIn_Option = Option_Menu.GetComponent<Animator>();
        ZoomIn_Info = Info.GetComponent<Animator>();
        ZoomIn_Rank = Rank_Menu.GetComponent<Animator>();

        Menu_Title_Selected = Menu.AddMenuTitle(Parent_Menu_Title);
        Menu_Sub_Selected = Menu.AddMenuSubSelect(Parent_Menu_Sub_Selected);

        for(int i = 0; i < Menu_Sub_Selected.Count; i++)
        {
            Menu_Sub_Child_Selected.AddRange(Menu.AddMenuSubSelect(Menu_Sub_Selected[i]));
        }
    }
    //Vao chon loai tro choi
    public void EnterSubMenu()
    {
        //StartCoroutine(Menu.WaitAnimation(ZoomIn_Main, Main_Menu, "ZoomIn", timeDelay, 0, false));
        
        Menu_Title_Selected[0].GetComponent<MainMenuSelected>().isSelected = true;
        Menu_Title_Selected[0].GetComponent<Image>().sprite = Menu_Title_Selected[0].GetComponent<MainMenuSelected>().SprSelected;

        Main_Menu.SetActive(false);

        Sub_Menu.SetActive(true);
        StartCoroutine(Menu.WaitAnimation(ZoomIn_Sub, Sub_Menu, "ZoomOut", timeDelay, 1, true));
    }
    //Vao chon nhap ten lai
    public void EnterNameBox()
    {
        Main_Menu.SetActive(false);

        Name_Box.SetActive(true);
        StartCoroutine(Menu.WaitAnimation(ZoomIn_Name_Box, Name_Box, "isAlert", timeDelay, 1, true));
    }
    //vao cai dat
    public void EnterOption()
    {
        Main_Menu.SetActive(false);

        Option_Menu.SetActive(true);
        StartCoroutine(Menu.WaitAnimation(ZoomIn_Option, Option_Menu, "ZoomOut", timeDelay, 1, true));
    }
    //vao infomation
    public void EnterInfo()
    {
        Main_Menu.SetActive(false);

        Info.SetActive(true);
        StartCoroutine(Menu.WaitAnimation(ZoomIn_Info, Info, "ZoomOut", timeDelay, 1, true));
    }
    //Xem BXH
    public void EnterRank()
    {
        Main_Menu.SetActive(false);

        Rank_Menu.SetActive(true);
        StartCoroutine(Menu.WaitAnimation(ZoomIn_Rank, Rank_Menu, "ZoomOut", timeDelay, 1, true));
    }
    //Thoat game
    public void EnterExit()
    {
        PlayerPrefs.SetInt(FirstPlay_Name_Box, 0);
        Application.Quit();
    }
    //Thoat menu chon tro choi ve menu chinh
    public void ReturnMainMenu()
    {
        //StartCoroutine(Menu.WaitAnimation(ZoomIn_Sub, Sub_Menu, "ZoomIn", timeDelay, 0, false));

        for(int i = 0; i < Menu_Title_Selected.Count; i++)
        {
            Menu_Title_Selected[i].GetComponent<Image>().sprite = Menu_Title_Selected[i].GetComponent<MainMenuSelected>().SprUnSelected;
            Menu_Title_Selected[i].GetComponent<MainMenuSelected>().isSelected = false;
        } 

        for(int i = 0; i < Menu_Sub_Child_Selected.Count; i++)
        {
            Menu_Sub_Child_Selected[i].GetComponent<Image>().color = new Color32(100, 100, 100, 255);
            Menu_Sub_Child_Selected[i].GetComponent<MenuSubChildSelect>().isSelected = false;
        } 

        Sub_Menu.SetActive(false);

        Main_Menu.SetActive(true);
        StartCoroutine(Menu.WaitAnimation(ZoomIn_Main, Main_Menu, "ZoomOut", timeDelay, 1, true));
    }
    //Tat doi ten
    public void ReturnOutNameBox(int index_number)
    {
        if(index_number == 0)
        {
            Name_Box.SetActive(false);

            Main_Menu.SetActive(true);
            StartCoroutine(Menu.WaitAnimation(ZoomIn_Main, Main_Menu, "ZoomOut", timeDelay, 1, true));
        }
        else if(index_number == 1)
        {
            if(Name_input.text != "")
            {
                Name_Box.SetActive(false);

                Main_Menu.SetActive(true);
                StartCoroutine(Menu.WaitAnimation(ZoomIn_Main, Main_Menu, "ZoomOut", timeDelay, 1, true));
                Title_Game.SetActive(true);
            }
        }
    }
    //Tat cai dat
    public void ReturnOutOption()
    {
        Option_Menu.SetActive(false);

        Main_Menu.SetActive(true);
        StartCoroutine(Menu.WaitAnimation(ZoomIn_Main, Main_Menu, "ZoomOut", timeDelay, 1, true));
    }
    //tat BXH
    public void ReturnOutRank()
    {
        Rank_Menu.SetActive(false);

        Main_Menu.SetActive(true);
        StartCoroutine(Menu.WaitAnimation(ZoomIn_Main, Main_Menu, "ZoomOut", timeDelay, 1, true));
    }
    //tat infomation
    public void ReturnOutInfo()
    {
        Info.SetActive(false);

        Main_Menu.SetActive(true);
        StartCoroutine(Menu.WaitAnimation(ZoomIn_Main, Main_Menu, "ZoomOut", timeDelay, 1, true));
    }
    //Load man
    public void LoadLevel ()
    {
        if(indexScene != 0)
        {
            StartCoroutine(Menu.LoadAsynchronously(indexScene, iLoading.loadinggScreen, iLoading.slider, iLoading.progressText));
            Time.timeScale=1;
        }
    }
}
