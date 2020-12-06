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

    //save
    public GameObject menu;
    public GameObject name;
    public TextMeshProUGUI txtname;
    public Button xacnhan;
    string URL_1 = "http://localhost/xampp/select_class.php";
    public string[] saveData;
    public TMP_InputField text_name;
    public TMP_Dropdown txt_class;
    List<string> option_class = new List<string> { };
    string str_name;
    string str_class;

    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(SelectClassAddDropdownlist(URL_1));
        SetCurrentWord();
       textTime.text = timeStart.ToString();
        textAccurary.text = "0";
        textSpeed.text = "0";
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
            if (timeStart <= 0)
            {
                total.SetActive(true);
                menu.SetActive(true);
                name.SetActive(false);
                ttAccurary.text = Mathf.RoundToInt(accurary).ToString();
                ttSpeed.text = Mathf.RoundToInt(tudung).ToString();

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



    private void CheckInput()
    {
        //test = null;
        if(Input.anyKeyDown)
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
         if(remainingWord.Substring(0,1)== "1")
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


    }

}
