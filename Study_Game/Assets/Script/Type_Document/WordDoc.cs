using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WordDoc : MonoBehaviour
{

    public List<string> WordList = new List<string> { };
    public string[] wordListcb;
    public GameObject GO;
    public TextMeshProUGUI WordDocOP;
    public TMP_InputField IPWord;
    private string currentWord = string.Empty;
    private string reWord = string.Empty;
    private string tudung = string.Empty;
    private string tusai = string.Empty;
    // Start is called before the first frame update
    void Start()
    {
        wordListcb = catList(WordList, wordListcb, 0);
        getList();
       // Debug.Log(wordListcb);
       

    }

    public static string[] catList(List<string> List, string[] StringList, int i)
    {
        StringList = new string[1];
        StringList[0] = List[i];
        return StringList;
    }
    public void getList()
    {
        currentWord = wordListcb[0];
        WordDocOP.text = wordListcb[0];
        Debug.Log(WordDocOP.text);    
    }

    // Update is called once per frame
    void Update()
    {
         getWord();
        colorWord();
    }

    public void colorWord()
    {
        WordDocOP.text = reWord +currentWord;
    }
    public void getWord()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            for (int i =0; i < currentWord.Length; i++)
            {
      
                if (currentWord.Substring(i, 1) == " ")
                {
                    tusai = null;
                    tudung = null;
                    if (IPWord.text == currentWord.Substring(0,i+1))
                    {
                        //Debug.Log(currentWord.Substring(0, i));
                        tudung = "<color=green>" + currentWord.Substring(0, i+1) + "</color>";
                        currentWord = currentWord.Remove(0, i+1);
                        reWord += tudung;
                        Debug.Log(tudung);
                    }
                   else if(IPWord.text != currentWord.Substring(0, i+1))
                    {
                        
                        tusai = "<color=red>" +  currentWord.Substring(0, i+1) + "</color>";
                       currentWord = currentWord.Remove(0, i+1);
                        reWord += tusai;
                        Debug.Log(tusai);

                    }
                    i = currentWord.Length;
                    IPWord.text = null;
                    //Debug.Log(tudung);
                    //Debug.Log(tusai);
                }
            }
        }
    }
}
