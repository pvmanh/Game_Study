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
    public GameObject Play_btn;
    public GameObject Math_Menu;
    public GameObject Menu_Data;
    public GameObject SFX;
    public Vector2[,] List_Grid_Blox = new Vector2[5,9];
    public bool[,] List_Grid_Blox_Value = new bool[5,9];
    public List<TextMeshProUGUI> List_Show_Number_Text;
    public TextMeshProUGUI Operator_Text;
    public Math_Value_Operator List_Number_Operator;
    public GameObject Number_Blox;
    public GameObject Hole_Blox;
    public List<GameObject> List_Tool_Has;

    public int A_min = 0;
    public int B_max = 1000;
    public Button B_max_1000;
    public Button B_max_100;
    List<int> Container_List_Grid_Blox = new List<int>{};
    int iR;
    int Number_rand;
    List<int> iPoint = new List<int>{};
    public GameObject go_Notification;
    public GameObject backgroundNotForClick;
    public bool isCompleteMath = false;
    int Result_1;
    public Vector3 SpawnPoint;
    public string LastVectorPoint;
    int iNumber_Checked = 0;
    bool isChecked;
    bool isFalse;
    int number_hole;
    int number_success;
    private void Start() 
    {   
        Time.timeScale = 0;
        Player.GetComponent<SpriteRenderer>().sortingOrder = 0;
    }
    // Update is called once per frame
    void Update()
    {   
        if(Math_Menu.activeSelf == true)
        {
            Menu_Data.GetComponent<MenuDragController>().menuData.isMenuActive = true;
        }
        if(Menu_Data.transform.GetChild(0).gameObject.activeSelf == true)
        {
            Sorting_Order_GameObject_To_Zero();
        }

        Check_Result_Run_One_Time();

        if(isChecked == true)
        {
            Math_Check_Result(Operator_Text.text);
            isChecked = false;
        }

        if(isCompleteMath == true)
        {
            ClearMathRound();
            ReloadMathRound();
            isCompleteMath = false;
            iNumber_Checked = 0;
            SpawnPoint = Player.transform.localPosition;
            LastVectorPoint = Player.GetComponent<FunctionCenter>().Player_side.ToString(); 
        } 
    }
    public void ShowRangePlusMinusSelect(string Operator_Math_txt)
    {
        B_max_1000.gameObject.SetActive(true);
        B_max_100.gameObject.SetActive(true);

        B_max_1000.onClick.AddListener(delegate{Select_Operator_Math(Operator_Math_txt);});
        B_max_100.onClick.AddListener(delegate{Select_Operator_Math(Operator_Math_txt);});

        Math_Menu.SetActive(false);
    }
    public void OffRangePlusMinusSelect()
    {
        B_max_1000.gameObject.SetActive(false);
        B_max_100.gameObject.SetActive(false);
    }
    public void MaxPlusMinusRange(int maxPlusMinus)
    {
        B_max = maxPlusMinus;
    }
    //Btn menu chon phep toan
    public void Select_Operator_Math(string Operator_Math_txt)
    {
        Time.timeScale = 1;

        Operator_Text.text = Operator_Math_txt;

        number_hole = 0;
        number_success = 0;
        
        Player = GameObject.Find("Player");
        List_Grid_Blox = Create_List_Grid(); 
        Get_List_Grid_GameObject();
        ReloadMathRound();

        SpawnPoint = Player.transform.localPosition;
        LastVectorPoint = Player.GetComponent<FunctionCenter>().Player_side.ToString();

        Math_Menu.SetActive(false);
        backgroundNotForClick.SetActive(false);
        Player.GetComponent<SpriteRenderer>().sortingOrder = 1;
        Menu_Data.GetComponent<MenuDragController>().menuData.isMenuActive = false;
    }
    public void Sorting_Order_GameObject_To_Zero()
    {
        Player.GetComponent<SpriteRenderer>().sortingOrder = 0;
        foreach(Transform child in Math_Round_Object)
        {
            child.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
    }
    public void Sorting_Order_GameObject_To_One()
    {
        Player.GetComponent<SpriteRenderer>().sortingOrder = 1;
        foreach(Transform child in Math_Round_Object)
        {
            if(child.tag == "Hole")
                child.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
    //Kiem tra da nhan number
    void Check_Result_Run_One_Time()
    {
        if(List_Number_Operator.Number_First != "" && List_Number_Operator.Number_Second != "" && List_Number_Operator.Number_Result != "")
        {
            if(List_Number_Operator.Number_First != "?" && List_Number_Operator.Number_Second != "?" && List_Number_Operator.Number_Result != "?" && iNumber_Checked == 0)
            {
                isChecked = true;
                iNumber_Checked++;
            }
        }
    }
    //check math to continues
    void Math_Check_Result(string Operator_Math)
    {
        switch(Operator_Math)
        {
            case "+":
            {
                Result_1 = int.Parse(List_Number_Operator.Number_First) + int.Parse(List_Number_Operator.Number_Second);
                break;
            }  
            case "-":
            {
                Result_1 = int.Parse(List_Number_Operator.Number_First) - int.Parse(List_Number_Operator.Number_Second);
                break;
            }
            case "*":
            {
                Result_1 = int.Parse(List_Number_Operator.Number_First) * int.Parse(List_Number_Operator.Number_Second);
                break;
            }
            case "/":
            {
                Result_1 = int.Parse(List_Number_Operator.Number_First) / int.Parse(List_Number_Operator.Number_Second);
                break;
            }
        }

        if(Result_1 == int.Parse(List_Number_Operator.Number_Result))
        {
            foreach(Transform child in Math_Round_Object)
            {
                child.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            StartCoroutine(Waiting_Report_Per_Check_Result("Đúng rồi!"));
            number_success++;
            if(number_hole != 5)
                number_hole++;
                
            if(number_success == 2)
            {
                List_Tool_Has[2].SetActive(true);
            }
            else if(number_success == 4)
            {
                List_Tool_Has[4].SetActive(true);
            }
            else if(number_success == 6)
            {
                List_Tool_Has[3].SetActive(true);
            }
        }
        else
        {
            foreach(Transform child in Math_Round_Object)
            {
                child.GetComponent<SpriteRenderer>().sortingOrder = 0;
            }
            StartCoroutine(Waiting_Report_Per_Check_Result("Sai rồi!"));
            isFalse = true;
            Player.GetComponent<FunctionCenter>().Reset_Direction_Player();
        }
    }
    //Thong bao ket qua
    IEnumerator Waiting_Report_Per_Check_Result(string Notification_str)
    {
        Player.GetComponent<SpriteRenderer>().sortingOrder = 0;
        backgroundNotForClick.SetActive(true);
        var Notification_new = Instantiate(go_Notification, backgroundNotForClick.transform);
        Notification_new.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = Notification_str;
        if(Notification_str == "Đúng rồi!")
            SFX.GetComponent<AudioManager>().soundEffectsAudio[1].Play();
        else if(Notification_str == "Sai rồi!")
            SFX.GetComponent<AudioManager>().soundEffectsAudio[2].Play();

        yield return new WaitForSeconds(2f);

        Destroy(Notification_new);
        backgroundNotForClick.SetActive(false);
        Play_btn.GetComponent<PlayMath>().Restart_btn();
        Play_btn.GetComponent<PlayMath>().Clear_Area_Command_Btn();
        Player.GetComponent<SpriteRenderer>().sortingOrder = 1;  
        isCompleteMath = true; 
    }
    //tao ngau nhien bai toan
    void Random_Operator_Math(string Operator_Math)
    {
        iR = 3;
        switch(Operator_Math)
        {
            case "+":
            {
                //iR = Random.Range(1,3);
                /*if(iR == 1)
                {
                    List_Number_Operator.Number_First = "?";
                    List_Number_Operator.Number_Second = Random.Range(0, 101).ToString();
                    List_Number_Operator.Number_Result = Random.Range(int.Parse(List_Number_Operator.Number_Second), 101).ToString();
                }
                else if(iR == 2)
                {
                    List_Number_Operator.Number_First = Random.Range(0, 101).ToString();
                    List_Number_Operator.Number_Second = "?";
                    List_Number_Operator.Number_Result = Random.Range(int.Parse(List_Number_Operator.Number_First), 101).ToString();
                }
                else*/ if(iR == 3)
                {
                    //List_Number_Operator.Number_First = Random.Range(0, 101).ToString();
                    //List_Number_Operator.Number_Second = Random.Range(0, 101).ToString();
                    //List_Number_Operator.Number_Result = "?";
                    Number_rand = Random.Range(A_min, B_max);
                    List_Number_Operator.Number_First = Random.Range(A_min, Number_rand).ToString();
                    List_Number_Operator.Number_Second = (Number_rand - int.Parse(List_Number_Operator.Number_First)).ToString();
                    List_Number_Operator.Number_Result = "?";
                }
                
                break;
            }  
            case "-":
            {    
                //iR = Random.Range(1,3);
                if(iR == 1)
                {
                    List_Number_Operator.Number_First = "?";
                    List_Number_Operator.Number_Second = Random.Range(0, 101).ToString();
                    List_Number_Operator.Number_Result = Random.Range(0, int.Parse(List_Number_Operator.Number_Second)).ToString();
                }
                else if(iR == 2)
                {
                    List_Number_Operator.Number_First = Random.Range(0, 101).ToString();
                    List_Number_Operator.Number_Second = "?";
                    List_Number_Operator.Number_Result = Random.Range(0, int.Parse(List_Number_Operator.Number_First)).ToString();
                }
                else if(iR == 3)
                {
                    //List_Number_Operator.Number_First = Random.Range(0, 101).ToString();
                    //List_Number_Operator.Number_Second = Random.Range(0, int.Parse(List_Number_Operator.Number_First)).ToString();
                    //List_Number_Operator.Number_Result = "?";
                    List_Number_Operator.Number_First = Random.Range(A_min, B_max).ToString();
                    List_Number_Operator.Number_Second = Random.Range(A_min, int.Parse(List_Number_Operator.Number_First)).ToString();
                    List_Number_Operator.Number_Result = "?";
                }
                break;
            }
            case "*":
            {    
                //iR = Random.Range(1,3);
                if(iR == 1)
                {
                    Number_rand = Random.Range(0, 10);
                    List_Number_Operator.Number_First = "?";
                    List_Number_Operator.Number_Second = Random.Range(0, 10).ToString();
                    List_Number_Operator.Number_Result = (int.Parse(List_Number_Operator.Number_Second) * Number_rand).ToString();
                }
                else if(iR == 2)
                {
                    Number_rand = Random.Range(0, 10);
                    List_Number_Operator.Number_First = Random.Range(0, 10).ToString();
                    List_Number_Operator.Number_Second = "?";
                    List_Number_Operator.Number_Result = (int.Parse(List_Number_Operator.Number_First) * Number_rand).ToString();
                }
                else if(iR == 3)
                {

                    List_Number_Operator.Number_First = Random.Range(0, 10).ToString();
                    List_Number_Operator.Number_Second = Random.Range(0, 10).ToString();
                    List_Number_Operator.Number_Result = "?";
                }
                break;
            }
            case "/":
            {
                iR = Random.Range(1,3);
                if(iR == 1)
                {
                    List_Number_Operator.Number_First = "?";
                    List_Number_Operator.Number_Second = Random.Range(1, 10).ToString();
                    List_Number_Operator.Number_Result = Random.Range(0, 10).ToString();
                }
                else if(iR == 2)
                {
                    Number_rand = Random.Range(1, 10);
                    List_Number_Operator.Number_Second = "?";
                    List_Number_Operator.Number_Result = Random.Range(0, 10).ToString();
                    List_Number_Operator.Number_First = (int.Parse(List_Number_Operator.Number_Result) * Number_rand).ToString();
                }
                else if(iR == 3)
                {
                    Number_rand = Random.Range(0, 10);
                    List_Number_Operator.Number_Second = Random.Range(1, 10).ToString();
                    List_Number_Operator.Number_Result = "?";
                    List_Number_Operator.Number_First = (int.Parse(List_Number_Operator.Number_Result) * Number_rand).ToString();
                }
                break;
            }
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

        int i_x = Random.Range(0, 5);
        int i_y = Random.Range(0, 9);

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

        if(isFalse == true)
        {
            Player.transform.localPosition = SpawnPoint;
            isFalse = false;
        }

        Vector3 Player_Stant = new Vector3(Mathf.Round(Player.transform.localPosition.x * 100.0f) / 100.0f, Mathf.Round(Player.transform.localPosition.y * 100.0f) / 100.0f, 0);
        Debug.Log(Player_Stant);
        //Reset value
        for(int i = 0; i < 5; i++)
        {
            for(int j = 0; j < 9; j++)
            {
                if(Player_Stant == new Vector3(List_Grid_Blox[i, j].x, List_Grid_Blox[i, j].y, 0))
                {
                    List_Grid_Blox_Value[i,j] = true;
                }
                else
                    List_Grid_Blox_Value[i,j] = false;
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

        switch (Operator_Text.text)
        {
            case "+":
            {
                //kiem tra an tinh toan gan gia tri dung gan vao TMP
                if(List_Number_Operator.Number_First == "?")
                {
                    Number_rand = int.Parse(List_Number_Operator.Number_Result) - int.Parse(List_Number_Operator.Number_Second);
                }
                else if(List_Number_Operator.Number_Second == "?")
                {
                    Number_rand = int.Parse(List_Number_Operator.Number_Result) - int.Parse(List_Number_Operator.Number_First);
                }
                else if(List_Number_Operator.Number_Result == "?")
                {
                    Number_rand = int.Parse(List_Number_Operator.Number_First) + int.Parse(List_Number_Operator.Number_Second);
                }

                for(int i = 0; i < 4; i++)
                {
                    Create_Random_Number_Box(Random.Range(A_min, Number_rand));
                }

                break;
            }  
            case "-":
            {
                //kiem tra an tinh toan gan gia tri dung gan vao TMP
                if(List_Number_Operator.Number_First == "?")
                {
                    Number_rand = int.Parse(List_Number_Operator.Number_Result) + int.Parse(List_Number_Operator.Number_Second);
                }
                else if(List_Number_Operator.Number_Second == "?")
                {
                    Number_rand = int.Parse(List_Number_Operator.Number_First) - int.Parse(List_Number_Operator.Number_Result);
                }
                else if(List_Number_Operator.Number_Result == "?")
                {
                    Number_rand = int.Parse(List_Number_Operator.Number_First) - int.Parse(List_Number_Operator.Number_Second);
                }

                for(int i = 0; i < 4; i++)
                {
                    Create_Random_Number_Box(Random.Range(A_min, Number_rand));
                }

                break;
            }
            case "*":
            { 
                //kiem tra an tinh toan gan gia tri dung gan vao TMP
                if(List_Number_Operator.Number_Result == "?")
                {
                    Number_rand = int.Parse(List_Number_Operator.Number_First) * int.Parse(List_Number_Operator.Number_Second);
                }
                for(int i = 0; i < 4; i++)
                {
                    Create_Random_Number_Box(Random.Range(0, 100));
                }
                break;
            }
            case "/":
            {
                //kiem tra an tinh toan gan gia tri dung gan vao TMP
                if(iR == 1)
                {
                    Number_rand = int.Parse(List_Number_Operator.Number_Second) * int.Parse(List_Number_Operator.Number_Result);
                }
                for(int i = 0; i < 4; i++)
                {
                    Create_Random_Number_Box(Random.Range(0, 10));
                }
                break;
            }
        }
        
        Create_Random_Number_Box(Number_rand);
                
        for(int j = 0; j < number_hole; j++)
        {
            var blox_hole = CutPuzzle.CreateObject(Hole_Blox, Math_Round_Object);
            iPoint = RandomArrayGrid();
            blox_hole.transform.localPosition = new Vector3(List_Grid_Blox[iPoint[0], iPoint[1]].x, List_Grid_Blox[iPoint[0], iPoint[1]].y, 0);
        }
    }
    //Create Random Number
    void Create_Random_Number_Box(int Number_rand)
    {
        var blox_0 = CutPuzzle.CreateObject(Number_Blox, Math_Round_Object);
        //Random so bat ky gan vao TMP
        blox_0.transform.GetChild(0).GetComponent<TextMeshPro>().text = Number_rand.ToString();
        iPoint = RandomArrayGrid(); //random vi tri trong mang 2 chieu
        //tranform vi tri theo vector grid dc tao ra theo vi tri random trong mag
        blox_0.transform.localPosition = new Vector3(List_Grid_Blox[iPoint[0], iPoint[1]].x, List_Grid_Blox[iPoint[0], iPoint[1]].y, 0);
    }
}
