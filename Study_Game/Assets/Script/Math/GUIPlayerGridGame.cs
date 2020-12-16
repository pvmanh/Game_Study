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
    public Transform Math_Round_Object;
    public GameObject Player;
    public Vector2[,] List_Grid_Blox = new Vector2[5,9];
    public bool[,] List_Grid_Blox_Value = new bool[5,9];
    public List<TextMeshProUGUI> List_Show_Number_Text;
    public TextMeshProUGUI Operator_Text;
    public Math_Value_Operator List_Number_Operator;
    public GameObject Number_Blox;
    public GameObject Hole_Blox;
    List<int> Container_List_Grid_Blox = new List<int>{};
    int iR;
    List<int> iPoint = new List<int>{};
    public bool isCompleteMath = false;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        List_Grid_Blox = Create_List_Grid(); 
        Get_List_Grid_GameObject();
        ReloadMathRound();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCompleteMath == true)
        {
            ClearMathRound();
            ReloadMathRound();
            isCompleteMath = false;
        }
    }
    //tao ngau nhien bai toan
    void Random_Operator_Math(string Operator_Math)
    {
        switch(Operator_Math)
        {
            case "+":
            {
                iR = Random.Range(1,3);
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
    //Tao danh sach offset Vector
    Vector2[,] Create_List_Grid()
    {
        Vector2 offset_grid = new Vector2(-1.5f, 0.5f);
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 9; j++)
            {
                List_Grid_Blox[i,j] = offset_grid;
                offset_grid.x -= 1f; 

                if(i == 0 && j ==0)
                    List_Grid_Blox_Value[i,j] = true;
                else
                    List_Grid_Blox_Value[i,j] = false;
            }
            offset_grid.x = -1.5f;
            offset_grid.y -= 1f;
        }
        return List_Grid_Blox;
    }
    //tao lai danh sach grid
    List<int> Get_List_Grid_GameObject()
    {
        Container_List_Grid_Blox.Clear();
        for(int i = 0; i < List_Grid_Blox.Length; i++)
        {
            Container_List_Grid_Blox.Add(i);
        }
        return Container_List_Grid_Blox;
    }
    //random trong mang 2 chieu
    List<int> RandomArrayGrid()
    {
        iPoint.Clear();

        int i_x = Random.Range(0, 4);
        int i_y = Random.Range(0, 8);

        if(List_Grid_Blox_Value[i_x, i_y] == true)
        {
            RandomArrayGrid();
        }
        else if(List_Grid_Blox_Value[i_x, i_y] == false)
        {
            List_Grid_Blox_Value[i_x, i_y] = true;
            iPoint.Add(i_x);
            iPoint.Add(i_y);
        }

        return iPoint;
    }
    //Xu ly xong man dau
    void ClearMathRound()
    {
        List_Show_Number_Text[0].color = new Color32(255, 255, 255, 255);
        List_Show_Number_Text[1].color = new Color32(255, 255, 255, 255);
        List_Show_Number_Text[2].color = new Color32(255, 255, 255, 255);

        //Destroy items
        foreach(Transform child in Math_Round_Object)
        {
            Destroy(child.gameObject);
        }

        //Reset value
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 9; j++)
            {
                if(Player.transform.localPosition == new Vector3(List_Grid_Blox[i, j].x, List_Grid_Blox[i, j].y, 0))
                {
                    List_Grid_Blox_Value[i,j] = true;
                }
                else
                    List_Grid_Blox_Value[i,j] = false;
                Debug.Log(List_Grid_Blox_Value[i,j]);
            }
        }
    }
    //Tai lai vong choi
   void ReloadMathRound()
    {
        Random_Operator_Math(Operator_Text.text);
        //Gan gia tri thu nhat cua phep toan
        List_Show_Number_Text[0].text = List_Number_Operator.Number_First;
        //Gan gia tri thu hai cua phep toan
        List_Show_Number_Text[1].text = List_Number_Operator.Number_Second;
        //Gan gia tri thu ba cua phep toan
        List_Show_Number_Text[2].text = List_Number_Operator.Number_Result;
        //gan an so bangg mau khac
        List_Show_Number_Text[iR - 1].color = new Color32(255, 0, 0, 255);

        //tao block thu 2
        var blox_1 = CutPuzzle.CreateObject(Number_Blox, Math_Round_Object);
        iPoint = RandomArrayGrid(); //random vi tri trong mang 2 chieu
        //tranform vi tri theo vector grid dc tao ra theo vi tri random trong mag
        blox_1.transform.localPosition = new Vector3(List_Grid_Blox[iPoint[0], iPoint[1]].x, List_Grid_Blox[iPoint[0], iPoint[1]].y, 0);
        //kiem tra an tinh toan gan gia tri dung gan vao TMP
        if(List_Number_Operator.Number_First == "?")
        {
            blox_1.transform.GetChild(0).GetComponent<TextMeshPro>().text = (int.Parse(List_Number_Operator.Number_Result) - int.Parse(List_Number_Operator.Number_Second)).ToString();
        }
        else if(List_Number_Operator.Number_Second == "?")
        {
            blox_1.transform.GetChild(0).GetComponent<TextMeshPro>().text = (int.Parse(List_Number_Operator.Number_Result) - int.Parse(List_Number_Operator.Number_First)).ToString();
        }
        else if(List_Number_Operator.Number_Result == "?")
        {
            blox_1.transform.GetChild(0).GetComponent<TextMeshPro>().text = (int.Parse(List_Number_Operator.Number_First) + int.Parse(List_Number_Operator.Number_Second)).ToString();
        }
        //tao block thu 2
        var blox_2 = CutPuzzle.CreateObject(Number_Blox, Math_Round_Object);
        //Random so bat ky gan vao TMP
        blox_2.transform.GetChild(0).GetComponent<TextMeshPro>().text = Random.Range(0,99).ToString();
        iPoint = RandomArrayGrid(); //random vi tri trong mang 2 chieu
        //tranform vi tri theo vector grid dc tao ra theo vi tri random trong mag
        blox_2.transform.localPosition = new Vector3(List_Grid_Blox[iPoint[0], iPoint[1]].x, List_Grid_Blox[iPoint[0], iPoint[1]].y, 0);

        var blox_3 = CutPuzzle.CreateObject(Number_Blox, Math_Round_Object);
        //Random so bat ky gan vao TMP
        blox_3.transform.GetChild(0).GetComponent<TextMeshPro>().text = Random.Range(0,99).ToString();
        iPoint = RandomArrayGrid(); //random vi tri trong mang 2 chieu
        //tranform vi tri theo vector grid dc tao ra theo vi tri random trong mag
        blox_3.transform.localPosition = new Vector3(List_Grid_Blox[iPoint[0], iPoint[1]].x, List_Grid_Blox[iPoint[0], iPoint[1]].y, 0);

        var blox_4 = CutPuzzle.CreateObject(Number_Blox, Math_Round_Object);
        //Random so bat ky gan vao TMP
        blox_4.transform.GetChild(0).GetComponent<TextMeshPro>().text =  Random.Range(0,99).ToString();
        iPoint = RandomArrayGrid(); //random vi tri trong mang 2 chieu
        //tranform vi tri theo vector grid dc tao ra theo vi tri random trong mag
        blox_4.transform.localPosition = new Vector3(List_Grid_Blox[iPoint[0], iPoint[1]].x, List_Grid_Blox[iPoint[0], iPoint[1]].y, 0);
    }
}
