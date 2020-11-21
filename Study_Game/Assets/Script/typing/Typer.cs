using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Typer : MonoBehaviour
{ //Ngân Hàng Từ
    public WordBank wordBank =null;
    public TextMeshProUGUI wordOutput = null;

    public string test;

    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;

    private string colorWord = string.Empty ;

    public Button btn1;
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
    public Button btnxet;
    //time
    public float timeStart = 60;
    public Text textTime ;
    private int i= 1 ;

    // Start is called before the first frame update
     private void Start()
    {
       SetCurrentWord();
       textTime.text = timeStart.ToString();
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
        timeStart -= Time.deltaTime;
        textTime.text = Mathf.RoundToInt(timeStart).ToString();
        CheckInput();
        checkbp();
        
        
    }
    
    private void CheckInput()
    {
        //test = null;
        if(Input.anyKeyDown)
        {
            string keysPressed = Input.inputString;
           // Debug.Log(test);
            if(keysPressed.Length ==1)
            {
                EnterLetter(keysPressed);
            }
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
        btnmoh.gameObject.SetActive(false);
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
            if(remainingWord.Substring(0,1)== "'")
            {
                btnmoh.gameObject.SetActive(true);
            }
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
