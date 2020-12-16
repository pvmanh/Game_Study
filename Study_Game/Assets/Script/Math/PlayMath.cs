using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayMath : MonoBehaviour
{
    public GameObject Area;
    public GameObject Player;
    public GameObject Restart;
    public Material Outline_Run_Blox;
    public Material Outline_None_Blox;
    FunctionCenter Script_Player;
    public List<GameObject> ListActive = new List<GameObject>{};
    // Start is called before the first frame update
    void Start()
    {
        Script_Player = Player.GetComponent<FunctionCenter>();
    }
    public void Play_btn()
    {
        ListActive.Clear();

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
        Restart.SetActive(false);
        GetComponent<CanvasGroup>().alpha = 1;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
    public IEnumerator Do_Play_Button()
    {
        if(ListActive.Count != 0)
        {
            for(int i = 0; i < ListActive.Count; i++)
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
                }  
            }
        }
    }
}
