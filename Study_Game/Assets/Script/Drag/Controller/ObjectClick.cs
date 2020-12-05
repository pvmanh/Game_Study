using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject parentArea;
    public GameObject parent;
    public GameObject SFX;
    Animator Flip;
    void Start()
    {
        Flip = GetComponentInParent<Animator>();
        parentArea = GameObject.Find("Area");
        SFX = GameObject.Find("SFX");
    }
    //Xu ly event cac loai click lat hinh theo cac level
    public void OnPointerClick(PointerEventData eventData)
    {
        int clickCount = eventData.clickCount; 
        int level = parentArea.GetComponent<ObjectArea>().objectData.Level;
        ObjectArea objData = parentArea.GetComponent<ObjectArea>();

        if (clickCount == 1)
        {
            //Xu ly chuot trai cho level <= x1
            if(level <= objData.x1)
            {
                if(parentArea.GetComponent<ObjectArea>().IDSelected.Count < 2)
                {
                    if(GetComponentInParent<ObjectInfo>().isSelected == false)
                    {
                        if (eventData.button == PointerEventData.InputButton.Left)
                        {
                            if (parentArea.GetComponentInParent<ObjectArea>().IDSelected.Count < 2)
                            {
                                parentArea.GetComponent<ObjectArea>().IDSelected.Add(parent);
                                SFX.GetComponent<AudioManager>().PlayClipButton(SFX.GetComponent<AudioManager>().soundEffectsAudio[1]);
                                Flip.SetTrigger("isFlip");
                            }
                            if (parentArea.GetComponentInParent<ObjectArea>().IDSelected.Count >= 2)
                            {
                                parentArea.GetComponent<ObjectArea>().isCheckSelected = true;
                            }
                            GetComponentInParent<ObjectInfo>().isSelected = true;
                        }
                    }
                }
            }
            //Xu ly chuot phai cho level tu x2 > x3
            else if(level >= objData.x2 && level < objData.x3)
            {
                if(parentArea.GetComponent<ObjectArea>().IDSelected.Count < 2)
                {
                    if(GetComponentInParent<ObjectInfo>().isSelected == false)
                    {
                        if (eventData.button == PointerEventData.InputButton.Right)
                        {
                            if (parentArea.GetComponentInParent<ObjectArea>().IDSelected.Count < 2)
                            {
                                parentArea.GetComponent<ObjectArea>().IDSelected.Add(parent);
                                SFX.GetComponent<AudioManager>().PlayClipButton(SFX.GetComponent<AudioManager>().soundEffectsAudio[1]);
                                Flip.SetTrigger("isFlip");
                            }
                            if (parentArea.GetComponentInParent<ObjectArea>().IDSelected.Count >= 2)
                            {
                                parentArea.GetComponent<ObjectArea>().isCheckSelected = true;
                            }
                            GetComponentInParent<ObjectInfo>().isSelected = true;
                        }
                    }
                }
            }
            //Xu ly chuot giua cho level tu x4 > x5
            else if(level >= objData.x4 && level < objData.x5)
            {
                if(parentArea.GetComponent<ObjectArea>().IDSelected.Count < 2)
                {
                    if(GetComponentInParent<ObjectInfo>().isSelected == false)
                    {
                        if (eventData.button == PointerEventData.InputButton.Middle)
                        {
                            if (parentArea.GetComponentInParent<ObjectArea>().IDSelected.Count < 2)
                            {
                                parentArea.GetComponent<ObjectArea>().IDSelected.Add(parent);
                                SFX.GetComponent<AudioManager>().PlayClipButton(SFX.GetComponent<AudioManager>().soundEffectsAudio[1]);
                                Flip.SetTrigger("isFlip");
                            }
                            if (parentArea.GetComponentInParent<ObjectArea>().IDSelected.Count >= 2)
                            {
                                parentArea.GetComponent<ObjectArea>().isCheckSelected = true;
                            }
                            GetComponentInParent<ObjectInfo>().isSelected = true;
                        }
                    }
                }
            }
        }
        //Xu ly click doi cho level x6
        else if (clickCount == 2)
        {
            if(level == objData.x6)
            {
                if(parentArea.GetComponent<ObjectArea>().IDSelected.Count < 2)
                {
                    if(GetComponentInParent<ObjectInfo>().isSelected == false)
                    {
                        if (eventData.button == PointerEventData.InputButton.Left)
                        {
                            if (parentArea.GetComponentInParent<ObjectArea>().IDSelected.Count < 2)
                            {
                                parentArea.GetComponent<ObjectArea>().IDSelected.Add(parent);
                                SFX.GetComponent<AudioManager>().PlayClipButton(SFX.GetComponent<AudioManager>().soundEffectsAudio[1]);
                                Flip.SetTrigger("isFlip");
                            }
                            if (parentArea.GetComponentInParent<ObjectArea>().IDSelected.Count >= 2)
                            {
                                parentArea.GetComponent<ObjectArea>().isCheckSelected = true;
                            }
                            GetComponentInParent<ObjectInfo>().isSelected = true;
                        }
                    }
                }
            }
        }
    }
}
