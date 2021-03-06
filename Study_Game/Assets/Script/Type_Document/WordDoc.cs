﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
public class WordDoc : MonoBehaviour
{
    private static readonly string FirstPlay_Name_Box = "FirstPlay_Name_Box";
    private static readonly string Student_Name = "Student_Name";
    private static readonly string Student_Class = "Student_Class";
    private int firstPlayInt;
    string A;
    string Final;
    string stringgoc;
    public List<string> WordList = new List<string> { };
    public string[] wordListcb;
    public GameObject GO;
    public TextMeshProUGUI WordDocOP;
    public TMP_InputField IPWord;
    private string currentWord = string.Empty;
    private string reWord = string.Empty;
    private string txtdung = string.Empty;
    private string txtsai = string.Empty;
    //private int k = 0;
    //time
    public TimeModel timeData;

    //time
    //public float timeStart = 0;
   // public Text textTime;
    //score
    public Text textAccurary;
    public Text textSpeed;
    public TextMeshProUGUI ttAccurary;
    public TextMeshProUGUI ttSpeed;
    public TextMeshProUGUI ttTime;
    public GameObject total;
    public GameObject menu;
    private float accurary = 0;
    private float tudung = 0;
    private float tusai = 0;
    private float speed = 0;

    //save
    public GameObject name;
    public TextMeshProUGUI txtname;
    public Button xacnhan;
    string URL = "http://localhost/xampp/typedoc_rank_insert.php";
    string URL_1 = "http://localhost/xampp/select_class.php";
    public string[] saveData;
    public TMP_InputField text_name;
    public TMP_Dropdown txt_class;
    List<string> option_class = new List<string> { };
    public string str_name;
    public string str_class;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(SelectClassAddDropdownlist(URL_1));

        firstPlayInt = PlayerPrefs.GetInt(FirstPlay_Name_Box);

        if(firstPlayInt == -1)
        {
            GetNamePlayerPrefs();
            Time.timeScale = 1;
        }

        timeData.timegget = timeData.txt_time.text;
        if (MenuTypeDoc.i == 1)
        { 
        wordListcb = catList(WordList, wordListcb, 0);
        }
        if(MenuTypeDoc.i == 2)
        {
            wordListcb = catList(WordList, wordListcb, Random.Range(1,11));
        }
        //IPWord.Select();
        getList();
        catchuoi();
        currentWord = Final;
        currentWord += " ";
        WordDocOP.text = Final;
        
         Debug.Log(Final);
        Debug.Log(stringgoc);

    }

    //Lay ten va lop hoc sinh
    public void GetNamePlayerPrefs()
    {
        str_name = PlayerPrefs.GetString(Student_Name);
        str_class = PlayerPrefs.GetString(Student_Class);
    }

    public static string[] catList(List<string> List, string[] StringList, int i)
    {
        StringList = new string[1];
        StringList[0] = List[i];
        return StringList;
    }
    public void getList()
    {
        
        stringgoc = wordListcb[0];
        A = stringgoc;
        //WordDocOP.text = wordListcb[0];
        //currentWord += " ";
       /* for (int i = 0; i < currentWord.Length; i++)
        {
           // if(currentWord.Substring(currentWord.IndexOf(" ")))
            //{
                Debug.Log(currentWord.Remove(currentWord.IndexOf(" ")));
            //}
        }
            Debug.Log(WordDocOP.text);   */ 
    }
    void catchuoi()
    {
        for (int i = 0; i < stringgoc.Length; i++)
        {
            if (A.IndexOf(" ") >= 0)
            {
                string B = A.Remove(A.IndexOf(" "));
                A = A.Substring(A.IndexOf(" "));



                if (B.Length != 0)
                {
                    Final += B + " ";
                }
                else if (B.Length == 0)
                {
                    A = A.Remove(0, 1);
                }
            }
            else
            {
                Final += A;
                i = stringgoc.Length;
                Debug.Log(Final.Length);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
           // timeStart += Time.deltaTime;
        
        //textTime.text = Mathf.RoundToInt(timeStart).ToString();

        textAccurary.text = Mathf.RoundToInt(accurary).ToString();
            textSpeed.text = Mathf.RoundToInt(tudung).ToString();
        // IPWord.Select();
        getWord();
        colorWord();
        if (str_name == "")
        {
      
            Menu.SetActiveMenuTrue(total, name);
        }
    }
    void FixedUpdate()
    {
            Timer.TimeClock(timeData);
       // Debug.Log(timeData.second);
       // Debug.Log(timeData.minute);
    }

    public void colorWord()
    {
        WordDocOP.text = reWord +currentWord;
    }


    //Hien bang nhap ten
    public void InputNameClass()
    {
        if (text_name.text != null)
        {
            str_name = text_name.text;
            Time.timeScale = 1;
            Menu.SetActiveMenuFalse(total,name) ;
        }
    }
    //Xu ly gan id class = dropdown changed
    public void ClassChangeAdd()
    {
        for (int i = 0; i < (saveData.Length - 1); i++)
        {
            if (txt_class.options[txt_class.value].text == SaveRankView.GetValueData(saveData[i], "class:"))
            {
              str_class = SaveRankView.GetValueData(saveData[i], "id:");
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


    public IEnumerator AddRankTypeDoc()
    {
        //data dung de post tuong ung mysql trong php
         
        WWWForm form = new WWWForm();
        form.AddField("addIDrank", System.DateTime.Now.ToFileTime().ToString());
        form.AddField("addnamerank", str_name);
        form.AddField("addclasrank", str_class);
        form.AddField("addaccuraryrank", accurary.ToString());
        form.AddField("addtimerank", timeData.txt_time.text);
        form.AddField("addspeedrank", tudung.ToString());

        //Post form len php => insert into
        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
    //Cat du lieu string lay dc
    public void getWord()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
           // k++;
            if ( IPWord.text != "")//&& IPWord.text != "  " &&IPWord.text != "   " && IPWord.text != "    " && IPWord.text != "     ")
            {
                for (int i = 0; i < currentWord.Length; i++)
                {

                    if (currentWord.Substring(i, 1) == " ")
                    {
                        txtsai = null;
                        txtdung = null;
                        if (IPWord.text == currentWord.Substring(0, i))
                        {
                            Debug.Log(currentWord.Substring(0, i));
                            txtdung = "<color=green>" + currentWord.Substring(0, i + 1) + "</color>";
                            currentWord = currentWord.Remove(0, i + 1);
                            reWord += txtdung;
                            tudung++;
                            Debug.Log(txtdung);
                        }
                        else if (IPWord.text != currentWord.Substring(0, i))
                        {

                            txtsai = "<color=red>" + currentWord.Substring(0, i + 1) + "</color>";
                            currentWord = currentWord.Remove(0, i + 1);
                            reWord += txtsai;
                            tusai++;
                             Debug.Log(txtsai);

                        }
                        i = currentWord.Length;
                        //if (k >= 1)
                      //  {
                            IPWord.text = null;
                        //Debug.Log(tudung);
                        //Debug.Log(tusai);
                        // }
                        if (tudung != 0 || tusai != 0)
                        {
                            accurary = (tudung / (tusai + tudung)) * 100;
                            speed = (tudung)/(timeData.hour*60 +timeData.minute+ timeData.second/60);
                        }
                    }
                }
                if (currentWord.Length == 0)
                {
                    total.SetActive(true);
                    menu.SetActive(true);
                    WordDocOP.gameObject.SetActive(false);
                    IPWord.gameObject.SetActive(false);
                    Time.timeScale = 0;
                    ttAccurary.text = Mathf.RoundToInt(accurary).ToString();
                    ttSpeed.text = ((speed*100.0f)/100.0f).ToString();
                    ttTime.text = timeData.txt_time.text;
                    Debug.Log("112222");
                    if (MenuTypeDoc.i != 1)
                    {
                        StartCoroutine(AddRankTypeDoc());
                    }
                }
            }
            //Debug.Log(currentWord+"1")
        }
    }

}
