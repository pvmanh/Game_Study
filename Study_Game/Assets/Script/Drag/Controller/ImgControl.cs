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
    public bool isTruePlace = false;
    //set thong so dau game
    private void Awake() 
    {
        rectTransform = puzzle.GetComponent<RectTransform>();
        blockray = puzzle.GetComponent<CanvasGroup>();
        ParentName = transform.parent.name;
    }
    //khi bat dau keo
    public void OnBeginDrag(PointerEventData eventData)
    {
        //puzzle ko nam dung vi tri
        if(isTruePlace == false)
        {
            isDrag = puzzle;
            //dua hinh dc keo len top
            RawPuzzle.transform.SetAsLastSibling();
            //nam trong o chua tat block ray cast
            if(onParentRaw == true)
            {
                blockray.blocksRaycasts = false;
            }
            //khong nam trong o chua tat block ray cast va gan lai parent
            else if(onParentRaw == false)
            {
                blockray.blocksRaycasts = false;
                puzzle.transform.SetParent(RawPuzzle);
                //onParentRaw = true;
            }
        }
    }
    //xu ly hinh theo vi tro con tro khi dang keo
    public void OnDrag(PointerEventData eventData)
    {
        if(isTruePlace == false)
        {
            puzzle.transform.position = Input.mousePosition;
        }
    }
    //xu ly ket thuc keo
    public void OnEndDrag(PointerEventData eventData)
    {
        //kiem tra chua nam dung vi tri
        if(isTruePlace == false)
        {
            isDrag = null;
            blockray.blocksRaycasts = true;
            //Trung ten o chua thi xu ly ngau nhien theo vi tri
            if(ParentName == transform.parent.name)
            {
                //puzzle thuoc o chua keo vao grid nhung k trung bat ky vi tri vao tra ve vi tri ngau nhien trong o chua
                if(onParentRaw == true)
                {
                    x = Random.Range(-53f, 53f);
                    y = Random.Range(-80f, 80f);
                    rectTransform.anchorMin = new Vector2 (0.5f, 0.5f);
                    rectTransform.anchorMax = new Vector2 (0.5f, 0.5f);
                    rectTransform.localPosition = new Vector2 (x, y);
                    rectTransform.sizeDelta = new Vector2 (100f, 80f);
                }
                //puzzle khong thuoc o chua nam sai vi tri tren grid dc keo ve vi tri ngau nhien o chua ban dau
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
            //Neu khong trung ten o chua thi set gia tri zoom anh full size theo o grid
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
}
