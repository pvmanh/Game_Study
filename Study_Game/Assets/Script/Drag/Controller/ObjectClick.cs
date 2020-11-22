using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClick : MonoBehaviour, IPointerClickHandler
{
    public GameObject parentArea;
    public GameObject parent;
    Animator Flip;
    void Start()
    {
        Flip = GetComponentInParent<Animator>();
        parentArea = GameObject.Find("Area");
    }
    
    public void OnPointerClick(PointerEventData eventData)
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
                        Flip.SetTrigger("isFlip");
                    }
                    if (parentArea.GetComponentInParent<ObjectArea>().IDSelected.Count >= 2)
                    {
                        parentArea.GetComponent<ObjectArea>().isCheckSelected = true;
                    }
                }
                GetComponentInParent<ObjectInfo>().isSelected = true;
            }
        }
    }
}
