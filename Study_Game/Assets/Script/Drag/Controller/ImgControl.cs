using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ImgControl : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject isDrag;
    public GameObject puzzle;
    public Transform RawPuzzle;
    public RectTransform rectTransform;
    public int TagValueImg;
    CanvasGroup blockray;
    public bool onParentRaw = true;
    private float x;
    private float y;
    private string ParentName;
    private void Awake() 
    {
        rectTransform = puzzle.GetComponent<RectTransform>();
        blockray = puzzle.GetComponent<CanvasGroup>();
        ParentName = transform.parent.name;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = puzzle;
        RawPuzzle.transform.SetAsLastSibling();
        if(onParentRaw == true)
        {
            blockray.blocksRaycasts = false;
        }
        else if(onParentRaw == false)
        {
            blockray.blocksRaycasts = false;
            puzzle.transform.SetParent(RawPuzzle);
            //onParentRaw = true;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        puzzle.transform.position = Input.mousePosition;
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = null;
        blockray.blocksRaycasts = true;
        if(ParentName == transform.parent.name)
        {
            if(onParentRaw == true)
            {
                x = Random.Range(-53f, 53f);
                y = Random.Range(-80f, 80f);
                rectTransform.anchorMin = new Vector2 (0.5f, 0.5f);
                rectTransform.anchorMax = new Vector2 (0.5f, 0.5f);
                rectTransform.localPosition = new Vector2 (x, y);
                rectTransform.sizeDelta = new Vector2 (100f, 80f);
            }
            else if(onParentRaw == false)
            {
                x = Random.Range(-53f, 53f);
                y = Random.Range(-80f, 80f);
                puzzle.transform.SetParent(RawPuzzle);
                rectTransform.anchorMin = new Vector2 (0.5f, 0.5f);
                rectTransform.anchorMax = new Vector2 (0.5f, 0.5f);
                rectTransform.localPosition = new Vector2 (x, y);
                rectTransform.sizeDelta = new Vector2 (100f, 80f);
                onParentRaw = true;
            }
        }
        else if(ParentName != transform.parent.name)
        {
            onParentRaw = false;
            rectTransform.anchorMin = new Vector2 (0f, 0f);
            rectTransform.anchorMax = new Vector2 (1f, 1f);
            rectTransform.offsetMin = new Vector2 (0f, 0f);
            rectTransform.offsetMax = new Vector2 (0f, 0f);
        }
    }
}
