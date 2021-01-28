using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayMath : MonoBehaviour
{
    public GameObject Area;
    public GameObject Area_Block;
    public GameObject Player;
    public GameObject Restart;
    public Material Outline_Run_Blox;
    public Material Outline_None_Blox;
    FunctionCenter Script_Player;
    public List<GameObject> ListActive = new List<GameObject>{};
    int i;
    float last_press_button;
    // Start is called before the first frame update
    void Start()
    {
        Script_Player = Player.GetComponent<FunctionCenter>();
    }
    public void Play_btn()
    {
        if(last_press_button > (Time.time - 0.5f)) 
            return;
        last_press_button = Time.time;
        ListActive.Clear();
        Area_Block.GetComponent<CanvasGroup>().blocksRaycasts = false;

        foreach(Transform child in Area.transform)
        {
            if(child.gameObject.GetComponent<BlockInfo>().isActive == true)
            {
                ListActive.Add(child.gameObject);
            }
        }
        GetComponent<CanvasGroup>().alpha = 0;
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        Restart.SetActive(true);
        StartCoroutine(Do_Play_Button());
    }
    public void Restart_btn()
    {   
        if(last_press_button > (Time.time - 1f)) 
            return;
        last_press_button = Time.time;
        
        StopAllCoroutines();

        Restart.SetActive(false);
        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        Area_Block.GetComponent<CanvasGroup>().blocksRaycasts = true;
        ListActive.Clear();
        StartCoroutine(WattingSetBeginPoint());
        Player.GetComponent<FunctionCenter>().Reset_Direction_Player();

        foreach(Transform child in Area.transform)
        {
            child.GetComponent<Image>().material = Outline_None_Blox;
        }
    }
    public void Clear_Area_Command_Btn()
    {
        foreach (Transform child in Area.transform)
        {
            if(child.GetComponent<BlockInfo>().Function_name != "")
            {
                Destroy(child.gameObject);
            }
        }
    }
    public IEnumerator Do_Play_Button()
    {
        if(ListActive.Count != 0)
        {
            for(i = 0; i < ListActive.Count; i++)
            {
                string Func_name = ListActive[i].GetComponent<BlockInfo>().Function_name;
                switch (Func_name)
                {
                    case "MoveForward":
                    {
                        ListActive[i].GetComponent<Image>().material = Outline_Run_Blox;
                        Script_Player.StartCoroutine(Func_name);
                        yield return new WaitForSeconds(0.5f);
                        ListActive[i].GetComponent<Image>().material = Outline_None_Blox;
                        break;
                    }
                    case "Turn_Away":
                    {
                        ListActive[i].GetComponent<Image>().material = Outline_Run_Blox;
                        int direction = ListActive[i].GetComponent<BlockInfo>().Mid_Contain.GetComponent<TMP_Dropdown>().value;
                        Script_Player.StartCoroutine(Func_name, direction);
                        yield return new WaitForSeconds(0.2f);
                        ListActive[i].GetComponent<Image>().material = Outline_None_Blox;
                        break;
                    }
                    case "LoopFuctionUntilGoal":
                    {
                        ListActive[i].GetComponent<Image>().material = Outline_Run_Blox;
                        GameObject Mid_Contain = ListActive[i].GetComponent<BlockInfo>().Mid_Contain;
                        Script_Player.StartCoroutine(Func_name, Mid_Contain);
                        yield return new WaitUntil(() => Player.GetComponent<FunctionCenter>().isHitItems == true);
                        ListActive[i].GetComponent<Image>().material = Outline_None_Blox;
                        break;
                    }
                    case "DeleteFromTarget":
                    {
                        ListActive[i].GetComponent<Image>().material = Outline_Run_Blox;
                        Script_Player.StartCoroutine(Func_name);
                        yield return new WaitForSeconds(0.2f);
                        ListActive[i].GetComponent<Image>().material = Outline_None_Blox;
                        break;
                    }
                    case "RepeatAfterNTurn":
                    {
                        ListActive[i].GetComponent<Image>().material = Outline_Run_Blox;
                        GameObject Mid_Contain = ListActive[i].GetComponent<BlockInfo>().Mid_Contain;
                        object[] parameters_func = new object[2]{Mid_Contain, int.Parse(ListActive[i].GetComponent<BlockInfo>().repeat_number.options[ListActive[i].GetComponent<BlockInfo>().repeat_number.value].text)};
                        Script_Player.StartCoroutine(Func_name, parameters_func);
                        yield return new WaitUntil(() => ListActive[i].GetComponent<BlockInfo>().int_variable == (int)parameters_func[1]);
                        ListActive[i].GetComponent<Image>().material = Outline_None_Blox;
                        break;
                    }
                }  
            }
            yield return null;
        }
    }
    public IEnumerator WattingSetBeginPoint()
    {
        yield return new WaitForSeconds(0.5f);
        Player.transform.localPosition = Player.GetComponent<FunctionCenter>().GUI_Math.GetComponent<GUIPlayerGridGame>().SpawnPoint;
        Player.GetComponent<Animator>().SetBool("isHole", false);
        Player.GetComponent<Animator>().SetBool("isMove", false);
    }
}
