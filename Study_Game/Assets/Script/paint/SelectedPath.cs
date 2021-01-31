using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using FreeDraw;

public class SelectedPath : MonoBehaviour, IPointerClickHandler
{
    public Transform parentImg;
    public GameObject parent_App_Click;
    public Texture2D selectedTxture;
    public bool isSelected = false;
    // Start is called before the first frame update
    void Start()
    {
        parentImg = GameObject.Find("Content-imgP").transform;
        parent_App_Click = GameObject.Find("ReadWriteEnabledImageToDrawOn");
    }
    //chon hinh anh cho level tiep theo
    public void OnPointerClick(PointerEventData eventData)
    {
        parent_App_Click.GetComponent<Drawable>().is_bool = true;
        if (isSelected == false)
        {
            foreach (Transform child in parentImg)
            {
                child.gameObject.GetComponent<RawImage>().color = Color.white;
                child.gameObject.GetComponent<SelectedPath>().isSelected = false;
               
            }

            parent_App_Click.GetComponent<Drawable>().icon = selectedTxture;
            parent_App_Click.GetComponent<Drawable>().iconselected = gameObject;
            GetComponent<RawImage>().color = Color.red;
            isSelected = true;
        }
    }
}
