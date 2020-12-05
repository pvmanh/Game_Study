using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scut : MonoBehaviour
{
    //public Text iText;
    public string sChuoi_Input;
    string A;
    string Final;
    // Start is called before the first frame update
    void Start()
    {
        A = sChuoi_Input;
        catchuoi();

        //iText.text = Final;
    }
    void catchuoi()
    {   
        for(int i = 0; i < sChuoi_Input.Length; i++)
        {
            if(A.IndexOf(" ") >= 0)
            {
                string B = A.Remove(A.IndexOf(" "));
                A = A.Substring(A.IndexOf(" "));

                

                if(B.Length != 0)
                {
                    Final += B + " ";
                }
                else if(B.Length == 0)
                {
                    A = A.Remove(0,1);
                }
            }
            else
            {
                Final += A;
                i = sChuoi_Input.Length;
                Debug.Log(Final.Length);
            }
        }

        
    }
}
