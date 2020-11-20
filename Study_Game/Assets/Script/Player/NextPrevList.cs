using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextPrevList : MonoBehaviour
{
    private GameObject[] ListPuzzle;
    private GameObject HoldPuzzle;
    private int j = 0;
    // Start is called before the first frame update
    void Start()
    {
        ListPuzzle = new GameObject[this.transform.childCount];
        foreach (Transform ChildPuzzle in this.transform)  
        {
            ListPuzzle[j] = ChildPuzzle.gameObject;
            j++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        PrevNextList();
    }

    void PrevNextList()
    {
        var MouseSwheel = Input.GetAxis("Mouse ScrollWheel");
        if(MouseSwheel > 0f)
        {
            ListPuzzle[0].transform.SetAsLastSibling();
            
            for(int i = 0; i < ListPuzzle.Length; i++)
            {
                if(i == 0)
                {
                    HoldPuzzle = ListPuzzle[i];
                    ListPuzzle[i] = ListPuzzle[i+1];
                   
                }
                else if(i != 0 && i != (ListPuzzle.Length - 1))
                {
                    ListPuzzle[i] = ListPuzzle[i+1];
                }
                else if(i == (ListPuzzle.Length - 1))
                {
                    ListPuzzle[i] = HoldPuzzle;
                }
            }
        }
        else if(MouseSwheel < 0f)
        {
            ListPuzzle[ListPuzzle.Length-1].transform.SetAsFirstSibling();
            
            for(int i = (ListPuzzle.Length-1); i >= 0 ; i--)
            {
                if(i == 0)
                {
                    ListPuzzle[i] = HoldPuzzle;
                }
                else if(i != 0 && i != (ListPuzzle.Length-1))
                {
                    ListPuzzle[i] = ListPuzzle[i-1];
                }
                else if(i == (ListPuzzle.Length-1))
                {
                    HoldPuzzle = ListPuzzle[i];
                    ListPuzzle[i] = ListPuzzle[i-1]; 
                }
            }
        }
    }
}
