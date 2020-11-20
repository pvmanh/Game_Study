using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationItem : MonoBehaviour
{
    PlayerController pControl;
    Animator AnimationItems;
    public GameObject Items;
    public string OpenParameter;
    // Start is called before the first frame update
    void Start()
    {
        AnimationItems = Items.GetComponent<Animator>();
        pControl = Camera.main.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        LoadAnimation(OpenParameter);
    }

    void LoadAnimation(string valueOpen)
    {
        if(pControl.colliItems == Items.tag)
        {
            if(pControl.isOpen == false)
            {
                AnimationItems.SetBool(valueOpen,true);
                pControl.isOpen = true;
                pControl.colliItems = null;
            }
            else if(pControl.isOpen == true)
            {
                AnimationItems.SetBool(valueOpen ,false);
                pControl.isOpen = false;
                pControl.colliItems = null;
            }
        }
    }
}
