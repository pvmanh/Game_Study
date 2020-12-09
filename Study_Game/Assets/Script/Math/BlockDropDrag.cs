using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockDropDrag : MonoBehaviour, IDropHandler
{
    //de hien check enable script
    private void Start() {
        
    }
    //kiem tra con cua cha tra ve null
    public GameObject item
    {
        get {
            if(transform.childCount < 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }
    //set parent khi dat dieu kien
    public void OnDrop(PointerEventData eventData)
    {
        if(!item)
        {
            BlockDragging.itemBeingDragged.transform.SetParent(transform);
        }
    }
}
