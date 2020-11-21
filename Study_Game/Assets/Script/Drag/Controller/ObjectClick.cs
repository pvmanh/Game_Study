using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectClick : MonoBehaviour, IPointerClickHandler
{
    public int idObject;
    public GameObject image;
    public bool isSelected = false;
    Animator Flip;
    void Start()
    {
        Flip = GetComponent<Animator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(isSelected == false)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                if (GetComponentInParent<ObjectArea>().IDSelected.Count < 2)
                {
                    GetComponentInParent<ObjectArea>().IDSelected.Add(gameObject);
                    Flip.SetTrigger("isFlip");
                }
                if (GetComponentInParent<ObjectArea>().IDSelected.Count >= 2)
                {
                    GetComponentInParent<ObjectArea>().isCheckSelected = true;
                }
            }
            isSelected = true;
        } 
    }
}
