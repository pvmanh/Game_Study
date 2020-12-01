using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImgBasic : MonoBehaviour, IDropHandler
{
    public int TagValueImg;
    //kiem tra child cua grid null
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
    //tha vao grid sau khi keo xong
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
