using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScreen : MonoBehaviour
{/*
    PlayerController pController;
    ItemDrag pItemCase;
    ItemDrag pItemMonitor;
    ItemDrag pItemKeyboard;
    ItemDrag pItemMouse;
    ComputerCotroller pComputerController;
    [Header("Player Setting")]
    public Transform rayTarget;
    public float distance = 1.5f;
    [Header("Object Setting")]
    public GameObject pCase;
    public GameObject pMonitor;
    public GameObject pKeyboard;
    public GameObject pMouse;
    public GameObject pManagerPc;
    [Header("Canvas Setting")]
    public GameObject KeyPass;
    public GameObject BG;
    [Header("Monitor Setting")]
    public GameObject CubeMonitor;
    private Canvas ZoomScreen;
    private Canvas HideScreen;
    private bool onScreen = false;
    private bool cMonitor = false;
    // Start is called before the first frame update
    void Start()
    {
        pController = Camera.main.GetComponent<PlayerController>();
        ZoomScreen = KeyPass.GetComponent<Canvas>();
        HideScreen = BG.GetComponent<Canvas>();
        pItemCase = pCase.GetComponent<ItemDrag>();
        pItemMonitor = pMonitor.GetComponent<ItemDrag>();
        pItemKeyboard = pKeyboard.GetComponent<ItemDrag>();
        pItemMouse = pMouse.GetComponent<ItemDrag>();
        pComputerController = pManagerPc.GetComponent<ComputerCotroller>();
    }

    // Update is called once per frame
    void Update()
    {
        TurnOnScreen();
        ChangeScreenStyle();
        CloseScreenStyle();
    }

    void TurnOnScreen()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Vector3 direction = Camera.main.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit,distance))
            {
                if(onScreen == false)
                {
                    if (hit.collider.tag == "Case")
                    {
                        if(cMonitor == false && pItemCase.isTruePlace == true && pItemMonitor.isTruePlace == true && pItemKeyboard.isTruePlace == true && pItemMouse.isTruePlace == true)
                        {
                            CubeMonitor.SetActive(true);
                            pComputerController.isTurnOn = true;
                            cMonitor = true;
                        }
                        else if(cMonitor == true && pItemCase.isTruePlace == true && pItemMonitor.isTruePlace == true && pItemKeyboard.isTruePlace == true && pItemMouse.isTruePlace == true)
                        {
                            pComputerController.isTurnOn = false;
                            if(pComputerController.Loading.GetCurrentAnimatorStateInfo(0).IsName("idle"))
                            {
                                CubeMonitor.SetActive(false);
                                cMonitor = false;
                            }
                            
                        }
                    }
                }
            }
        }
    }
    
    void ChangeScreenStyle()
    {
        RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 direction = Camera.main.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(rayTarget.transform.position,Camera.main.transform.forward, out hit,distance))
            {
                if (hit.collider.tag == "Monitor")
                {
                    if(onScreen == false && cMonitor == true)
                    {
                        ZoomScreen.renderMode = RenderMode.ScreenSpaceOverlay;
                        HideScreen.renderMode = RenderMode.WorldSpace;
                        //BG.SetActive(false);  
                        Cursor.lockState = CursorLockMode.None;
                        pController.CanMove = false;
                        onScreen = true;
                    }
                }
            }
        }
    }

    void CloseScreenStyle()
    {
        if(Input.GetKey(KeyCode.Space) && onScreen == true)
        {
            ZoomScreen.renderMode = RenderMode.ScreenSpaceCamera;
            HideScreen.renderMode = RenderMode.ScreenSpaceOverlay;
            //BG.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            pController.CanMove = true;
            onScreen = false;
        }
    }*/
}
