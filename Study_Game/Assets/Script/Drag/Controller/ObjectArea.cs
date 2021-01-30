using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class ObjectArea : MonoBehaviour
{
    private static readonly string FirstPlay_Name_Box = "FirstPlay_Name_Box";
    private static readonly string Student_Name = "Student_Name";
    private static readonly string Student_Class = "Student_Class";
    private int firstPlayInt;
    public ObjectModel objectData;
    public GameObject gridObject;
    public TextMeshProUGUI text_Level;
    public TimeModel timeData;
    [Header("List Image Setting")]
    public List<GameObject> IDSelected = new List<GameObject> { };
    float[] gridValue = new float[2];
    public List<Texture2D> listIcon = new List<Texture2D> { };
    public List<GameObject> GridList = new List<GameObject> { };
    public List<int> listNumber = new List<int> { };
    public List<int> ListID = new List<int> { };
    public bool isCheckSelected = false;
    public bool iChild;
    public Vector2 rect_min;
    public Vector2 rect_max;
    public Texture2D[] LoadListTexture;
    [Header("Menu setting")]
    public GameObject MenuData;
    public TMP_InputField text_name;
    public GameObject RankTimeComplete;
    public TextMeshProUGUI RankTimeComp; 
    public bool isLevelup;
    [Header("Left Click")]
    public int x1;
    [Header("Right Click")]
    public int x2;
    public int x3;
    [Header("Middle Click")]
    public int x4;
    public int x5;
    [Header("Double Click")]
    public int x6;    
    [Header("Save Setting")]
    string URL = "http://localhost/xampp/click_rank_insert.php";
    string URL_1 = "http://localhost/xampp/select_class.php";
    public TMP_Dropdown txt_class;
    public string[] saveData;
    List<string> option_class = new List<string> { };
    public bool isSave = false;
    public GameObject Particle_Manager;
    public GameObject Win_btn;
    public TextMeshProUGUI txt_Notice;
    public GameObject SFX;
    [Header("Help Setting")]
    public GameObject Help;
    public GameObject Help_1;
    public GameObject Help_2;
    public GameObject Help_3;
    public GameObject Help_4;
    // Start is called before the first frame update
    void Start()
    {
        isSave = false;

        SFX = GameObject.Find("SFX");

        HelpActive(Help, Help_1);

        firstPlayInt = PlayerPrefs.GetInt(FirstPlay_Name_Box);

        if(firstPlayInt == -1)
        {
            GetNamePlayerPrefs();
        }

        rect_min = new Vector2(0f, 0f);
        rect_max = new Vector2(1f, 1f);

        //Load danh sach texture trong thu muc Card
        LoadListTexture = Resources.LoadAll<Texture2D>("Card/");

        //Chon lop va them vao dropdown
        StartCoroutine(SelectClassAddDropdownlist(URL_1));
        
        for(int i = 0; i < LoadListTexture.Length; i++)
        {
            listIcon.Add(LoadListTexture[i]);
        }

        timeData.timegget = timeData.txt_time.text;
        //timeData.timeToDisplay = Time.time;

        text_Level.text = objectData.Level.ToString();

        gridValue = ObjectView.CaculatorValueGrid(gridValue, objectData);
        ObjectView.SplitGridObject(objectData, gridObject, gridValue, transform);

        GridList = ObjectView.AddListObjectGrid(GridList, transform);
        listNumber = ObjectView.AddNumber(listNumber, GridList);
        ListID = ObjectView.AddNumberID(ListID, GridList);
        ObjectView.AddIDNumber(listNumber, ListID, GridList, listIcon);
        Time.timeScale = 0;
    }
    void Update()
    {
        Object_Main_Game();
        zoom_in_icon_click();
    }
    //Lay ten va lop hoc sinh
    public void GetNamePlayerPrefs()
    {
        objectData.str_name = PlayerPrefs.GetString(Student_Name);
        objectData.str_class = PlayerPrefs.GetString(Student_Class);
    }
    //thu nho vung click khi click dc 1 lan
    void zoom_in_icon_click()
    {
        foreach(Transform child in transform)
        {
            if(child.gameObject.GetComponent<ObjectInfo>().firstClick == false && child.gameObject.GetComponent<ObjectInfo>().isSelected == true)
            {
                child.gameObject.GetComponent<ObjectInfo>().firstClick = true;
                if(rect_min.x <= 0.45f || rect_min.y <= 0.45f)
                {
                    rect_min.x += 0.0125f;
                    rect_min.y += 0.0125f;
                    rect_max.x -= 0.0125f;
                    rect_max.y -= 0.0125f;

                    foreach(Transform icon_click in transform)
                    {
                        RectTransform rect_icon_click = icon_click.GetComponent<ObjectInfo>().click_icon.GetComponent<RectTransform>();
                        
                        rect_icon_click.anchorMin = new Vector2(rect_min.x, rect_min.y);
                        rect_icon_click.anchorMax = new Vector2(rect_max.x, rect_max.y);
                    }
                }
            }
        }
    }
    void Object_Main_Game()
    {
        //kiem tra ten rong thi hien yeu cau nhap ten - chon lop
        if(objectData.str_name == "")
        {
            MenuDragController iDrag = MenuData.GetComponent<MenuDragController>();
            Menu.SetActiveMenuTrue(iDrag.menuData.hide_puzzle, iDrag.menuData.info_surrender);
            StartCoroutine(Menu.WaitAnimation(iDrag.menuData.ZoomIn_alert_end, iDrag.menuData.info_surrender, "isAlert", iDrag.menuData.timeDelay, 1, true));
            MenuData.GetComponent<MenuDragController>().menuData.isMenuActive = true; 
        }
        //kiem tra hinh da click du 2 tam de so sanh
        CheckSelected();
        //Kiem tra dieu kien qua man hoac chien thang
        iChild = ObjectView.CheckWinClick(gameObject);
        //dat du dieu kien qua man
        if(iChild == true && objectData.Level != objectData.LevelLimit)
        {
            Particle_Manager.GetComponent<ParticleManager>().TimeDelay();
            //Save du lieu vao table sau khi hoan thanh level
            if(isSave == false)
            {
                SFX.GetComponent<AudioManager>().PlayClipButton(SFX.GetComponent<AudioManager>().soundEffectsAudio[4]);

                long idrank = System.DateTime.Now.ToFileTime();
                StartCoroutine(SaveRankView.AddRankDrag(URL, idrank.ToString(), objectData.str_name, objectData.str_class, objectData.Level.ToString(), timeData.txt_time.text));
                isSave = true;
            }
            //Hien bang thanh tich khi xong level
            if(isLevelup == false)
            {
                MenuDragController iDrag = MenuData.GetComponent<MenuDragController>();
                Menu.SetActiveMenuTrue(iDrag.menuData.hide_puzzle, RankTimeComplete);
                RankTimeComp.text = timeData.txt_time.text;
                MenuData.GetComponent<MenuDragController>().menuData.isMenuActive = true;
            }
            //Dong y tiep tuc level => level up
            else if(isLevelup == true)
            {
                SFX.GetComponent<AudioManager>().StopClipButton(SFX.GetComponent<AudioManager>().soundEffectsAudio[4]);

                LoadListTexture = null;
                listIcon.Clear();
                LoadListTexture = Resources.LoadAll<Texture2D>("Card/");

                //lay lai danh sach texture moi
                for(int i = 0; i < LoadListTexture.Length; i++)
                {
                    listIcon.Add(LoadListTexture[i]);
                }
                /*
                //them gia tri ung voi moi boi so level khac nhau
                if(objectData.iLevel == 1)
                {
                    //objectData.Width++;
                    objectData.Height++;    
                    objectData.iLevel = 3;
                }
                else if(objectData.iLevel == 2)
                {
                    objectData.Width++;
                    objectData.Height++;
                    objectData.iLevel--;
                }
                else if(objectData.iLevel == 3)
                {
                    objectData.Width++;
                    //objectData.Height++;
                    objectData.iLevel--;
                }*/
                objectData.Level++;
                text_Level.text = objectData.Level.ToString();

                //Gan lai x, y min, x, y max
                if(objectData.Level == x2)
                {
                    rect_min = new Vector2(0f, 0f);
                    rect_max = new Vector2(1f, 1f);
                    HelpActive(Help, Help_2);
                }
                else if(objectData.Level == x4)
                {
                    rect_min = new Vector2(0f, 0f);
                    rect_max = new Vector2(1f, 1f);
                    HelpActive(Help, Help_3);
                }
                else if(objectData.Level == x6)
                {
                    rect_min = new Vector2(0f, 0f);
                    rect_max = new Vector2(1f, 1f);
                    HelpActive(Help, Help_4);
                }

                //reset vi tri grid
                objectData.xMin = objectData.xMax = 0f;
                objectData.yMin = objectData.yMax = 1f;
                //Grid lai vi tri tro choi lat hinh
                gridValue = ObjectView.CaculatorValueGrid(gridValue, objectData);
                ObjectView.SplitGridObject(objectData, gridObject, gridValue, transform);
                //Xu ly thong so tro choi level up
                GridList.Clear();
                GridList = ObjectView.AddListObjectGrid(GridList, transform);
                listNumber = ObjectView.AddNumber(listNumber, GridList);
                ListID = ObjectView.AddNumberID(ListID, GridList);
                ObjectView.AddIDNumber(listNumber, ListID, GridList, listIcon);

                foreach(Transform child in transform)
                {
                    RectTransform rect_icon_click = child.GetComponent<ObjectInfo>().click_icon.GetComponent<RectTransform>();
                         
                    rect_icon_click.anchorMin = new Vector2(rect_min.x, rect_min.y);
                    rect_icon_click.anchorMax = new Vector2(rect_max.x, rect_max.y);
                }

                timeData.timeToDisplay = 0;
                iChild = false;
                isLevelup = false;
                isSave = false;
            }
        }
        //thang man cuoi xu ly xong game
        else if(iChild == true && objectData.Level == objectData.LevelLimit)
        {
            Particle_Manager.GetComponent<ParticleManager>().TimeDelay();
            if(isSave == false)
            {
                SFX.GetComponent<AudioManager>().PlayClipButton(SFX.GetComponent<AudioManager>().soundEffectsAudio[5]);

                MenuData.GetComponent<MenuDragController>().menuData.isMenuActive = true;
                Win_btn.SetActive(true);
                long idrank = System.DateTime.Now.ToFileTime();
                StartCoroutine(SaveRankView.AddRankDrag(URL, idrank.ToString(), objectData.str_name, objectData.str_class, objectData.Level.ToString(), timeData.txt_time.text));
                isSave = true;
                txt_Notice.gameObject.SetActive(true);
                txt_Notice.text = "Congrulations!!!";
            }
        }
    }
    //Thoi gian cua dem sau moi frame co dinh
    void FixedUpdate()
    {
        Timer.TimeClock(timeData);
    }
    //kiem tra 2 hinh giong nhau hay khac nhau
    void CheckSelected()
    {
        if(isCheckSelected == true)
        {
            int ID_1 = IDSelected[0].GetComponent<ObjectInfo>().idObject;
            int ID_2 = IDSelected[1].GetComponent<ObjectInfo>().idObject;

            if (ID_1 == ID_2)
            {
                StartCoroutine(ObjectView.waitingFlipBeforeDestroy(IDSelected, SFX));
                
                isCheckSelected = false;
            }
            else
            {
                StartCoroutine(ObjectView.waitingFlip(IDSelected, SFX));
                
                isCheckSelected = false;
            }
        }
    }
    //kiem tra ten khong duoc de trong thi them ten
    public void InputNameClass()
    {
        if(text_name.text != null)
        {
            objectData.str_name = text_name.text;
            MenuDragController iDrag = MenuData.GetComponent<MenuDragController>();
            Menu.SetActiveMenuFalse(iDrag.menuData.hide_puzzle, iDrag.menuData.info_surrender);
            MenuData.GetComponent<MenuDragController>().menuData.isMenuActive = false;
            Time.timeScale = 1;
        }
    }
    //Thong bao thanh tich cho tiep tuc hoac ve menu game
    public void LevelUpContinue()
    {
        MenuDragController iDrag = MenuData.GetComponent<MenuDragController>();
        Menu.SetActiveMenuFalse(iDrag.menuData.hide_puzzle, RankTimeComplete);
        MenuData.GetComponent<MenuDragController>().menuData.isMenuActive = false;
        isLevelup = true;
    }
    //bat tro giup
    void HelpActive(GameObject _Help, GameObject _Help_1)
    {
        Menu.SetActiveMenuTrue(_Help, _Help_1);
        MenuData.GetComponent<MenuDragController>().menuData.isMenuActive = true;
    }
    //tat tro giup
    public void HelpDisable()
    {
        if(Help_1.activeSelf == true)
        {
            Help_1.SetActive(false);
        }
        else if(Help_2.activeSelf == true)
        {
            Help_2.SetActive(false);
        }
        else if(Help_3.activeSelf == true)
        {
            Help_3.SetActive(false);
        }
        else if(Help_4.activeSelf == true)
        {
            Help_4.SetActive(false);
        }
        Help.SetActive(false);
        MenuData.GetComponent<MenuDragController>().menuData.isMenuActive = false;
        Time.timeScale = 1;
    }
    //Doi class id khi co su kien dropdown changed
    public void ClassChangeAdd()
    {
        for (int i = 0; i < (saveData.Length - 1); i++)
        {
            if (txt_class.options[txt_class.value].text == SaveRankView.GetValueData(saveData[i], "class:"))
            {
                objectData.str_class = SaveRankView.GetValueData(saveData[i], "id:");
                break;
            }
        }
    }
    //Chon lop va them vao dropdown
    IEnumerator SelectClassAddDropdownlist(string URL)
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Select data complete!");
        }
        string usersDataString = www.downloadHandler.text;
        saveData = usersDataString.Split(';');

        for (int i = 0; i < (saveData.Length - 1); i++)
        {
            option_class.Add(SaveRankView.GetValueData(saveData[i], "class:"));
        }

        txt_class.AddOptions(option_class);
        ClassChangeAdd();
    }
}
