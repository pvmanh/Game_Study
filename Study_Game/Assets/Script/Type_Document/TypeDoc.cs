using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeDoc : MonoBehaviour
{
    public WordDoc WordDoc;
    public TextMeshProUGUI WordDocOP;
    // Start is called before the first frame update
    void Start()
    {
        SetCurrentWord();
    } 

    private void SetCurrentWord()
    {
//WordDocOP.text = WordDoc.wordListcb[0];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
