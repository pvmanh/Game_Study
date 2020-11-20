using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutPuzzle : MonoBehaviour
{
    public GridModel gridData;
    //public GameObject pApp_Click;
    public GameObject GridObject;
    LoadPuzzle pLoadPuzzle;
    float[] gridValue;
    // Start is called before the first frame update
    void Start()
    {
        pLoadPuzzle = gridData.pApp_Click.GetComponent<LoadPuzzle>();
        gridValue = GridPuzzle.CaculatorValueGrid(gridValue, pLoadPuzzle.puzzleData);

        GridPuzzle.SplitGridPuzzle(gridData, GridObject, pLoadPuzzle.puzzleData, gridValue, transform);
    }

    // Update is called once per frame
    void Update()
    {
        GridPuzzle.PuzzleLevelUp(pLoadPuzzle.puzzleData, GridObject, gridData, gridValue, transform);
        
    }

    public static void DestroyObject(GameObject ojb)
    {
        Destroy(ojb);
    }

    public static GameObject CreateObject(GameObject ojb, Transform parent)
    {
        return Instantiate(ojb, parent);
    }
}
