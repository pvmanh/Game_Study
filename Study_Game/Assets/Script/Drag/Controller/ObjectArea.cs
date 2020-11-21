using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectArea : MonoBehaviour
{
    public ObjectModel objectData;
    public GameObject gridObject;
    public List<GameObject> IDSelected = new List<GameObject> { };
    float[] gridValue = new float[2];
    public List<Texture2D> listIcon = new List<Texture2D> { };
    public List<GameObject> GridList = new List<GameObject> { };
    public List<int> listNumber = new List<int> { };
    public List<int> ListID = new List<int> { };
    public bool isCheckSelected = false;
    public bool iChild;
    // Start is called before the first frame update
    void Start()
    {
        gridValue = Object.CaculatorValueGrid(gridValue, objectData);
        Object.SplitGridObject(objectData, gridObject, gridValue, transform);

        GridList = Object.AddListObjectGrid(GridList, transform);
        listNumber = Object.AddNumber(listNumber, GridList);
        ListID = Object.AddNumberID(ListID, GridList);
        Object.AddIDNumber(listNumber, ListID, GridList, listIcon);
    }
    void Update()
    {
        //GridPuzzle.PuzzleLevelUp(pLoadPuzzle.puzzleData, GridObject, gridData, gridValue, transform);
        CheckSelected();
        iChild = Object.CheckWinClick(gameObject);
        if(iChild == true)
        {
            objectData.Level++;
            objectData.Width += 2;
            objectData.Height += 2;

            objectData.xMin = objectData.xMax = 0f;
            objectData.yMin = objectData.yMax = 1f;

            gridValue = Object.CaculatorValueGrid(gridValue, objectData);
            Object.SplitGridObject(objectData, gridObject, gridValue, transform);

            GridList.Clear();
            GridList = Object.AddListObjectGrid(GridList, transform);
            listNumber = Object.AddNumber(listNumber, GridList);
            ListID = Object.AddNumberID(ListID, GridList);
            Object.AddIDNumber(listNumber, ListID, GridList, listIcon);
            iChild = false;
        }

    }
    void CheckSelected()
    {
        if(isCheckSelected == true)
        {
            int ID_1 = IDSelected[0].GetComponent<ObjectClick>().idObject;
            int ID_2 = IDSelected[1].GetComponent<ObjectClick>().idObject;
            if (ID_1 == ID_2)
            {
                Destroy(IDSelected[0]);
                Destroy(IDSelected[1]);
                IDSelected.Clear();
                isCheckSelected = false;
            }
            else
            {
                StartCoroutine(Object.waitingFlip(IDSelected));
                
                isCheckSelected = false;
            }
        }
    }
}
