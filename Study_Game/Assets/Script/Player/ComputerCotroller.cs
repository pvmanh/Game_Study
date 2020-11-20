using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ComputerCotroller : MonoBehaviour
{/*
    [Header("On-Off Setting")]
    public GameObject Manager;
    public Image Logo;
    public GameObject LoadingObject;
    public TextMeshProUGUI ShuttingMessage;
    public Sprite TurnOnSprite;
    public Sprite TurnOffSprite;
    [System.NonSerialized]
    public Animator Loading;
    RawImage ColorManager;
    public bool isTurnOn = false;
    [System.Serializable]
    public struct Menu_App
    {
        [SerializeField] 
        public GameObject StartMenu_App;
        public Sprite App_Icon_Active;
        public Sprite App_Icon_Unactive;
        public string App_Name;
        public bool isOpen;
        public bool isActive;
    }
    [Header("App Setting")]
    public Menu_App[] StartMenu_Manager;
    public int NumberApp;
    // Start is called before the first frame update
    void Start()
    {
        Loading = Manager.GetComponent<Animator>();
        ColorManager = Manager.GetComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        TurnOn();
        SwapAppPoisition();
    }

    void TurnOn()
    {
        if(isTurnOn == true)
        {
            Loading.SetBool("isTurnOn", true);
            Manager.transform.SetAsLastSibling(); 
            if(Loading.GetCurrentAnimatorStateInfo(0).IsName("Loading"))
            {
                if(Loading.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
                {
                    Logo.gameObject.SetActive(true);
                    LoadingObject.SetActive(true);
                    ShuttingMessage.gameObject.SetActive(false);
                    Logo.sprite = TurnOnSprite;
                }
                else if(Loading.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
                {
                    ColorManager.color = new Color32(0,0,0,0);
                    Manager.transform.SetAsFirstSibling();  
                }
            }
        }
        else if(isTurnOn == false)
        {
            Loading.SetBool("isTurnOn", false);
            if(Loading.GetCurrentAnimatorStateInfo(0).IsName("Shutting-Down"))
            {
                if(Loading.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
                {
                    Manager.transform.SetAsLastSibling(); 
                    ColorManager.color = new Color32(0,0,0,255);
                    Logo.sprite = TurnOffSprite;
                    ShuttingMessage.gameObject.SetActive(true);
                }
            }
            else if(Loading.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                Logo.gameObject.SetActive(false);
                LoadingObject.SetActive(false);
                ShuttingMessage.gameObject.SetActive(false);
            }
        }
    }

    void SwapAppPoisition()
    {
        for(int i = (NumberApp-1); i > 0; i--)
        {
            if( StartMenu_Manager[i].isOpen == true)
            {
                if(StartMenu_Manager[i-1].isOpen == false)
                {
                    StartMenu_Manager[i-1].App_Name = StartMenu_Manager[i].App_Name;
                    StartMenu_Manager[i-1].App_Icon_Active = StartMenu_Manager[i].App_Icon_Active;
                    StartMenu_Manager[i-1].App_Icon_Unactive = StartMenu_Manager[i].App_Icon_Unactive;
                    StartMenu_Manager[i-1].isOpen = StartMenu_Manager[i].isOpen;
                    StartMenu_Manager[i-1].isActive = StartMenu_Manager[i].isActive;

                    StartMenu_Manager[i-1].StartMenu_App.GetComponent<MinimumApp>().App_Parent = StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>().App_Parent;
                    StartMenu_Manager[i-1].StartMenu_App.GetComponent<MinimumApp>().App_Active = StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>().App_Active;
                    StartMenu_Manager[i-1].StartMenu_App.GetComponent<MinimumApp>().App_Unactive = StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>().App_Unactive;
                    StartMenu_Manager[i-1].StartMenu_App.GetComponent<MinimumApp>().isMax = StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>().isMax;

                    StartMenu_Manager[i].App_Name = null;
                    StartMenu_Manager[i].App_Icon_Active = null;
                    StartMenu_Manager[i].App_Icon_Unactive = null;
                    StartMenu_Manager[i].isOpen = false;
                    StartMenu_Manager[i].isActive = false;


                    StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>().App_Parent = null;
                    StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>().App_Active = null;
                    StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>().App_Unactive = null;
                    StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>().isMax = false;
                }
            }
        }
    }*/
}
