using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSelected : MonoBehaviour
{
    public GameObject ParentMenu;
    public Button MenuTitle;
    public GameObject MenuSub;
    public Sprite SprSelected;
    public Sprite SprUnSelected;
    public bool isSelected = false;
    // Start is called before the first frame update
    void Start()
    {
        MenuTitle = GetComponent<Button>();
        MenuTitle.onClick.AddListener(() => SelectedTitleMenu());
    }
    //Xu ly tieu de lua chon 1 trong 2 lai danh may hoac chuot
    public void SelectedTitleMenu()
    {
        if(isSelected == false)
        {
            List<Image> ListImg = new List<Image>{};
            ListImg = ParentMenu.GetComponent<MainMenuController>().Menu_Title_Selected;

            List<GameObject> ListSubMain = new List<GameObject>{};
            ListSubMain = ParentMenu.GetComponent<MainMenuController>().Menu_Sub_Selected;

            List<GameObject> ListSubChild = new List<GameObject>{};
            ListSubChild = ParentMenu.GetComponent<MainMenuController>().Menu_Sub_Child_Selected;

            for(int i = 0; i < ListImg.Count; i++)
            {
                ListImg[i].GetComponent<Image>().sprite = SprUnSelected;
                ListImg[i].GetComponent<MainMenuSelected>().isSelected = false;
            } 

            for(int i = 0; i < ListSubChild.Count; i++)
            {
                ListSubChild[i].GetComponent<Image>().color = new Color32(100, 100, 100, 255);
                ListSubChild[i].GetComponent<MenuSubChildSelect>().isSelected = false;
            } 

            ParentMenu.GetComponent<MainMenuController>().indexScene = 0;
            MenuTitle.GetComponent<Image>().sprite = SprSelected;       
            isSelected = true;
        }
    }
}
