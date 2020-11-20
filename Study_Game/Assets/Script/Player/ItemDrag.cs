using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;

public class ItemDrag : MonoBehaviour
{/*
    PlayerController pControl;
    [Header("Item Setting")]
    public GameObject item;
    [Header("Item Hand Setting")]
    public GameObject VisibleItem;
    public GameObject tempParent;
    public Transform guide;
    private string VisibleHandle;
    [Header("Item Place Setting")]
    public GameObject Parentplace;
    public Transform guidePlace;
    public bool isTruePlace = false;
    //public enum value_PC { Monitor, Case, Keyboard, Mouse}
    //public value_PC dropValue;
    //private float Double_click_time = 0.2f;
    //private float lastClickTime;
    [Header("Item Image Setting")]
    public Image ImgPick;
    public Sprite SpritePick;
    public Sprite VisibleSprite;
    // Start is called before the first frame update
    void Start()
    {
        pControl = Camera.main.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        DoubleClickPick();
        DoubleClickUnPick();
    }
    
    private void DoubleClickPick()
    {
        //if(Input.GetMouseButtonDown(0))
        //{
            //float timeSinceClick = Time.time - lastClickTime;
            //if(timeSinceClick <= Double_click_time)
            //{
                if(pControl.isPickup == false)
                {
                    if(pControl.colliPC == item.tag)
                    {
                        foreach (Transform child in item.GetComponentsInChildren<Transform>(true))  
                        {
                            child.gameObject.layer = 8;
                        }
                        item.transform.SetParent(guide);
                        item.transform.localPosition = Vector3.zero;
                        item.transform.localRotation = Quaternion.Euler(Vector3.zero);
                        item.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                        //item.transform.parent = tempParent.transform;
                        ImgPick.sprite = SpritePick;
                        ImgPick.preserveAspect = true;
                        ImgPick.useSpriteMesh = true;
                        VisibleItem.SetActive(true);
                        VisibleHandle = VisibleItem.tag;
                        pControl.isPickup = true;
                        //pControl.colliPC = null;
                    }                    
                }
            //}
            //lastClickTime = Time.time;
        //}
    }
    
    private void DoubleClickUnPick() 
    {
        //if(Input.GetMouseButtonDown(0))
        //{
            //float timeSinceClick = Time.time - lastClickTime;
            //if(timeSinceClick <= Double_click_time)
            //{
                if(pControl.isPickup == true)
                {
                    if(pControl.colliPCVis == VisibleHandle)
                    {
                        foreach (Transform child in item.GetComponentsInChildren<Transform>(true))  
                        {
                            child.gameObject.layer = 0;
                        }
                        item.transform.SetParent(guidePlace);
                        item.transform.localPosition = Vector3.zero;
                        item.transform.localRotation = Quaternion.Euler(Vector3.zero);
                        item.transform.localScale = Vector3.one;
                        ImgPick.sprite = VisibleSprite;
                        ImgPick.preserveAspect = false;
                        ImgPick.useSpriteMesh = false;
                        VisibleItem.SetActive(false);
                        VisibleHandle = null;
                        pControl.isPickup = false;
                        //pControl.colliPC = null;
                        isTruePlace = true;
                        item.GetComponent<ItemDrag>().enabled = false;
                    }
                }
            //}
            //lastClickTime = Time.time;
        //}
    }*/
}
