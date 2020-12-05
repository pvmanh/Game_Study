using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WordDoc : MonoBehaviour
{
 
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
    private int k = 0;
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
    private float accurary = 0;
    private float tudung = 0;
    private float tusai = 0;


    // Start is called before the first frame update
    void Start()
    {
        timeData.timegget = timeData.txt_time.text;
        wordListcb = catList(WordList, wordListcb, 0);

        getList();
        catchuoi();
        currentWord = Final;
        currentWord += " ";
        WordDocOP.text = Final;
        
         Debug.Log(Final);
        Debug.Log(stringgoc);

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
        if (tudung != 0 || tusai != 0)
        {
            accurary = (tudung / (tusai + tudung)) * 100;
        }
            //textTime.text = Mathf.RoundToInt(timeStart).ToString();
            textAccurary.text = Mathf.RoundToInt(accurary).ToString();
            textSpeed.text = Mathf.RoundToInt(tudung).ToString();
          
        getWord();
        colorWord();
    }
    void FixedUpdate()
    {
        Timer.TimeClock(timeData);
    }

    public void colorWord()
    {
        WordDocOP.text = reWord +currentWord;
    }
    void test()
    {

    }
    public void getWord()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
           // k++;
            if ( IPWord.text!=" "&& IPWord.text != "  " &&IPWord.text != "   " && IPWord.text != "    " && IPWord.text != "     ")
            {
                for (int i = 0; i < currentWord.Length; i++)
                {

                    if (currentWord.Substring(i, 1) == " ")
                    {
                        txtsai = null;
                        txtdung = null;
                        if (IPWord.text == currentWord.Substring(0, i + 1))
                        {
                            Debug.Log(currentWord.Substring(0, i));
                            txtdung = "<color=green>" + currentWord.Substring(0, i + 1) + "</color>";
                            currentWord = currentWord.Remove(0, i + 1);
                            reWord += txtdung;
                            tudung++;
                            Debug.Log(txtdung);
                        }
                        else if (IPWord.text != currentWord.Substring(0, i + 1))
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
                    }
                }
            }

            if (IPWord.text == "     ")
            {
                IPWord.text = null;
            }
            Debug.Log(currentWord+"1");
            if (currentWord.Length == 0)
            {
                total.SetActive(true);
                WordDocOP.gameObject.SetActive(false);
                IPWord.gameObject.SetActive(false);
                Time.timeScale = 0;
                ttAccurary.text = Mathf.RoundToInt(accurary).ToString();
                ttSpeed.text = Mathf.RoundToInt(tudung).ToString();
                ttTime.text = timeData.txt_time.text;
            }
        }
       /* else
        {
            k = 0;
        }*/
    }
}
