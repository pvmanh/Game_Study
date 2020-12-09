using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlockDragging : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public static GameObject itemBeingDragged; //gia tri check de xac dinh co dang drag hay khong
	public Transform Hold_Block_Tool; //vi tri chua block dang dc drag >< luon nam tren cac UI khac
	public Transform startParent; //vi tri bat dau >< noi chua block tool
	Vector3 startPosition; //vi tri bat dau
	bool firstCreateTool = true; //bien kiem tra tao tool moi khi tool cu dc keo
	bool isDropped = false; //kiem tra da dropped de fix vi tri
	private void Update() {
		//fix vi tri neu chen block vao vi tri bat ki trong cac block khac >< khi parent la Content thi ko xet
		if(isDropped == true)
		{
			if(transform.parent.name != "Content")
			{
				transform.localPosition = Vector3.zero - (new Vector3(0, 35f, 0));
			}
			isDropped = false;
		}
		
	}
	//Khi bat dau drag
	public void OnBeginDrag(PointerEventData eventData)
	{
		itemBeingDragged = gameObject; //gan bien check trang thai keo = gameobject
		startPosition = transform.position; //set vi tri ban dau
		//startParent = transform.parent;

		transform.SetParent(Hold_Block_Tool); //chuyen vi tri parent sang hold block de khong bi che do tac dung cua scrollview
		
		GetComponent<BlockDropDrag>().enabled = true; //bat script cho phep dropped tren block nay
		GetComponent<CanvasGroup>().blocksRaycasts = false; //tat raycast >< ko cho phep chieu ray vao >< ko keo dc neu ray = false

		GetComponent<Image>().color = Random.ColorHSV(); //random mau >< test kiem tra vi tri mau >< se xoa sau
	}

	public void OnDrag(PointerEventData eventData)
	{
		transform.position = Input.mousePosition; //set vi tri block = vi tri chuot di chuyen

		if(firstCreateTool == true) //kiem tra tool
		{
			var new_Tool = Instantiate(gameObject, startParent); //tao tool moi
			new_Tool.name = name; //set ten
			new_Tool.transform.position = startPosition; //set vi tri tai noi bat dau
			new_Tool.GetComponent<CanvasGroup>().blocksRaycasts = true; //set ray cho phep keo tha dc
			new_Tool.GetComponent<BlockDropDrag>().enabled = false; //tat script ko cho phep dropped vao day

			firstCreateTool = false; //set ko con la tool
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		itemBeingDragged = null; //tra trang thai keo = null
		GetComponent<CanvasGroup>().blocksRaycasts = true; //tra ray cho phep keo tha dc

		if(transform.parent == startParent || transform.parent == Hold_Block_Tool) //kiem tra parent neu nam trong hold block hoac tool
		{
			Destroy(gameObject); //xoa block
		}

		if(GetComponent<RectTransform>().anchoredPosition.x < 40f) //kiem tra bien trai neu bi cat thi fix vi tri
		{
			transform.localPosition = new Vector3(transform.localPosition.x + 45f, transform.localPosition.y, 0);
		}
		else if(GetComponent<RectTransform>().anchoredPosition.x > 240f) //kiem tra bien phai neu bi cat thi fix vi tri
		{
			transform.localPosition = new Vector3(transform.localPosition.x - 45f, transform.localPosition.y, 0);
		}

		if(transform.parent.name != "Content") 
		{
			if(transform.parent.childCount >= 1) //kiem tra child neu  != 0 >< maximum child trong 1 block la 1
			{
				foreach(Transform child in transform.parent) // tim child trong parent cua block dc tha
				{
					child.transform.SetParent(transform); //set parent cua child la block dc tha vao
					child.transform.localPosition = Vector3.zero - (new Vector3(0, 35f, 0)); //set lai vi tri cua child
				}
			}
		}

		isDropped = true; 
	}
}