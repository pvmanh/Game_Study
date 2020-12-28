using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FreeDraw;

public class testscript : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //-5 va 5, -3.7 va 3.7 tu do trong play
        if(mouse_pos.x >= -5 && mouse_pos.x <= 5f && mouse_pos.y >= -3.7f && mouse_pos.y <= 3.7f)
        {
            transform.position = new Vector3(mouse_pos.x, mouse_pos.y, -1.02f);
        }
    }
}
