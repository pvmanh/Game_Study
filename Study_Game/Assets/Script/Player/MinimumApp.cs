using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimumApp : MonoBehaviour
{/*
    ComputerCotroller pComputer;
    public Button App;
    public GameObject App_Parent;
    public Sprite App_Active;
    public Sprite App_Unactive;
    public bool isMax;
    public GameObject Manager;
    public string AppName;
    // Start is called before the first frame update
    void Start()
    {
        App.onClick.AddListener(MinimumApplication);
        pComputer = Manager.GetComponent<ComputerCotroller>();
    }

    void MinimumApplication()
    {
        int iAppOpen = 0;
        for(int g = 0; g < pComputer.NumberApp; g++)
        {
            if(pComputer.StartMenu_Manager[g].isOpen == true)
            {
                iAppOpen ++;
            }
        }
        if(iAppOpen == 1)
        {
            if(isMax == true && App_Parent != null)
            {
                App_Parent.GetComponent<CanvasGroup>().alpha = 0;
                App.GetComponent<Image>().sprite = App_Unactive;
                App_Parent.transform.SetAsFirstSibling();
                isMax = false;
                for(int i = 0; i < pComputer.NumberApp; i++)
                {
                    if(pComputer.StartMenu_Manager[i].App_Name == AppName)
                    {
                        pComputer.StartMenu_Manager[i].isActive = false;
                    }
                }
            }
            else if(isMax == false && App_Parent != null)
            {
                App_Parent.GetComponent<CanvasGroup>().alpha = 1;
                App.GetComponent<Image>().sprite = App_Active;
                App_Parent.transform.SetAsLastSibling();
                isMax = true;
                for(int i = 0; i < pComputer.NumberApp; i++)
                {
                    if(pComputer.StartMenu_Manager[i].App_Name == AppName)
                    {
                        pComputer.StartMenu_Manager[i].isActive = true;
                    }
                }
            }
        }
        else if(iAppOpen > 1)
        {
            if(isMax == true)
            {
                for(int i = 0; i < pComputer.NumberApp; i++)
                {
                    if(pComputer.StartMenu_Manager[i].App_Name == AppName)
                    {
                        if(pComputer.StartMenu_Manager[i].isActive == true)
                        {
                            App_Parent.GetComponent<CanvasGroup>().alpha = 0;
                            App.GetComponent<Image>().sprite = App_Unactive;
                            App_Parent.transform.SetAsFirstSibling();
                            isMax = false;
                            pComputer.StartMenu_Manager[i].isActive = false;
                            for(int j = 0; j < pComputer.NumberApp; j++)
                            {
                                MinimumApp pMiniApp = pComputer.StartMenu_Manager[j].StartMenu_App.GetComponent<MinimumApp>();
                                if(pMiniApp.isMax == true)
                                {
                                    pMiniApp.App_Parent.GetComponent<CanvasGroup>().alpha = 1;
                                    pMiniApp.GetComponent<Image>().sprite = pMiniApp.App_Active;
                                    pMiniApp.App_Parent.transform.SetAsLastSibling();
                                    pComputer.StartMenu_Manager[j].isActive = true;
                                    j = pComputer.NumberApp;
                                }
                            }
                        }
                        else if(pComputer.StartMenu_Manager[i].isActive == false)
                        {
                            App_Parent.GetComponent<CanvasGroup>().alpha = 1;
                            App.GetComponent<Image>().sprite = App_Active;
                            App_Parent.transform.SetAsLastSibling();
                            for(int j = 0; j < pComputer.NumberApp; j++)
                            {
                                MinimumApp pMiniApp = pComputer.StartMenu_Manager[j].StartMenu_App.GetComponent<MinimumApp>();
                                if(pComputer.StartMenu_Manager[j].isActive == true)
                                {
                                    pMiniApp.App_Parent.GetComponent<CanvasGroup>().alpha = 0;
                                    pMiniApp.GetComponent<Image>().sprite = pMiniApp.App_Unactive;
                                    pMiniApp.App_Parent.transform.SetAsFirstSibling();
                                    pComputer.StartMenu_Manager[j].isActive = false;
                                    j = pComputer.NumberApp;
                                }
                            }
                            pComputer.StartMenu_Manager[i].isActive = true;
                        }
                    }
                }
            }
            else if(isMax == false)
            {
                App_Parent.GetComponent<CanvasGroup>().alpha = 1;
                App.GetComponent<Image>().sprite = App_Active;
                App_Parent.transform.SetAsLastSibling();
                isMax = true;
                for(int i = 0; i < pComputer.NumberApp; i++)
                {
                    if(pComputer.StartMenu_Manager[i].App_Name == AppName)
                    {
                        pComputer.StartMenu_Manager[i].isActive = true;
                    }
                    else if(pComputer.StartMenu_Manager[i].App_Name != AppName && pComputer.StartMenu_Manager[i].App_Name != null)
                    {
                        MinimumApp pMiniApp = pComputer.StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>();
                        if(pComputer.StartMenu_Manager[i].isActive == true)
                        {
                            pMiniApp.App_Parent.GetComponent<CanvasGroup>().alpha = 0;
                            pMiniApp.GetComponent<Image>().sprite = pMiniApp.App_Unactive;
                            pMiniApp.App_Parent.transform.SetAsFirstSibling();
                            pComputer.StartMenu_Manager[i].isActive = false;
                        }
                    }
                }
            }
            
            for(int i = 0; i < pComputer.NumberApp; i++)
            {
                if(pComputer.StartMenu_Manager[i].App_Name != AppName)
                {
                    pComputer.StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>().App_Parent.GetComponent<CanvasGroup>().alpha = 0;
                    pComputer.StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>().App.GetComponent<Image>().sprite = pComputer.StartMenu_Manager[i].App_Icon_Unactive;
                    pComputer.StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>().App_Parent.transform.SetAsFirstSibling();
                    pComputer.StartMenu_Manager[i].StartMenu_App.GetComponent<MinimumApp>().isMax = false;
                    pComputer.StartMenu_Manager[i].isActive = false;
                }
            }
            if(isMax == true && App_Parent != null)
            {
                App_Parent.GetComponent<CanvasGroup>().alpha = 0;
                App.GetComponent<Image>().sprite = App_Unactive;
                App_Parent.transform.SetAsFirstSibling();
                isMax = false;
                for(int j = 0; j < pComputer.NumberApp; j++)
                {
                    if(pComputer.StartMenu_Manager[j].App_Name == AppName)
                    {
                        pComputer.StartMenu_Manager[j].isActive = false;
                    }
                }
            }
            else if(isMax == false && App_Parent != null)
            {
                App_Parent.GetComponent<CanvasGroup>().alpha = 1;
                App.GetComponent<Image>().sprite = App_Active;
                App_Parent.transform.SetAsLastSibling();
                isMax = true;
                for(int j = 0; j < pComputer.NumberApp; j++)
                {
                    if(pComputer.StartMenu_Manager[j].App_Name == AppName)
                    {
                        pComputer.StartMenu_Manager[j].isActive = true;
                    }
                }
            }
            
        }
        
    }*/
}
