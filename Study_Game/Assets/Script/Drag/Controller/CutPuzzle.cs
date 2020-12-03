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
    //tinh grid & them grid
    void Start()
    {
        pLoadPuzzle = gridData.pApp_Click.GetComponent<LoadPuzzle>();
        gridValue = GridPuzzle.CaculatorValueGrid(gridValue, pLoadPuzzle.puzzleData);

        GridPuzzle.SplitGridPuzzle(gridData, GridObject, pLoadPuzzle.puzzleData, gridValue, transform);
    }
    //xoa grid cu => tinh grid => them grid moi khi level up
    void Update()
    {
        GridPuzzle.PuzzleLevelUp(pLoadPuzzle.puzzleData, GridObject, gridData, gridValue, transform);      
    }
    //ham huy gameobject ojb
    public static void DestroyObject(GameObject ojb)
    {
        Destroy(ojb);
    }
    //ham tao gameobject ojb
    public static GameObject CreateObject(GameObject ojb, Transform parent)
    {
        return Instantiate(ojb, parent);
    }
}
