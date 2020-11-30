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
    public Texture2D[] LoadListTexture;
    [Header("Left Click")]
    public int x1;
    [Header("Right Click")]
    public int x2;
    public int x3;
    [Header("Middle Click")]
    public int x4;
    public int x5;
    [Header("Double Click")]
    public int x6;    
    // Start is called before the first frame update
    // Start is called before the first frame update
    void Start()
    {
        LoadListTexture = Resources.LoadAll<Texture2D>("Card/");
        
        for(int i = 0; i < LoadListTexture.Length; i++)
        {
            listIcon.Add(LoadListTexture[i]);
        }

        timeData.timegget = timeData.txt_time.text;
        timeData.timeToDisplay = Time.time;

        text_Level.text = objectData.Level.ToString();

        gridValue = ObjectView.CaculatorValueGrid(gridValue, objectData);
        ObjectView.SplitGridObject(objectData, gridObject, gridValue, transform);

        GridList = ObjectView.AddListObjectGrid(GridList, transform);
        listNumber = ObjectView.AddNumber(listNumber, GridList);
        ListID = ObjectView.AddNumberID(ListID, GridList);
        ObjectView.AddIDNumber(listNumber, ListID, GridList, listIcon);
    }
    void Update()
    {
        CheckSelected();
        iChild = ObjectView.CheckWinClick(gameObject);
        if(iChild == true && objectData.Level != objectData.LevelLimit)
        {
            LoadListTexture = null;
            listIcon.Clear();
            LoadListTexture = Resources.LoadAll<Texture2D>("Card/");
        
            for(int i = 0; i < LoadListTexture.Length; i++)
            {
                listIcon.Add(LoadListTexture[i]);
            }

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

            gridValue = ObjectView.CaculatorValueGrid(gridValue, objectData);
            ObjectView.SplitGridObject(objectData, gridObject, gridValue, transform);

            GridList.Clear();
            GridList = ObjectView.AddListObjectGrid(GridList, transform);
            listNumber = ObjectView.AddNumber(listNumber, GridList);
            ListID = ObjectView.AddNumberID(ListID, GridList);
            ObjectView.AddIDNumber(listNumber, ListID, GridList, listIcon);
            iChild = false;
        }
        else if(iChild == true && objectData.Level == objectData.LevelLimit)
        {
            Debug.Log("Game Complete");
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
                StartCoroutine(ObjectView.waitingFlipBeforeDestroy(IDSelected));
                
                isCheckSelected = false;
            }
            else
            {
                StartCoroutine(ObjectView.waitingFlip(IDSelected));
                
                isCheckSelected = false;
            }
        }
    }
}
