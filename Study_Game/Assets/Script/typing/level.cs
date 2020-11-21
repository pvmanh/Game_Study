using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level : MonoBehaviour
{   public Button btncb;
    public Button btnhd;
    public Button btnht;
    public Button btnps;
    public Button btnot;
    public RawImage imgbp;
    public GameObject Typer;
    public GameObject OP;
    public GameObject time;

    //	exit
   /* ComputerCotroller pComputer;
    public GameObject imgb;
    AppOpen pApp;
	public Button Close;
    public GameObject pCom;
    public string App_Name;
    public Sprite None_App;
    public GameObject App_Parent;*/
    public string tlevel;
    
    // Start is called before the first frame update
    void Start()
    {
       // pCom = GameObject.Find("Manager");
        //App_Parent = GameObject.Find(App_Name);
        //pComputer = pCom.GetComponent<ComputerCotroller>();
       // pApp = App_Parent.GetComponent<AppOpen>();
        btncb.onClick.AddListener(() => GetLevel(btncb));
        btnhd.onClick.AddListener(() => GetLevel(btnhd));
        btnht.onClick.AddListener(() => GetLevel(btnht));
        btnps.onClick.AddListener(() => GetLevel(btnps));
        btnot.onClick.AddListener(() => GetLevel(btnot));
       // Close.onClick.AddListener(CloseApp);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void GetLevel(Button btn)
    {
        tlevel = btn.name;
        Typer.SetActive(true);
        OP.SetActive(true);
        time.SetActive(true);
        btncb.gameObject.SetActive(false);
        btnhd.gameObject.SetActive(false);
        btnht.gameObject.SetActive(false);
        btnps.gameObject.SetActive(false);
        btnot.gameObject.SetActive(false);
        imgbp.gameObject.SetActive(true);

    }
  /*  void CloseApp()
    {
        for(int i = 0; i < pComputer.NumberApp; i++)
        {
            if(pComputer.StartMenu_Manager[i].App_Name == App_Name)
            {
                pComputer.StartMenu_Manager[i].StartMenu_App.GetComponent<Image>().sprite = None_App;
                pComputer.StartMenu_Manager[i].isOpen = false;
                pComputer.StartMenu_Manager[i].App_Name = null;
                pApp.isOpen = false;
                Destroy(imgb);
            }
        }      
    }*/
}
