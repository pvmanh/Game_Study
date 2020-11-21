using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menutype : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Hidemenu;
    public GameObject MenuType;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            hienmenu();
        }
    }

    public void hienmenu()
    {
        Menu.SetActiveMenuTrue(Hidemenu, MenuType);

    }

    public void quaylai()
    {
        Menu.SetActiveMenuFalse(MenuType , Hidemenu);
    }
}
