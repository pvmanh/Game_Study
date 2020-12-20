using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class paintBucket : MonoBehaviour
{
    public Color[] colorList;
    public Color curColor;
    public int colorCount;

    // Start is called before the first frame update
    void Start()
    {
        paint(colorCount);
    }

    // Update is called once per frame
    void Update()
    {
        curColor = colorList[colorCount];
        var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
        

        if (Input.GetButton("Fire1"))
        { 
            if(hit.collider != null)
            {
                Debug.DrawLine(ray, hit.point, Color.blue, 0.5f);
                SpriteRenderer sp = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                Debug.Log(hit.collider.name);
                sp.color = curColor;
            }
            if (hit.collider == null)
            {
                //
               // Camera.main.backgroundColor = curColor;
            }
        }

    }
    public void paint (int colorCode)
    {
        colorCount = colorCode;
    }
}
