using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[System.Serializable]
public class ShowCheckBlock : MonoBehaviour
{
    public GameObject Top_Check;
    public GameObject Mid_Check;
    public GameObject Bot_Check;
    // Update is called once per frame
    void Update()
    {
        Check_Block_Drag();
    }
    //kiem tra neu block dang dc raycast la block hien tai thi show check
    void Check_Block_Drag()
    {
        if(BlockDragging.itemBeingDragged != null)
        {
            if(Top_Check != null)
            {
                Top_Check.GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
            if(Bot_Check != null)
            {
                Bot_Check.GetComponent<CanvasGroup>().blocksRaycasts = true;
            }
        }
        else if(BlockDragging.itemBeingDragged == null)
        {
            if(Top_Check != null)
            {
                Top_Check.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
            if(Bot_Check != null)
            {
                Bot_Check.GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }

        if(BlockDragging.Block_Dragging_Hover != null)
        {
            if(BlockDragging.Block_Dragging_Hover_ID == gameObject.GetInstanceID())
            {
                if(Top_Check != null)
                {
                    Top_Check.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                }
                if(Mid_Check != null)
                {
                    Mid_Check.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                }
                if(Bot_Check != null)
                {
                    Bot_Check.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
                }
            }
            else
            {
                if(Top_Check != null)
                {
                    Top_Check.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                }
                if(Mid_Check != null)
                {
                    Mid_Check.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                }
                if(Bot_Check != null)
                {
                    Bot_Check.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
                }
            }  
        }
        else
        {
            if(Top_Check != null)
            {
                Top_Check.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            }
            if(Mid_Check != null)
            {
                Mid_Check.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            }
            if(Bot_Check != null)
            {
                Bot_Check.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
            }
        }
    }
}
