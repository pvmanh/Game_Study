using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Character
    [Header("Player")]
    public Transform target;
    public Transform rayTarget;
    public CharacterController player;
    [Header("Mouse Setting")]
    public float MouseSensitivity = 100f;
    public float RotationX = 0f;
    public float RotationY = 0f;
    [System.NonSerialized]
    public bool CanMove = true;
    [Header("Move Setting")]
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    [System.NonSerialized]
    public bool isPickup = false;
    [Header("Range Setting")]
    public float distance = 1.5f;
    //private float Double_click_time = 0.2f;
    //private float lastClickTime;
    [System.NonSerialized]
    public string colliPC;
    public string colliPCVis;
    public string colliItems;
    public bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {  
        Cursor.lockState = CursorLockMode.Locked;
        player = target.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateMouse();
        MoveChar();
        getPCTag();
    }
    
    // Character 
    void RotateMouse()
    {
        if(CanMove == true)
        {
            float MouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
            float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

            RotationY -= MouseY;
            RotationY = Mathf.Clamp(RotationY,-90f,90f);

            RotationX += MouseX;
            //RotationX = Mathf.Clamp(RotationX, -180f,180f);

            transform.localRotation = Quaternion.Euler(RotationY,0f,0f);
            target.localRotation = Quaternion.Euler(0f,RotationX,0f);
            //target.Rotate(Vector3.up * MouseX);
        }
    }
    
    void MoveChar()
    {
        if(CanMove == true)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if(isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            player.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            player.Move(velocity * Time.deltaTime);
        }
    }

    public void getPCTag()
    {
        RaycastHit hit;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 direction = Camera.main.transform.position;
        if(Input.GetMouseButtonDown(1))
        {
            //float timeSinceClick = Time.time - lastClickTime;
           //if(timeSinceClick <= Double_click_time)
            //{
                if(Physics.Raycast(rayTarget.transform.position,Camera.main.transform.forward, out hit,distance))
                {
                    //Debug.DrawLine(rayTarget.transform.position,hit.point, Color.blue,0.5f);
                    if(isPickup == false)
                        colliPC = hit.collider.tag;
                    else if(isPickup == true)
                        colliPCVis = hit.collider.tag;
                }
            //}
            //lastClickTime = Time.time;
        }
        else if(Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(rayTarget.transform.position,Camera.main.transform.forward, out hit,distance))
            {
                //Debug.DrawLine(rayTarget.transform.position,hit.point, Color.blue,0.5f);
                colliItems = hit.collider.tag;
            }
        }
    }
}
