using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImgBasic : MonoBehaviour, IDropHandler
{
    public int TagValueImg;
    public GameObject puzzle
    {
        get
        {
            if(transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if(!puzzle)
        {
            if(ImgControl.isDrag != null)
            {
                ImgControl.isDrag.transform.SetParent(transform);
            }

        }
    }
}
