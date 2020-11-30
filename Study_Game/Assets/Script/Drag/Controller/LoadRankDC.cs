using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class LoadRankDC : MonoBehaviour
{
    string URL = "http://localhost/xampp/drag_rank_select.php?level=";
    string URL_1 = "http://localhost/xampp/select_class.php";
    public string[] saveData;
    public string[] saveData_1;
    [System.Serializable]
    public struct SaveRankData
    {
        public string idnumber;
        public string PlayerName;
        public string ClassName;
        public string LevelGame;
        public string TimePlayed;
    }
    public SaveRankData[] dataDragRank;
    public List<string> class_name;
    public string classid;
    public TMP_Dropdown level;
    public TMP_Dropdown class_rank;
    public GameObject RankRows;
    public Transform Drag_Content;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelectClassAddDropdownlist(URL_1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DataChangeRankTable()
    {
        if(dataDragRank.Length != 0)
        {
            for(int i = 0; i < dataDragRank.Length; i++)
            {
                var RankInfo = Instantiate(RankRows, Drag_Content);
                RankInfo.GetComponent<InfoHolder>().STT.text = (i + 1).ToString();
                RankInfo.GetComponent<InfoHolder>().Name.text = dataDragRank[i].PlayerName;
                RankInfo.GetComponent<InfoHolder>().Class.text = dataDragRank[i].ClassName;
                RankInfo.GetComponent<InfoHolder>().Level.text = dataDragRank[i].LevelGame;
                RankInfo.GetComponent<InfoHolder>().Time.text = dataDragRank[i].TimePlayed;
                if(i == 0)
                {
                    RankInfo.GetComponent<Image>().color = new Color32(255, 238, 0, 255);
                }
                else if(i == 1)
                {
                    RankInfo.GetComponent<Image>().color = new Color32(110, 179, 255, 255);
                }
                else if(i == 2)
                {
                    RankInfo.GetComponent<Image>().color = new Color32(140, 255, 120, 255);
                }
                else if(i%2 == 0 && i > 2)
                {
                    RankInfo.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                }
                else if(i%2 != 0 && i > 2)
                {
                    RankInfo.GetComponent<Image>().color = new Color32(240, 240, 240, 255);
                }
            }
        }
        else if(dataDragRank.Length == 0)
        {
            var RankInfo = Instantiate(RankRows, Drag_Content);
            RankInfo.GetComponent<InfoHolder>().STT.gameObject.SetActive(false);
            RankInfo.GetComponent<InfoHolder>().Name.gameObject.SetActive(false);
            RankInfo.GetComponent<InfoHolder>().Class.gameObject.SetActive(false);
            RankInfo.GetComponent<InfoHolder>().Level.gameObject.SetActive(false);
            RankInfo.GetComponent<InfoHolder>().Time.gameObject.SetActive(false);
            RankInfo.GetComponent<InfoHolder>().Alert.gameObject.SetActive(true);
        }
    }
    public void OnChangeValued()
    {
        foreach (Transform child in Drag_Content)
        {
            Destroy(child.gameObject);
        }

        StartCoroutine(SelectDragRankWithLevel(URL, level.options[level.value].text, GetClassID()));
    }
    IEnumerator SelectDragRankWithLevel(string URL, string level, string classid)
    {
        UnityWebRequest www = UnityWebRequest.Get(URL + level + "&class=" + classid);

        yield return www.SendWebRequest();
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Select data complete!");
        }
        string usersDataString = www.downloadHandler.text;
        saveData = usersDataString.Split(';');

        if(saveData.Length != 0)
        {
            dataDragRank = new SaveRankData[saveData.Length - 1];

            for (int i = 0; i < (saveData.Length - 1); i++)
            {
                dataDragRank[i].idnumber = SaveRankView.GetValueData(saveData[i], "id:");
                dataDragRank[i].PlayerName = SaveRankView.GetValueData(saveData[i], "name:");
                dataDragRank[i].LevelGame = SaveRankView.GetValueData(saveData[i], "level:");
                dataDragRank[i].ClassName = SaveRankView.GetValueData(saveData[i], "class:");
                dataDragRank[i].TimePlayed = SaveRankView.GetValueData(saveData[i], "time:");
            }

            DataChangeRankTable();
        }  
    }
    public string GetClassID()
    {
        for (int i = 0; i < (saveData_1.Length - 1); i++)
        {
            if (class_rank.options[class_rank.value].text == SaveRankView.GetValueData(saveData_1[i], "class:"))
            {
                classid = SaveRankView.GetValueData(saveData_1[i], "id:");
                break;
            }
        }
        return classid;
    }
    public void ClassIDChange()
    {
        foreach (Transform child in Drag_Content)
        {
            Destroy(child.gameObject);
        }

        classid = GetClassID();
        StartCoroutine(SelectDragRankWithLevel(URL, level.options[level.value].text, classid));
    }
    IEnumerator SelectClassAddDropdownlist(string URL_link)
    {
        UnityWebRequest www = UnityWebRequest.Get(URL_link);

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Select data complete!");
        }
        string usersDataString = www.downloadHandler.text;
        saveData_1 = usersDataString.Split(';');

        for (int i = 0; i < (saveData_1.Length - 1); i++)
        {
            class_name.Add(SaveRankView.GetValueData(saveData_1[i], "class:"));
        }

        class_rank.AddOptions(class_name);

        classid = GetClassID();
        StartCoroutine(SelectDragRankWithLevel(URL, level.options[level.value].text, classid));
    }
}
