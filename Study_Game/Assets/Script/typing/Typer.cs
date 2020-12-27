using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
public class Typer : MonoBehaviour
{ //Ngân Hàng Từ
    public WordBank wordBank =null;
    public TextMeshProUGUI wordOutput = null;

    public string test;

    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;

    private string colorWord = string.Empty ;

    /*public Button btn1;
    public Button btn2;
    public Button btn3;
    public Button btn4;
    public Button btn5;
    public Button btn6;
    public Button btn7;
    public Button btn8;
    public Button btn9;
    public Button btn0;
    public Button btnq;
    public Button btnw;
    public Button btne;
    public Button btnr;
    public Button btnt;
    public Button btny;
    public Button btnu;
    public Button btni;
    public Button btno;
    public Button btnp;
    public Button btna;
    public Button btns;
    public Button btnd;
    public Button btnf;
    public Button btng;
    public Button btnh;
    public Button btnj;
    public Button btnk;
    public Button btnl;
    public Button btnchamp;
    public Button btnmoh;
    public Button btnz;
    public Button btnx;
    public Button btnc;
    public Button btnv;
    public Button btnb;
    public Button btnn;
    public Button btnm;
    public Button btnphay;
    public Button btncham;
    public Button btnxet;*/
    //img ban phim
    public GameObject btn1;
    public GameObject btn2;
    public GameObject btn3;
    public GameObject btn4;
    public GameObject btn5;
    public GameObject btn6;
    public GameObject btn7;
    public GameObject btn8;
    public GameObject btn9;
    public GameObject btn0;
    public GameObject btnq;
    public GameObject btnw;
    public GameObject btne;
    public GameObject btnr;
    public GameObject btnt;
    public GameObject btny;
    public GameObject btnu;
    public GameObject btni;
    public GameObject btno;
    public GameObject btnp;
    public GameObject btna;
    public GameObject btns;
    public GameObject btnd;
    public GameObject btnf;
    public GameObject btng;
    public GameObject btnh;
    public GameObject btnj;
    public GameObject btnk;
    public GameObject btnl;
    public GameObject btnchamp;
    //public GameObject btnmoh;
    public GameObject btnz;
    public GameObject btnx;
    public GameObject btnc;
    public GameObject btnv;
    public GameObject btnb;
    public GameObject btnn;
    public GameObject btnm;
    public GameObject btnphay;
    public GameObject btncham;
    public GameObject btnxet;
    public GameObject btnsQ;
    public GameObject btnsW;
    public GameObject btnsE;
    public GameObject btnsR;
    public GameObject btnsT;
    public GameObject btnsY;
    public GameObject btnsU;
    public GameObject btnsI;
    public GameObject btnsO;
    public GameObject btnsP;
    public GameObject btnsA;
    public GameObject btnsS;
    public GameObject btnsD;
    public GameObject btnsF;
    public GameObject btnsG;
    public GameObject btnsH;
    public GameObject btnsJ;
    public GameObject btnsK;
    public GameObject btnsL;
    //public GameObject btnchamp;
    //public GameObject btnmoh;
    public GameObject btnsZ;
    public GameObject btnsX;
    public GameObject btnsC;
    public GameObject btnsV;
    public GameObject btnsB;
    public GameObject btnsN;
    public GameObject btnsM;



    //time
    public float timeStart = 60;
    public Text textTime ;
    private int i= 1 ;
    //score
    public Text textAccurary;
    public Text textSpeed;
    public TextMeshProUGUI ttAccurary;
    public TextMeshProUGUI ttSpeed;
    public GameObject total;
    private float accurary = 0;
    private float tudung = 0;
    private float tusai = 0;
    bool iname = false;

    //save
    public GameObject menu;
    public GameObject name;
    public TextMeshProUGUI txtname;
    public Button xacnhan;
    string URL = "http://localhost/xampp/type_rank_insert.php";
    string URL_1 = "http://localhost/xampp/select_class.php";
    public string[] saveData;
    public TMP_InputField text_name;
    public TMP_Dropdown txt_class;
    List<string> option_class = new List<string> { };
    public string str_name;
    public string str_class;
    string str_level;
    bool endgame = true;
    level lv;

    // Start is called before the first frame update
    private void Start()
    {
        //total.SetActive(true);
        StartCoroutine(SelectClassAddDropdownlist(URL_1));
        SetCurrentWord();
        Time.timeScale = 0;
       textTime.text = timeStart.ToString();
        textAccurary.text = "0";
        textSpeed.text = "0";
        lv = wordBank.gameObject.GetComponent<level>();
        if (lv.tlevel == "BtnCB")
        {
            str_level = "0";
        }
        else if (lv.tlevel == "BtnHD")
        {
            str_level = "2";
        }
        else if (lv.tlevel == "BtnHT")
        {
            str_level = "1";
        }
        else if (lv.tlevel == "BtnPS")
        {
            str_level = "3";
        }
        else if (lv.tlevel == "BtnOT")
        {
            str_level = "4";
        }

        Debug.Log(str_level);
    }

    private void SetCurrentWord()
    {
        int j;
        currentWord = null;
        for( j = 0; j < 5; j++) 
        {
        currentWord += wordBank.GetRandomWord();
       // Debug.Log(currentWord);
        }
        j =0;
        if (str_level == null)
        {

        }
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string newString)
    {
        remainingWord = newString;
        wordOutput.text = "<color=red>"+ colorWord +"</color>" + remainingWord; 
        
         
    }


    // Update is called once per frame
     private void Update()
    {
        if (str_name == "")
        {

            Menu.SetActiveMenuTrue(total, name);

        }else
        {
            if (timeStart >= 0)
            {
                timeStart -= Time.deltaTime;
                textTime.text = Mathf.RoundToInt(timeStart).ToString();

                textAccurary.text = Mathf.RoundToInt(accurary).ToString();
                textSpeed.text = Mathf.RoundToInt(tudung).ToString();
                CheckInput();
                checkbp();

            }
            if (timeStart <= 0 && endgame == true)
            {
                total.SetActive(true);
                menu.SetActive(true);
                name.SetActive(false);
                ttAccurary.text = Mathf.RoundToInt(accurary).ToString();
                ttSpeed.text = Mathf.RoundToInt(tudung).ToString();
                StartCoroutine(AddRankType());
                endgame = false;
            }
        }

        

        
        //Debug.Log(timeStart);

    }


    //Hien bang nhap ten
    public void InputNameClass()
    {
        if (text_name.text != null)
        {
            str_name = text_name.text;
            Menu.SetActiveMenuFalse(total, name);
            Time.timeScale = 1;
            iname = true;
            Debug.Log(str_name);
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
    public IEnumerator AddRankType()
    {
        //data dung de post tuong ung mysql trong php
        Debug.Log(  str_level) ;
        WWWForm form = new WWWForm();
        form.AddField("addIDrank", System.DateTime.Now.ToFileTime().ToString());
        form.AddField("addnamerank", str_name);
        form.AddField("addclasrank", str_class);
        form.AddField("addaccuraryrank", accurary.ToString());
        form.AddField("addlevelrank", str_level);
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



    private void CheckInput()
    {
        //test = null;
        if (Input.anyKeyDown && iname == true)
        {
            //Debug.Log("100");
            string keysPressed = Input.inputString;
            if(IsCorrectLetter(keysPressed) == false)
            {
                tusai++;
            }
            if(keysPressed.Length ==1)
            {
                EnterLetter(keysPressed);

            }
           
                accurary = (tudung / (tusai + tudung)) * 100;
                Debug.Log(tudung);
                Debug.Log(tusai);
                Debug.Log(accurary);

            /*if(Input.GetKeyDown("a"))
            {
                test += Input.inputString;

            if(test=="a" &&Input.GetKeyDown("8"))
                {
                    test += Input.inputString;
                }
            if(test =="a8")
            {
             if(test.Length ==2)
            {
                EnterLetter("ă");
                if(test.Length ==2)
                {
                    test = null;
                }
            } 
            }
        }*/
            //  Debug.Log(keysPressed);
        }
    }


    private void EnterLetter(string typerLetter)
    {
        if(IsCorrectLetter(typerLetter))
        {
            if(i <= currentWord.Length)
            {
            colorWord = currentWord.Substring(0,i);
            i++;
            tudung++;
            }
           if(i > currentWord.Length)
            {
                colorWord = null;
                i=1;
            }
           
           
            RemoverLetter();
            
            if(IsWordComplete())
            {
                SetCurrentWord();
            }
            
           
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void RemoverLetter()
    {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete()
    {
        return remainingWord.Length ==  0;
    }
    
    private void checkscore()
    {
        //if

    }
    private void checkbp()
    {
        //btn1.GetComponent<Image>().color = Color.blue;
        btn1.gameObject.SetActive(false);
        btn2.gameObject.SetActive(false);
        btn3.gameObject.SetActive(false);
        btn4.gameObject.SetActive(false);
        btn5.gameObject.SetActive(false);
        btn6.gameObject.SetActive(false);
        btn7.gameObject.SetActive(false);
        btn8.gameObject.SetActive(false);
        btn9.gameObject.SetActive(false);
        btn0.gameObject.SetActive(false);
        btnq.gameObject.SetActive(false);
        btnw.gameObject.SetActive(false);
        btne.gameObject.SetActive(false);
        btnr.gameObject.SetActive(false);
        btnt.gameObject.SetActive(false);
        btny.gameObject.SetActive(false);
        btnu.gameObject.SetActive(false);
        btni.gameObject.SetActive(false);
        btno.gameObject.SetActive(false);
        btnp.gameObject.SetActive(false);
        btna.gameObject.SetActive(false);
        btns.gameObject.SetActive(false);
        btnd.gameObject.SetActive(false);
        btnf.gameObject.SetActive(false);
        btng.gameObject.SetActive(false);
        btnh.gameObject.SetActive(false);
        btnj.gameObject.SetActive(false);
        btnk.gameObject.SetActive(false);
        btnl.gameObject.SetActive(false);
        btnchamp.gameObject.SetActive(false);
        //btnmoh.gameObject.SetActive(false);
        btnz.gameObject.SetActive(false);
        btnx.gameObject.SetActive(false);
        btnc.gameObject.SetActive(false);
        btnv.gameObject.SetActive(false);
        btnb.gameObject.SetActive(false);
        btnn.gameObject.SetActive(false);
        btnm.gameObject.SetActive(false);
        btnphay.gameObject.SetActive(false);
        btncham.gameObject.SetActive(false);
        btnxet.gameObject.SetActive(false);

        btnsQ.gameObject.SetActive(false);
        btnsW.gameObject.SetActive(false);
        btnsE.gameObject.SetActive(false);
        btnsR.gameObject.SetActive(false);
        btnsT.gameObject.SetActive(false);
        btnsY.gameObject.SetActive(false);
        btnsU.gameObject.SetActive(false);
        btnsI.gameObject.SetActive(false);
        btnsO.gameObject.SetActive(false);
        btnsP.gameObject.SetActive(false);
        btnsA.gameObject.SetActive(false);
        btnsS.gameObject.SetActive(false);
        btnsD.gameObject.SetActive(false);
        btnsF.gameObject.SetActive(false);
        btnsG.gameObject.SetActive(false);
        btnsH.gameObject.SetActive(false);
        btnsJ.gameObject.SetActive(false);
        btnsK.gameObject.SetActive(false);
        btnsL.gameObject.SetActive(false);
      //  btnchamp.gameObject.SetActive(false);
        //btnmoh.gameObject.SetActive(false);
        btnsZ.gameObject.SetActive(false);
        btnsX.gameObject.SetActive(false);
        btnsC.gameObject.SetActive(false);
        btnsV.gameObject.SetActive(false);
        btnsB.gameObject.SetActive(false);
        btnsN.gameObject.SetActive(false);
        btnsM.gameObject.SetActive(false);

        if (remainingWord.Substring(0,1)== "1")
            {
                btn1.gameObject.SetActive(true);
             
            }
        if(remainingWord.Substring(0,1)== "2")
            {
                btn2.gameObject.SetActive(true);
              
            }
           if(remainingWord.Substring(0,1)== "3")
            {
                btn3.gameObject.SetActive(true);
               
            }
            if(remainingWord.Substring(0,1)== "4")
            {
                btn4.gameObject.SetActive(true);
               
            }
            if(remainingWord.Substring(0,1)== "5")
            {
                
                btn5.gameObject.SetActive(true);
                 
            }
            if(remainingWord.Substring(0,1)== "6")
            {
                
                btn6.gameObject.SetActive(true);
                
            }
            if(remainingWord.Substring(0,1)== "7")
            {
                btn7.gameObject.SetActive(true);
                
            }
            if(remainingWord.Substring(0,1)== "8")
            {
            
                btn8.gameObject.SetActive(true);
              
            } 
            if(remainingWord.Substring(0,1)== "9")
            {
                btn9.gameObject.SetActive(true);
              
            } 
            if(remainingWord.Substring(0,1)== "0")
            {
                btn0.gameObject.SetActive(true); 
            } 
             if(remainingWord.Substring(0,1)== "q")
            {
                btnq.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "w")
            {
                btnw.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "e")
            {
                btne.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "r")
            {
                btnr.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "t")
            {
                btnt.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "y")
            {
                btny.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "u")
            {
                btnu.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "i")
            {
                btni.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "o")
            {
                btno.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "p")
            {
                btnp.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "a")
            {
                btna.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "s")
            {
                btns.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "d")
            {
                btnd.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "f")
            {
                btnf.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "g")
            {
                btng.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "h")
            {
                btnh.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "j")
            {
                btnj.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "k")
            {
                btnk.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "l")
            {
                btnl.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== ";")
            {
                btnchamp.gameObject.SetActive(true);
            }
           /* if(remainingWord.Substring(0,1)== "'")
            {
                btnmoh.gameObject.SetActive(true);
            }*/
            if(remainingWord.Substring(0,1)== "z")
            {
                btnz.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "x")
            {
                btnx.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "c")
            {
                btnc.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "v")
            {
                btnv.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "b")
            {
                btnb.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "n")
            {
                btnn.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "m")
            {
                btnm.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== ",")
            {
                btnphay.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== ".")
            {
                btncham.gameObject.SetActive(true);
            }
            if(remainingWord.Substring(0,1)== "/")
            {
                btnxet.gameObject.SetActive(true);
            }
            //shift
        if (remainingWord.Substring(0, 1) == "Q")
        {
            btnsQ.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "W")
        {
            btnsW.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "E")
        {
            btnsE.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "R")
        {
            btnsR.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "T")
        {
            btnsT.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "Y")
        {
            btnsY.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "U")
        {
            btnsU.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "I")
        {
            btnsI.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "O")
        {
            btnsO.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "P")
        {
            btnsP.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "A")
        {
            btnsA.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "S")
        {
            btnsS.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "D")
        {
            btnsD.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "F")
        {
            btnsF.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "G")
        {
            btnsG.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "H")
        {
            btnsH.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "J")
        {
            btnsJ.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "K")
        {
            btnsK.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "L")
        {
            btnsL.gameObject.SetActive(true);
        }
       /* if (remainingWord.Substring(0, 1) == ";")
        {
            btnchamp.gameObject.SetActive(true);
        }
        /* if(remainingWord.Substring(0,1)== "'")
         {
             btnmoh.gameObject.SetActive(true);
         }*/
        if (remainingWord.Substring(0, 1) == "Z")
        {
            btnsZ.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "X")
        {
            btnsX.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "C")
        {
            btnsC.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "V")
        {
            btnsV.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "B")
        {
            btnsB.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "N")
        {
            btnsN.gameObject.SetActive(true);
        }
        if (remainingWord.Substring(0, 1) == "M")
        {
            btnsM.gameObject.SetActive(true);
        }

    }

}
