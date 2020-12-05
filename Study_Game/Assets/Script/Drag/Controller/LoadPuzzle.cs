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
    public bool isSave = false;
    public GameObject Particle_Manager;
    public TextMeshProUGUI txt_Notice;
    List<float> deltaFrame = new List<float>{3f};
    public bool levelup_sound = false;

    // Start is called before the first frame update
    void Start()
    {
        isSave = false;

        puzzleData.SFX = GameObject.Find("SFX");

        Puzzle.isWin = true;
        //Load hinh puzzle tu thu muc Puzzle
        textureData.TexturePuzzle = Resources.LoadAll<Texture2D>("Puzzle/");
        //Them class vao dropdown
        StartCoroutine(SelectClassAddDropdownlist(URL_1));
        //gan time = text
        timeData.timegget = timeData.txt_time.text;
        //timeData.timeToDisplay = Time.deltaTime;
        //khoa bam ESC
        MenuData.GetComponent<MenuDragController>().menuData.isMenuActive = true;
        //gan level size hien hanh
        txtLevelSelect.text = puzzleData.level.ToString();
        txtSizeSelect.text = (puzzleData.Height * puzzleData.Width).ToString();
        //xu ly danh sach texture
        textureData.list_Texture = new int[textureData.TexturePuzzle.Length];
        Puzzle.LoadLevelImage(textureData.TexturePuzzle, ImgTxture, positionTmgTxture);
        //xu ly random hinh anh puzzle
        ImageView.RandomNumberTexture(textureData);
        imageData = this.gameObject.GetComponent<CutImage>().imageData;
        BaseImage = this.gameObject.GetComponent<CutImage>();
        //Tim txt-level TMP GUI
        puzzleData.txt_level = GameObject.Find("txt-level").GetComponent<TextMeshProUGUI>();
        //ngung time hoac delta time
        Time.timeScale = 0;
        //Puzzle.LoadPuzzleLevel(puzzleData, imgpuzzle, imageData, BaseImage.BasePuzzleObject);
    }

    // Update is called once per frame
    void Update()
    {
        //kiem tra dieu kien win
        Puzzle.CheckWinPuzzle(puzzleData, timeData, Menu_Level_Select, imageData, BaseImage.BasePuzzleObject, Particle_Manager, deltaFrame);
        //Dat dieu kien thang tro choi & save rank cuoi
        if (puzzleData.iCount == puzzleData.isTrueCount)
        {
            if (puzzleData.level == puzzleData.level_limit)
            {
                if(Puzzle.isWin == false)
                {
                    if(isSave == false)
                    {
                        puzzleData.SFX.GetComponent<AudioManager>().PlayClipButton(puzzleData.SFX.GetComponent<AudioManager>().soundEffectsAudio[2]);

                        MenuData.GetComponent<MenuDragController>().menuData.isMenuActive = true;
                        long idrank = System.DateTime.Now.ToFileTime();
                        StartCoroutine(SaveRankView.AddRankDrag(URL, idrank.ToString(), puzzleData.str_name, puzzleData.str_class, puzzleData.level.ToString(), timeData.txt_time.text));
                        isSave = true;
                        txt_Notice.gameObject.SetActive(true);
                        txt_Notice.text = "Congrulations!!!";
                    }
                    Time.timeScale = 0;
                }  
            }
            else
            {
                if(levelup_sound == false)
                {
                    MenuData.GetComponent<MenuDragController>().menuData.isMenuActive = true;
                    puzzleData.SFX.GetComponent<AudioManager>().PlayClipButton(puzzleData.SFX.GetComponent<AudioManager>().soundEffectsAudio[1]);
                    levelup_sound = true;
                }
            }
        }
        //hien bang nhap nen neu ten rong
        if(puzzleData.str_name == "")
        {
            MenuDragController iDrag = MenuData.GetComponent<MenuDragController>();
            Menu.SetActiveMenuTrue(iDrag.menuData.hide_puzzle, iDrag.menuData.info_surrender);
            StartCoroutine(Menu.WaitAnimation(iDrag.menuData.ZoomIn_alert_end, iDrag.menuData.info_surrender, "isAlert", iDrag.menuData.timeDelay, 1, true)); 
        }
        //Xu ly level up thi hien bang chon hinh
        if(puzzleData.levelup == true)
        {
            if(isSave == false)
            {
                //Save rank level
                long idrank = System.DateTime.Now.ToFileTime();
                StartCoroutine(SaveRankView.AddRankDrag(URL, idrank.ToString(), puzzleData.str_name, puzzleData.str_class, (puzzleData.level - 1).ToString(), timeData.txt_time.text));
                Time.timeScale = 0;
                txtLevelSelect.text = puzzleData.level.ToString();
                txtSizeSelect.text = (puzzleData.Height * puzzleData.Width).ToString();
                //MenuData.GetComponent<MenuDragController>().menuData.isMenuActive = true;
                timeData.timeToDisplay = 0;
                puzzleData.levelup = false;
                Particle_Manager.GetComponent<ParticleManager>().isActive = true;
                isSave = true;
                levelup_sound = false;
            }
        }
    }
    //thoi gian tro choi
    void FixedUpdate()
    {
        Timer.TimeClock(timeData);
    }
    // hoan doi vi tri puzzle
    public void ButtonRandom()
    {
        Puzzle.RandomPuzzlePosition(puzzleData);
    }
    //Chon hinh va bat dau tro choi
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
            isSave = false;
        }
    }
    //Hien bang nhap ten
    public void InputNameClass()
    {
        if(text_name.text != null)
        {
            puzzleData.str_name = text_name.text;
            MenuDragController iDrag = MenuData.GetComponent<MenuDragController>();
            Menu.SetActiveMenuFalse(iDrag.menuData.hide_puzzle, iDrag.menuData.info_surrender);
        }
    }
    //Xu ly gan id class = dropdown changed
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
    //Chon class va them vao dropdown
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
