using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    public Texture2D cursorPen;
    public Texture2D cursorTomau;
    public Texture2D cursorEraser;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    int i = 0;

    private void Start()
    {
        OnMousePen();
    }

    private void Update()
    {
        if(i==1)
        {
            Cursor.SetCursor(cursorPen, hotSpot, cursorMode);
        }
        else if(i==2)
        {
            Cursor.SetCursor(cursorTomau, hotSpot, cursorMode);
        }
        else if(i==3)
        {
            Cursor.SetCursor(cursorEraser, hotSpot, cursorMode);
        }
    }
    public void OnMousePen()
    {
        i=1;
    }

     public void OnMouseTomau()
    {
        i=2;
    }
    public void OnMouseEraser()
    {
        i=3;
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

}
