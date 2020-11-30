using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using TMPro;

public class LoadPuzzle : MonoBehaviour
{
    public PuzzleModel puzzleData;
    public TextureModel textureData;
    public TimeModel timeData;
    public GameObject ImgTxture;
    public Transform positionTmgTxture;
    public GameObject Menu_Level_Select;
    public TextMeshProUGUI txtLevelSelect;
    public TextMeshProUGUI txtSizeSelect;
    public TMP_InputField text_name;
    public TMP_Dropdown txt_class;
    public GameObject MenuData;
    public Texture2D imgpuzzle;
    public ImageModel imageData;
    public CutImage BaseImage;
    [Header("Save Setting")]
    //public SaveRankData prank; //Data chua thong tin STT
    //public SaveRankData[] ListRank; //Array Count de lay length add STT
    string URL = "http://localhost/xampp/drag_rank_insert.php";
    string URL_1 = "http://localhost/xampp/select_class.php";
    public string[] saveData;
    List<string> option_class = new List<string> { };

    // Start is called before the first frame update
    void Start()
    {
        textureData.TexturePuzzle = Resources.LoadAll<Texture2D>("Puzzle/");

        StartCoroutine(SelectClassAddDropdownlist(URL_1));

        timeData.timegget = timeData.txt_time.text;
        //timeData.timeToDisplay = Time.deltaTime;

        MenuData.GetComponent<MenuDragController>().menuData.isMenuActive = true;

        txtLevelSelect.text = puzzleData.level.ToString();
        txtSizeSelect.text = (puzzleData.Height * puzzleData.Width).ToString();

        textureData.list_Texture = new int[textureData.TexturePuzzle.Length];
        Puzzle.LoadLevelImage(textureData.TexturePuzzle, ImgTxture, positionTmgTxture);

        ImageView.RandomNumberTexture(textureData);
        imageData = this.gameObject.GetComponent<CutImage>().imageData;
        BaseImage = this.gameObject.GetComponent<CutImage>();

        puzzleData.txt_level = GameObject.Find("txt-level").GetComponent<TextMeshProUGUI>();

        Time.timeScale = 0;
        //Puzzle.LoadPuzzleLevel(puzzleData, imgpuzzle, imageData, BaseImage.BasePuzzleObject);
    }

    // Update is called once per frame
    void Update()
    {
        Puzzle.CheckWinPuzzle(puzzleData, timeData, Menu_Level_Select, imageData, BaseImage.BasePuzzleObject);

        if(puzzleData.str_name == "")
        {
            MenuDragController iDrag = MenuData.GetComponent<MenuDragController>();
            Menu.SetActiveMenuTrue(iDrag.menuData.hide_puzzle, iDrag.menuData.info_surrender);
            StartCoroutine(Menu.WaitAnimation(iDrag.menuData.ZoomIn_alert_end, iDrag.menuData.info_surrender, "isAlert", iDrag.menuData.timeDelay, 1, true)); 
        }

        if(puzzleData.levelup == true)
        {
            long idrank = System.DateTime.Now.ToFileTime();
            StartCoroutine(SaveRankView.AddRankDrag(URL, idrank.ToString(), puzzleData.str_name, puzzleData.str_class, (puzzleData.level - 1).ToString(), timeData.txt_time.text));

            Time.timeScale = 0;
            txtLevelSelect.text = puzzleData.level.ToString();
            txtSizeSelect.text = (puzzleData.Height * puzzleData.Width).ToString();
            MenuData.GetComponent<MenuDragController>().menuData.isMenuActive = true;
            timeData.timeToDisplay = 0;
            puzzleData.levelup = false;
        }
    }

    void FixedUpdate()
    {
        Timer.TimeClock(timeData);
    }

    public void ButtonRandom()
    {
        Puzzle.RandomPuzzlePosition(puzzleData);
    }

    public void OnPlayLevelSelect()
    {
        if(imgpuzzle != null)
        {
            Puzzle.LoadPuzzleLevel(puzzleData, imgpuzzle, imageData, BaseImage.BasePuzzleObject);
            Menu_Level_Select.SetActive(false);
            imgpuzzle = null;

            foreach(Transform child in positionTmgTxture)
            {
                if(child.GetComponent<SelectLevelImg>().isSelected == true)
                {
                    Destroy(child.gameObject);
                    break;
                }   
            }

            MenuData.GetComponent<MenuDragController>().menuData.isMenuActive = false;
            Time.timeScale = 1;
        }
    }
    public void InputNameClass()
    {
        if(text_name.text != null)
        {
            puzzleData.str_name = text_name.text;
            MenuDragController iDrag = MenuData.GetComponent<MenuDragController>();
            Menu.SetActiveMenuFalse(iDrag.menuData.hide_puzzle, iDrag.menuData.info_surrender);
        }
    }
    public void ClassChangeAdd()
    {
        for (int i = 0; i < (saveData.Length - 1); i++)
        {
            if (txt_class.options[txt_class.value].text == SaveRankView.GetValueData(saveData[i], "class:"))
            {
                puzzleData.str_class = SaveRankView.GetValueData(saveData[i], "id:");
                break;
            }
        }

    }
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
