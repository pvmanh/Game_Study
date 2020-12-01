using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSubChildSelect : MonoBehaviour
{
    public GameObject ParentMenu;
    public Button MenuSubChild;
    public int indexScene;
    public bool isSelected = false;
    // Start is called before the first frame update
    void Start()
    {
        MenuSubChild = GetComponent<Button>();
        MenuSubChild.onClick.AddListener(() => SelectedTitleMenu());
    }
    //Xu ly bai thuc hanh duoc chon chi duy nhat 1 bai de bat dau
    public void SelectedTitleMenu()
    {
        if(isSelected == false)
        {
            List<GameObject> ListSubChild = new List<GameObject>{};

            ListSubChild = ParentMenu.GetComponent<MainMenuController>().Menu_Sub_Child_Selected;

            for(int i = 0; i < ListSubChild.Count; i++)
            {
                ListSubChild[i].GetComponent<Image>().color = new Color32(100, 100, 100, 255);
                ListSubChild[i].GetComponent<MenuSubChildSelect>().isSelected = false;
            } 
            
            ParentMenu.GetComponent<MainMenuController>().indexScene = indexScene;
            MenuSubChild.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            isSelected = true;
        }
    }
}
