using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FunctionCenter : MonoBehaviour
{
    public enum Player_Side
    {
        Up,
        Right,
        Down,
        Left
    }
    public Player_Side Player_side;
    public GameObject GUI_Math;
    public List<Sprite> Arrow_Player;
    public Material Outline_Run_Blox;
    public Material Outline_None_Blox;
    Vector3 Side_Vector_Player;
    Vector3 startPos;
    Vector3 nextPos;
    Animator Player_Animator;
    public LayerMask whatStopsMoveMent;
    public bool isHitItems = false;
    private void Start() {
        Player_Animator = GetComponent<Animator>();
    }
    //Ham doi di chuyen trong 36 so dem trong 1 step theo huong vector
    public IEnumerator MoveForward()
    {
        switch (Player_side)
        {
            case Player_Side.Up:
            {
                Side_Vector_Player = Vector3.up;
                break;
            }
            case Player_Side.Down:
            {
                Side_Vector_Player = Vector3.down;
                break;
            }
            case Player_Side.Left:
            {
                Side_Vector_Player = Vector3.left;
                break;
            }
            case Player_Side.Right:
            {
                Side_Vector_Player = Vector3.right;
                break;
            }
        }

        Player_Animator.SetBool(Player_side.ToString(), true);

        startPos = transform.localPosition;
        nextPos = startPos + Side_Vector_Player;
        
        GetComponent<Rigidbody2D>().velocity = Side_Vector_Player * 2f;
        //transform.localPosition += Side_Vector_Player;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        transform.localPosition = nextPos;

        Player_Animator.SetBool(Player_side.ToString(), false);
    }
    //Quay mat player
    IEnumerator Turn_Away(int direction)
    {
        if(direction == 0)
        {
            if(Player_side == Player_Side.Up)
            {
                GetComponent<SpriteRenderer>().sprite = Arrow_Player[1];
                Player_side = Player_Side.Right;
            }
            else if(Player_side == Player_Side.Right)
            {
                GetComponent<SpriteRenderer>().sprite = Arrow_Player[2];
                Player_side = Player_Side.Down;
            }
            else if(Player_side == Player_Side.Down)
            {
                GetComponent<SpriteRenderer>().sprite = Arrow_Player[3];
                Player_side = Player_Side.Left;
            }
            else if(Player_side == Player_Side.Left)
            {
                GetComponent<SpriteRenderer>().sprite = Arrow_Player[0];
                Player_side = Player_Side.Up;
            }
            Player_Animator.SetTrigger("idle-left");
        }
        else if(direction == 1)
        {
            if(Player_side == Player_Side.Up)
            {
                GetComponent<SpriteRenderer>().sprite = Arrow_Player[1];
                Player_side = Player_Side.Right;
            }
            else if(Player_side == Player_Side.Right)
            {
                GetComponent<SpriteRenderer>().sprite = Arrow_Player[2];
                Player_side = Player_Side.Down;
            }
            else if(Player_side == Player_Side.Down)
            {
                GetComponent<SpriteRenderer>().sprite = Arrow_Player[3];
                Player_side = Player_Side.Left;
            }
            else if(Player_side == Player_Side.Left)
            {
                GetComponent<SpriteRenderer>().sprite = Arrow_Player[0];
                Player_side = Player_Side.Up;
            }
            Player_Animator.SetTrigger("idle-right");
        }
        yield return new WaitForSeconds(0.2f);
    }
    //Repeat loop method
    IEnumerator LoopFuctionUntilGoal(GameObject Mid_Contain)
    {   
        isHitItems = false;
        while (isHitItems == false)
        {
            if(Mid_Contain.transform.childCount != 0)
            {
                foreach(Transform child in Mid_Contain.transform)
                {
                    string Func_name = child.GetComponent<BlockInfo>().Function_name;
                    switch (Func_name)
                    {
                        case "MoveForward":
                        {   
                            child.GetComponent<Image>().material = Outline_Run_Blox;
                            StartCoroutine(Func_name);
                            yield return new WaitForSeconds(0.5f);
                            child.GetComponent<Image>().material = Outline_None_Blox;
                            break;
                        }
                        case "Turn_Away":
                        {
                            child.GetComponent<Image>().material = Outline_Run_Blox;
                            int direction = child.GetComponent<BlockInfo>().Mid_Contain.GetComponent<TMP_Dropdown>().value;
                            StartCoroutine(Func_name, direction);
                            yield return new WaitForSeconds(0.2f);
                            child.GetComponent<Image>().material = Outline_None_Blox;
                            break;
                        }
                        case "LoopFuctionUntilGoal":
                        {
                            child.GetComponent<Image>().material = Outline_Run_Blox;
                            GameObject Mid_contain = child.GetComponent<BlockInfo>().Mid_Contain;
                            StartCoroutine(Func_name, Mid_contain);
                            yield return new WaitUntil(() => isHitItems == true);
                            child.GetComponent<Image>().material = Outline_None_Blox;
                            break;
                        }
                    }  
                }
            }
            else if(Mid_Contain.transform.childCount == 0)
            {
                isHitItems = true;
            }
        }
        yield return new WaitUntil(() => isHitItems == true);
    }
    //Xu ly khi va cham diem den chuyen thanh diem bat dau & ngung rb velocity
    private void OnCollisionEnter2D(Collision2D other) {
        nextPos = startPos;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        isHitItems = true;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        isHitItems = true;
        if(other.tag == "Number")
        {
            if(GUI_Math.GetComponent<GUIPlayerGridGame>().List_Number_Operator.Number_First == "?")
            {
                GUI_Math.GetComponent<GUIPlayerGridGame>().List_Number_Operator.Number_First = other.transform.GetChild(0).GetComponent<TextMeshPro>().text;
                GUI_Math.GetComponent<GUIPlayerGridGame>().List_Show_Number_Text[0].text = GUI_Math.GetComponent<GUIPlayerGridGame>().List_Number_Operator.Number_First;
            }
            else if(GUI_Math.GetComponent<GUIPlayerGridGame>().List_Number_Operator.Number_Second == "?")
            {
                GUI_Math.GetComponent<GUIPlayerGridGame>().List_Number_Operator.Number_Second = other.transform.GetChild(0).GetComponent<TextMeshPro>().text;
                GUI_Math.GetComponent<GUIPlayerGridGame>().List_Show_Number_Text[1].text = GUI_Math.GetComponent<GUIPlayerGridGame>().List_Number_Operator.Number_Second;
            }
            else if(GUI_Math.GetComponent<GUIPlayerGridGame>().List_Number_Operator.Number_Result == "?")
            {
                GUI_Math.GetComponent<GUIPlayerGridGame>().List_Number_Operator.Number_Result = other.transform.GetChild(0).GetComponent<TextMeshPro>().text;
                GUI_Math.GetComponent<GUIPlayerGridGame>().List_Show_Number_Text[2].text = GUI_Math.GetComponent<GUIPlayerGridGame>().List_Number_Operator.Number_Result;
            }
            Destroy(other.gameObject);
        }
    }
}
