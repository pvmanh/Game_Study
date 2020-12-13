using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIPlayerGridGame : MonoBehaviour
{
    [System.Serializable]
    public struct Math_Value_Operator
    {
        public string Number_First;
        public string Number_Second;
        public string Number_Result;

    }
    [Header("Box Setting")]
    public List<GameObject> List_Grid_Blox;
    public List<TextMeshProUGUI> List_Show_Number_Text;
    public TextMeshProUGUI Operator_Text;
    public Math_Value_Operator List_Number_Operator;
    public GameObject Number_Blox;
    public GameObject Hole_Blox;
    List<GameObject> Container_List_Grid_Blox = new List<GameObject>{};
    int iR;
    bool isCompleteMath;
    // Start is called before the first frame update
    void Start()
    {
        Random_Operator_Math(Operator_Text.text);
        List_Show_Number_Text[0].text = List_Number_Operator.Number_First;
        List_Show_Number_Text[1].text = List_Number_Operator.Number_Second;
        List_Show_Number_Text[2].text = List_Number_Operator.Number_Result;
        
        List_Show_Number_Text[iR - 1].color = new Color32(255, 0, 0, 255);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Random_Operator_Math(string Operator_Math)
    {
        switch(Operator_Math)
        {
            case "+":
            {
                iR = Random.Range(1, 3);
                if(iR == 1)
                {
                    List_Number_Operator.Number_First = "?";
                    List_Number_Operator.Number_Second = Random.Range(0, 99).ToString();
                    List_Number_Operator.Number_Result = Random.Range(int.Parse(List_Number_Operator.Number_Second), 99).ToString();
                }
                else if(iR == 2)
                {
                    List_Number_Operator.Number_First = Random.Range(0, 99).ToString();
                    List_Number_Operator.Number_Second = "?";
                    List_Number_Operator.Number_Result = Random.Range(int.Parse(List_Number_Operator.Number_First), 99).ToString();
                }
                else if(iR == 3)
                {
                    List_Number_Operator.Number_First = Random.Range(0, 99).ToString();
                    List_Number_Operator.Number_Second = Random.Range(0, 99).ToString();
                    List_Number_Operator.Number_Result = "?";
                }
                break;
            }  
            case "-":
                //Do something
                break;
            case "*":
                //Do something
                break;
            case "/":
                //Do something
                break;
        }
    }
    List<GameObject> Get_List_Grid_GameObject()
    {
        Container_List_Grid_Blox.Clear();
        Container_List_Grid_Blox.AddRange(List_Grid_Blox);
        return Container_List_Grid_Blox;
    }

    int Random_Position_Block()
    {
        int iNum = Random.Range(0, Container_List_Grid_Blox.Count);
        Container_List_Grid_Blox.RemoveAt(iNum);
        return iNum;
    }
}
