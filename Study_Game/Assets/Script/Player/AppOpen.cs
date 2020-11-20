using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AppOpen : MonoBehaviour//, IPointerDownHandler
{/*
    ComputerCotroller pComputer;
    MinimumApp pMini;
    [Header("App Setting")]
    public GameObject App;
    public GameObject App_Open;
    public GameObject App_Parent;
    public GameObject ManagerComputer;
    public Sprite App_Icon_Active;
    public Sprite App_Icon_Unactive;
    public bool isOpen;
    private void Awake() {
        pComputer = ManagerComputer.GetComponent<ComputerCotroller>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(eventData.clickCount == 2)
        {
            if(isOpen == false)
            {
                for(int i = 0; i < pComputer.NumberApp; i++)
                {
                    if(pComputer.StartMenu_Manager[i].isOpen == false)
                    {
                        var App_ = Instantiate(App_Open, App_Parent.transform);
                        pComputer.StartMenu_Manager[i].StartMenu_App.GetComponent<Image>().sprite = App_Icon_Active;
                        pComputer.StartMenu_Manager[i].isOpen = true;
                        pComputer.StartMenu_Manager[i].App_Name = App.name;
                        pComputer.StartMenu_Manager[i].App_Icon_Active = App_Icon_Active;
                        pComputer.StartMenu_Manager[i].App_Icon_Unactive = App_Icon_Unactive;
                        for(int j = 0; j < pComputer.NumberApp; j++)
                        {
                            if(pComputer.StartMenu_Manager[j].isActive == true)
                            {
                                pComputer.StartMenu_Manager[j].isActive = false;
                            }
                        }
                        pComputer.StartMenu_Manager[i].isActive = true;
                        isOpen = true;

                        pComputer.StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>().App_Parent = App_;
                        pComputer.StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>().App_Active = App_Icon_Active;
                        pComputer.StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>().App_Unactive = App_Icon_Unactive;
                        pComputer.StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>().isMax = true;
                        pComputer.StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>().AppName = App.name;

                        i = pComputer.NumberApp;
                    }
                }
            }
            eventData.clickCount = 0;
        }
    }*/
}
