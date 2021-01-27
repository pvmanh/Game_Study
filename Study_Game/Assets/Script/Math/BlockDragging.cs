using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlockDragging : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public static GameObject itemBeingDragged; //gia tri check de xac dinh co dang drag hay khong
	public static GameObject Block_Dragging_Hover;
	public static int Block_Dragging_Hover_ID;
	public Transform Hold_Block_Tool; //vi tri chua block dang dc drag >< luon nam tren cac UI khac
	public Transform startParent; //vi tri bat dau >< noi chua block tool
	Vector3 startPosition; //vi tri bat dau
	bool firstCreateTool = true; //bien kiem tra tao tool moi khi tool cu dc keo
	int SiblingIndexBlock;
	public GameObject SFX;
	//Khi bat dau drag
	public void OnBeginDrag(PointerEventData eventData)
	{
		SFX.GetComponent<AudioManager>().soundEffectsAudio[3].Play();

		itemBeingDragged = gameObject; //gan bien check trang thai keo = gameobject
		startPosition = transform.position; //set vi tri ban dau
		SiblingIndexBlock = transform.GetSiblingIndex();
		///startParent = transform.parent;

		transform.SetParent(Hold_Block_Tool); //chuyen vi tri parent sang hold block de khong bi che do tac dung cua scrollview
		
		//GetComponent<BlockDropDrag>().enabled = true; //bat script cho phep dropped tren block nay
		GetComponent<CanvasGroup>().blocksRaycasts = false; //tat raycast >< ko cho phep chieu ray vao >< ko keo dc neu ray = false

		if(GetComponent<ShowCheckBlock>().Top_Check != null)
			GetComponent<ShowCheckBlock>().Top_Check.SetActive(true);
		if(GetComponent<ShowCheckBlock>().Mid_Check != null)
			GetComponent<ShowCheckBlock>().Mid_Check.SetActive(true);
		if(GetComponent<ShowCheckBlock>().Bot_Check != null)
			GetComponent<ShowCheckBlock>().Bot_Check.SetActive(true);

		if(name == "For")
		{
			transform.GetChild(2).GetComponent<CanvasGroup>().blocksRaycasts = true;
		}
		else if(name == "Repeat")
		{
			transform.GetChild(3).GetComponent<CanvasGroup>().blocksRaycasts = true;
		}
	}

	public void OnDrag(PointerEventData eventData)
	{
		Vector3 mousePos = Input.mousePosition;
    	mousePos.z = Camera.main.nearClipPlane;
		transform.position = Camera.main.ScreenToWorldPoint(mousePos); //set vi tri block = vi tri chuot di chuyen

		if(firstCreateTool == true) //kiem tra tool
		{
			var new_Tool = Instantiate(gameObject, startParent); //tao tool moi
			new_Tool.name = name; //set ten
			new_Tool.transform.position = startPosition; //set vi tri tai noi bat dau
			new_Tool.transform.SetSiblingIndex(SiblingIndexBlock);
			new_Tool.GetComponent<CanvasGroup>().blocksRaycasts = true; //set ray cho phep keo tha dc
			//new_Tool.GetComponent<BlockDropDrag>().enabled = false; //tat script ko cho phep dropped vao day

			if(new_Tool.GetComponent<ShowCheckBlock>().Top_Check != null)
				new_Tool.GetComponent<ShowCheckBlock>().Top_Check.SetActive(false);
				new_Tool.GetComponent<ShowCheckBlock>().Top_Check.GetComponent<CanvasGroup>().blocksRaycasts = false;
			//if(new_Tool.GetComponent<ShowCheckBlock>().Mid_Check != null)
			//	new_Tool.GetComponent<ShowCheckBlock>().Mid_Check.SetActive(false);
			if(new_Tool.GetComponent<ShowCheckBlock>().Bot_Check != null)
				new_Tool.GetComponent<ShowCheckBlock>().Bot_Check.SetActive(false);
				new_Tool.GetComponent<ShowCheckBlock>().Bot_Check.GetComponent<CanvasGroup>().blocksRaycasts = false;

			if(new_Tool.name == "For")
			{
				new_Tool.transform.GetChild(2).GetComponent<CanvasGroup>().blocksRaycasts = false;
			}
			else if(new_Tool.name == "Repeat")
			{
				new_Tool.transform.GetChild(3).GetComponent<CanvasGroup>().blocksRaycasts = false;
			}
			
			firstCreateTool = false; //set ko con la tool
		}

		//kiem tra truyen bien static block dang dc raycast
		if(eventData.pointerEnter != null)
		{
			if(eventData.pointerEnter.gameObject.name == "Top")
			{
				Block_Dragging_Hover = eventData.pointerEnter.gameObject.transform.parent.gameObject;
				Block_Dragging_Hover_ID = Block_Dragging_Hover.GetInstanceID();
			}
			else if(eventData.pointerEnter.gameObject.name == "Bot")
			{
				Block_Dragging_Hover = eventData.pointerEnter.gameObject.transform.parent.gameObject;
				Block_Dragging_Hover_ID = Block_Dragging_Hover.GetInstanceID();
			}
			else if(eventData.pointerEnter.gameObject.name == "Mid")
			{
				Block_Dragging_Hover = eventData.pointerEnter.gameObject.transform.parent.gameObject;
				Block_Dragging_Hover_ID = Block_Dragging_Hover.GetInstanceID();
			}
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		itemBeingDragged = null; //tra trang thai keo = null
		Block_Dragging_Hover = null;
		Block_Dragging_Hover_ID = 0;
		GetComponent<CanvasGroup>().blocksRaycasts = true; //tra ray cho phep keo tha dc

		if(eventData.pointerEnter != null)
		{
			if(eventData.pointerEnter.gameObject.name == "Top")
			{
				transform.SetParent(eventData.pointerEnter.gameObject.transform.parent.transform.parent);
				int index_block = eventData.pointerEnter.gameObject.transform.parent.GetSiblingIndex();
				transform.SetSiblingIndex(index_block);
			}
			else if(eventData.pointerEnter.gameObject.name == "Bot")
			{
				transform.SetParent(eventData.pointerEnter.gameObject.transform.parent.transform.parent);
				int index_block = eventData.pointerEnter.gameObject.transform.parent.GetSiblingIndex();
				transform.SetSiblingIndex(index_block + 1);
			}
			else if(eventData.pointerEnter.gameObject.name == "Mid")
			{
				transform.SetParent(eventData.pointerEnter.gameObject.transform);
			}
		}

		GetComponent<RectTransform>().localPosition = new Vector3(GetComponent<RectTransform>().localPosition.x ,GetComponent<RectTransform>().localPosition.y , 0);
		GetComponent<BlockInfo>().isActive = true;

		if(transform.parent == startParent || transform.parent == Hold_Block_Tool) //kiem tra parent neu nam trong hold block hoac tool
		{
			Destroy(gameObject); //xoa block
		}

		SFX.GetComponent<AudioManager>().soundEffectsAudio[3].Play();
	}
}