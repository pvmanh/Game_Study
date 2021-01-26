using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuTypeDoc : MonoBehaviour
{
    public GameObject typedoc;
    public Button btnLT;
    public Button btnVB;
    public Image huongdan;
    public static int i = 0;
    private static string[] wordListLT = { };

    // Start is called before the first frame update
    void Start()
    {
        btnLT.onClick.AddListener(() => GetLevel(btnLT));
        btnVB.onClick.AddListener(() => GetLevel(btnVB));

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void HDexit()
    {
       huongdan.gameObject.SetActive(false);
    }
    public void HDopen()
    {
        huongdan.gameObject.SetActive(true);
    }

    private void GetLevel(Button btn)
    {
        if (btn.name == "btnluyentap")
        {
            btnLT.gameObject.SetActive(false);
            btnVB.gameObject.SetActive(false);
            i = 1;
            typedoc.gameObject.SetActive(true);

        }
        if (btn.name == "btnvanban")
        {
            btnLT.gameObject.SetActive(false);
            btnVB.gameObject.SetActive(false);
            i = 2;
            typedoc.gameObject.SetActive(true);
        }




    }
}
