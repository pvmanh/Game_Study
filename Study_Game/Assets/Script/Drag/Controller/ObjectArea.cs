using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectArea : MonoBehaviour
{
    public ObjectModel objectData;
    public GameObject gridObject;
    public TextMeshProUGUI text_Level;
    public TimeModel timeData;
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
        timeData.timegget = timeData.txt_time.text;
        timeData.timeToDisplay = Time.time;

        text_Level.text = objectData.Level.ToString();

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
            if(objectData.iLevel == 1)
            {
                //objectData.Width++;
                objectData.Height++;    
                objectData.iLevel = 3;
            }
            else if(objectData.iLevel == 2)
            {
                objectData.Width++;
                objectData.Height++;
                objectData.iLevel--;
            }
            else if(objectData.iLevel == 3)
            {
                objectData.Width++;
                //objectData.Height++;
                objectData.iLevel--;
            }
            objectData.Level++;
            text_Level.text = objectData.Level.ToString();

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
    void FixedUpdate()
    {
        Timer.TimeClock(timeData);
    }
    void CheckSelected()
    {
        if(isCheckSelected == true)
        {
            int ID_1 = IDSelected[0].GetComponent<ObjectInfo>().idObject;
            int ID_2 = IDSelected[1].GetComponent<ObjectInfo>().idObject;
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
