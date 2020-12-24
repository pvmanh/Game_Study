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
    private void Start() 
    {
        Player_Animator = GetComponent<Animator>();
    }
    //Set Direction
    public void Reset_Direction_Player()
    {
        if(GUI_Math.GetComponent<GUIPlayerGridGame>().LastVectorPoint == Player_Side.Up.ToString())
            {
                Player_side = Player_Side.Up;
                Player_Animator.SetFloat("Hor", 0f);
                Player_Animator.SetFloat("Ver", 1f);
                //GetComponent<SpriteRenderer>().sprite = Arrow_Player[1];
                
            }
            else if(GUI_Math.GetComponent<GUIPlayerGridGame>().LastVectorPoint == Player_Side.Right.ToString())
            {
                Player_side = Player_Side.Right;
                Player_Animator.SetFloat("Hor", 1f);
                Player_Animator.SetFloat("Ver", 0f);
                //GetComponent<SpriteRenderer>().sprite = Arrow_Player[2];   
            }
            else if(GUI_Math.GetComponent<GUIPlayerGridGame>().LastVectorPoint == Player_Side.Down.ToString())
            {
                Player_side = Player_Side.Down;
                Player_Animator.SetFloat("Hor", 0f);
                Player_Animator.SetFloat("Ver", -1f);
                //GetComponent<SpriteRenderer>().sprite = Arrow_Player[3];
                
            }
            else if(GUI_Math.GetComponent<GUIPlayerGridGame>().LastVectorPoint == Player_Side.Left.ToString())
            {
                //GetComponent<SpriteRenderer>().sprite = Arrow_Player[0];
                Player_side = Player_Side.Left;
                Player_Animator.SetFloat("Hor", -1f);
                Player_Animator.SetFloat("Ver", 0f);
            }
    }
    //Ham doi di chuyen trong 36 so dem trong 1 step theo huong vector
    public IEnumerator MoveForward()
    {
        switch (Player_side)
        {
            case Player_Side.Up:
            {
                Side_Vector_Player = Vector3.up;
                Player_Animator.SetFloat("Hor", 0f);
                Player_Animator.SetFloat("Ver", 1f);
                break;
            }
            case Player_Side.Down:
            {
                Side_Vector_Player = Vector3.down;
                Player_Animator.SetFloat("Hor", 0f);
                Player_Animator.SetFloat("Ver", -1f);
                break;
            }
            case Player_Side.Left:
            {
                Side_Vector_Player = Vector3.left;
                Player_Animator.SetFloat("Hor", -1f);
                Player_Animator.SetFloat("Ver", 0f);
                break;
            }
            case Player_Side.Right:
            {
                Side_Vector_Player = Vector3.right;
                Player_Animator.SetFloat("Hor", 1f);
                Player_Animator.SetFloat("Ver", 0f);
                break;
            }
        }

        Player_Animator.SetBool("isMove", true);

        startPos = transform.localPosition;
        nextPos = startPos + Side_Vector_Player;
        
        GetComponent<Rigidbody2D>().velocity = Side_Vector_Player * 1.8f;
        //transform.localPosition += Side_Vector_Player * Time.deltaTime;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        transform.localPosition = nextPos;

        Player_Animator.SetBool("isMove", false);
    }
    //Quay mat player
    IEnumerator Turn_Away(int direction)
    {
        if(direction == 0)
        {
            if(Player_side == Player_Side.Up)
            {
                //GetComponent<SpriteRenderer>().sprite = Arrow_Player[1];
                Player_side = Player_Side.Right;
                Player_Animator.SetFloat("Hor", 1f);
                Player_Animator.SetFloat("Ver", 0f);
            }
            else if(Player_side == Player_Side.Right)
            {
                //GetComponent<SpriteRenderer>().sprite = Arrow_Player[2];
                Player_side = Player_Side.Down;
                Player_Animator.SetFloat("Hor", 0f);
                Player_Animator.SetFloat("Ver", -1f);
            }
            else if(Player_side == Player_Side.Down)
            {
                //GetComponent<SpriteRenderer>().sprite = Arrow_Player[3];
                Player_side = Player_Side.Left;
                Player_Animator.SetFloat("Hor", -1f);
                Player_Animator.SetFloat("Ver", 0f);
            }
            else if(Player_side == Player_Side.Left)
            {
                //GetComponent<SpriteRenderer>().sprite = Arrow_Player[0];
                Player_side = Player_Side.Up;
                Player_Animator.SetFloat("Hor", 0f);
                Player_Animator.SetFloat("Ver", 1f);
            }
        }
        else if(direction == 1)
        {
            if(Player_side == Player_Side.Up)
            {
                //GetComponent<SpriteRenderer>().sprite = Arrow_Player[3];
                Player_side = Player_Side.Left;
                Player_Animator.SetFloat("Hor", -1f);
                Player_Animator.SetFloat("Ver", 0f);
            }
            else if(Player_side == Player_Side.Right)
            {
                //GetComponent<SpriteRenderer>().sprite = Arrow_Player[0];
                Player_side = Player_Side.Up;
                Player_Animator.SetFloat("Hor", 0f);
                Player_Animator.SetFloat("Ver", 1f);
            }
            else if(Player_side == Player_Side.Down)
            {
                //GetComponent<SpriteRenderer>().sprite = Arrow_Player[1];
                Player_side = Player_Side.Right;
                Player_Animator.SetFloat("Hor", 1f);
                Player_Animator.SetFloat("Ver", 0f);
            }
            else if(Player_side == Player_Side.Left)
            {
                //GetComponent<SpriteRenderer>().sprite = Arrow_Player[2];
                Player_side = Player_Side.Down;
                Player_Animator.SetFloat("Hor", 0f);
                Player_Animator.SetFloat("Ver", -1f);
            }
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
                        case "DeleteFromTarget":
                        {
                            child.GetComponent<Image>().material = Outline_Run_Blox;
                            StartCoroutine(Func_name);
                            yield return new WaitForSeconds(0.2f);
                            child.GetComponent<Image>().material = Outline_None_Blox;
                            break;
                        }
                        case "RepeatAfterNTurn":
                        {
                            child.GetComponent<Image>().material = Outline_Run_Blox;
                            object[] parameters_func = new object[2]{Mid_Contain, int.Parse(child.GetComponent<BlockInfo>().repeat_number.text)};
                            StartCoroutine(Func_name, parameters_func);
                            yield return new WaitUntil(() => child.GetComponent<BlockInfo>().int_variable == (int)parameters_func[1]);
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
    IEnumerator RepeatAfterNTurn(object[] parameters_func)
    {   
        ((GameObject)parameters_func[0]).transform.parent.GetComponent<BlockInfo>().int_variable = 0;
        int i;
        for(i = 0; i < (int)parameters_func[1]; i++)
        {   
            if(((GameObject)parameters_func[0]).transform.childCount != 0)
            {   
                foreach(Transform child in ((GameObject)parameters_func[0]).transform)
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
                        case "DeleteFromTarget":
                        {
                            child.GetComponent<Image>().material = Outline_Run_Blox;
                            StartCoroutine(Func_name);
                            yield return new WaitForSeconds(0.2f);
                            child.GetComponent<Image>().material = Outline_None_Blox;
                            break;
                        }
                        case "RepeatAfterNTurn":
                        {
                            child.GetComponent<Image>().material = Outline_Run_Blox;
                            GameObject Mid_contain = child.GetComponent<BlockInfo>().Mid_Contain;
                            object[] parameters_func_c = new object[2]{Mid_contain, int.Parse(((GameObject)parameters_func[0]).transform.parent.GetComponent<BlockInfo>().repeat_number.text)};
                            StartCoroutine(Func_name, parameters_func_c);
                            yield return new WaitUntil(() => child.GetComponent<BlockInfo>().int_variable == (int)parameters_func_c[1]);
                            child.GetComponent<Image>().material = Outline_None_Blox;
                            break;
                        }
                    }  
                }
            }
        } 
        if(i == (int)parameters_func[1])
        {
            ((GameObject)parameters_func[0]).transform.parent.GetComponent<BlockInfo>().int_variable = i;
        }
        yield return new WaitUntil(() => ((GameObject)parameters_func[0]).transform.parent.GetComponent<BlockInfo>().int_variable == (int)parameters_func[1]);
    }
    public IEnumerator DeleteFromTarget()
    {
        Vector3 next_Staget = new Vector3(Mathf.Round(transform.localPosition.x * 100.0f) / 100.0f, Mathf.Round(transform.localPosition.y * 100.0f) / 100.0f, 0);
        
        switch (Player_side)
        {
            case Player_Side.Up:
            {    
                next_Staget = next_Staget + Vector3.up;
                break;
            }
            case Player_Side.Down:
            {    
                next_Staget = next_Staget + Vector3.down;
                break;
            }
            case Player_Side.Left:
            {    
                next_Staget = next_Staget + Vector3.left;
                break;
            }
            case Player_Side.Right:
            {    
                next_Staget = next_Staget + Vector3.right;
                break;
            }
        }

        foreach(Transform child in GUI_Math.GetComponent<GUIPlayerGridGame>().Math_Round_Object)
        {
            if(child.tag == "Number")
            {
                if(child.localPosition == next_Staget)
                {
                    Destroy(child.gameObject);
                    yield return new WaitForSeconds(0.2f);
                }
            }
        }
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
        else if(other.tag == "Hole")
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            transform.localPosition = other.transform.localPosition;
            StopAllCoroutines();
            GUI_Math.GetComponent<GUIPlayerGridGame>().Play_btn.GetComponent<PlayMath>().StopAllCoroutines();
            GUI_Math.GetComponent<GUIPlayerGridGame>().Play_btn.GetComponent<PlayMath>().ListActive.Clear();
            Player_Animator.SetBool("isHole", true);
        }
    }
}
