using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class LoadRankType : MonoBehaviour
{
    string URL_class = "http://localhost/xampp/select_class.php";
    [Header("Class Setting")]
    public List<string> data_Class_name;
    [System.Serializable]
    public struct SaveClassData
    {
        public string id_class;
        public string class_name;
    }
    public List<SaveClassData> data_class;
    public TMP_Dropdown dropdown_class_drag;
    public TMP_Dropdown dropdown_class_click;
    public bool isLoaded = false;
    public string class_id_drag;
    public string class_id_click;
    string URL_drag = "http://localhost/xampp/drag_rank_select.php?level=";
    string URL_click = "http://localhost/xampp/click_rank_select.php?level=";
    [System.Serializable]
    public struct SaveRankData
    {
        public string idnumber;
        public string PlayerName;
        public string ClassName;
        public string LevelGame;
        public string TimePlayed;

    }
    [Header("Rank Setting")]
    public SaveRankData[] data_Drag_Rank;
    public SaveRankData[] data_Click_Rank;
    public List<string> data_rank_uncut;
    public List<string> data_click_uncut;
    public TMP_Dropdown dropdown_level_drag;
    public TMP_Dropdown dropdown_level_click;
    public bool isCut = false;
    public GameObject Info_rank;
    public Transform Drag_Content;
    public Transform Click_Content;
    public bool isDrag_class = false;
    public bool isClick_class = false;
    private void Start()
    {
        //lay class cho drag & click
        StartCoroutine(SelectClassAndAddToList(URL_class, data_class, dropdown_class_drag, dropdown_class_click));
    }
    private void Update()
    {
        //them options dropdownlist
        if (isLoaded == true)
        {
            AddOptionsDropdown(data_class, data_Class_name, dropdown_class_drag, dropdown_class_click);
            class_id_drag = GetClassIDFromDropdown(class_id_drag, dropdown_class_drag, data_class);
            class_id_click = GetClassIDFromDropdown(class_id_click, dropdown_class_click, data_class);

            string level_drag = dropdown_level_drag.options[dropdown_level_drag.value].text;
            StartCoroutine(SelectDataRankCustom(URL_drag, level_drag, class_id_drag, data_rank_uncut));

            string level_click = dropdown_level_click.options[dropdown_level_click.value].text;
            StartCoroutine(SelectDataRankCustom(URL_click, level_click, class_id_click, data_click_uncut));

            isLoaded = false;
        }

        if (isCut == true)
        {
            if (isDrag_class == true)
            {
                data_Drag_Rank = new SaveRankData[data_rank_uncut.Count];
                data_Drag_Rank = CutDataRank(data_Drag_Rank, data_rank_uncut);
                AddRankDataToGUI(data_Drag_Rank, Info_rank, Drag_Content);
                isDrag_class = false;
            }

            if (isClick_class == true)
            {
                data_Click_Rank = new SaveRankData[data_click_uncut.Count];
                data_Click_Rank = CutDataRank(data_Click_Rank, data_click_uncut);
                AddRankDataToGUI(data_Click_Rank, Info_rank, Click_Content);
                isClick_class = false;
            }

            isCut = false;
        }
    }
    //class changed event
    public void ClassChanged(TMP_Dropdown class_dropdown)
    {
        if (class_dropdown.name == "class-select-drag")
        {
            foreach (Transform child in Drag_Content)
            {
                Destroy(child.gameObject);
            }
            class_id_drag = GetClassIDFromDropdown(class_id_drag, class_dropdown, data_class);
            string level_drag = dropdown_level_drag.options[dropdown_level_drag.value].text;
            StartCoroutine(SelectDataRankCustom(URL_drag, level_drag, class_id_drag, data_rank_uncut));
            isDrag_class = true;
        }
        else if (class_dropdown.name == "class-select-click")
        {
            foreach (Transform child in Click_Content)
            {
                Destroy(child.gameObject);
            }
            class_id_click = GetClassIDFromDropdown(class_id_click, class_dropdown, data_class);
            string level_click = dropdown_level_click.options[dropdown_level_click.value].text;
            StartCoroutine(SelectDataRankCustom(URL_click, level_click, class_id_click, data_click_uncut));
            isClick_class = true;
        }
    }
    //Lay data class va them vao list
    IEnumerator SelectClassAndAddToList(string link, List<SaveClassData> list_class, TMP_Dropdown classDropdown_drag, TMP_Dropdown classDropdown_click)
    {
        UnityWebRequest www = UnityWebRequest.Get(link);

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
        string[] dataGetFromLink = usersDataString.Split(';');

        for (int i = 0; i < (dataGetFromLink.Length - 1); i++)
        {
            SaveClassData iData;
            iData.id_class = SaveRankView.GetValueData(dataGetFromLink[i], "id:");
            iData.class_name = SaveRankView.GetValueData(dataGetFromLink[i], "class:");
            list_class.Add(iData);
        }

        isLoaded = true;
    }
    //Them options dropdownlist
    void AddOptionsDropdown(List<SaveClassData> list_class, List<string> list_class_name, TMP_Dropdown classDropdown_drag, TMP_Dropdown classDropdown_click)
    {
        for (int i = 0; i < list_class.Count; i++)
        {
            list_class_name.Add(list_class[i].class_name);
        }

        classDropdown_drag.AddOptions(list_class_name); //them class name vao rank drag
        classDropdown_click.AddOptions(list_class_name); //them class name vao rank click
    }
    //lay id class
    string GetClassIDFromDropdown(string classid, TMP_Dropdown class_dropdown, List<SaveClassData> list_class)
    {
        for (int i = 0; i < list_class.Count; i++)
        {
            if (class_dropdown.options[class_dropdown.value].text == list_class[i].class_name)
            {
                classid = list_class[i].id_class;
                break;
            }
        }
        return classid;
    }
    //Lay Data Rank custom uncut
    IEnumerator SelectDataRankCustom(string link, string level, string classid, List<string> data_uncut)
    {
        UnityWebRequest www = UnityWebRequest.Get(link + level + "&class=" + classid);

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
        string[] saveData = usersDataString.Split(';');

        data_uncut.Clear();

        if (saveData.Length != 0)
        {
            for (int i = 0; i < (saveData.Length - 1); i++)
            {
                data_uncut.Add(saveData[i]);
            }
        }
        isCut = true;


    }
    //cut data thanh Array
    SaveRankData[] CutDataRank(SaveRankData[] data_Rank, List<string> data_uncut)
    {
        if (data_uncut.Count != 0)
        {
            for (int i = 0; i < data_uncut.Count; i++)
            {
                data_Rank[i].idnumber = SaveRankView.GetValueData(data_uncut[i], "id:");
                data_Rank[i].PlayerName = SaveRankView.GetValueData(data_uncut[i], "name:");
                data_Rank[i].LevelGame = SaveRankView.GetValueData(data_uncut[i], "level:");
                data_Rank[i].ClassName = SaveRankView.GetValueData(data_uncut[i], "class:");
                data_Rank[i].TimePlayed = SaveRankView.GetValueData(data_uncut[i], "time:");
            }
            //DataChangeRankTable();
        }
        return data_Rank;
    }
    //Add data to gameobject
    public void AddRankDataToGUI(SaveRankData[] data_Rank, GameObject RankRows, Transform Content)
    {
        if (data_Rank.Length != 0)
        {
            for (int i = 0; i < data_Rank.Length; i++)
            {
                var RankInfo = Instantiate(RankRows, Content);
                RankInfo.GetComponent<InfoHolder>().STT.text = (i + 1).ToString();
                RankInfo.GetComponent<InfoHolder>().Name.text = data_Rank[i].PlayerName;
                RankInfo.GetComponent<InfoHolder>().Class.text = data_Rank[i].ClassName;
                RankInfo.GetComponent<InfoHolder>().Level.text = data_Rank[i].LevelGame;
                RankInfo.GetComponent<InfoHolder>().Time.text = data_Rank[i].TimePlayed;
                if (i == 0)
                {
                    RankInfo.GetComponent<Image>().color = new Color32(255, 238, 0, 255);
                }
                else if (i == 1)
                {
                    RankInfo.GetComponent<Image>().color = new Color32(110, 179, 255, 255);
                }
                else if (i == 2)
                {
                    RankInfo.GetComponent<Image>().color = new Color32(140, 255, 120, 255);
                }
                else if (i % 2 == 0 && i > 2)
                {
                    RankInfo.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                }
                else if (i % 2 != 0 && i > 2)
                {
                    RankInfo.GetComponent<Image>().color = new Color32(240, 240, 240, 255);
                }
            }
        }
        else if (data_Rank.Length == 0)
        {
            var RankInfo = Instantiate(RankRows, Content);
            RankInfo.GetComponent<InfoHolder>().STT.gameObject.SetActive(false);
            RankInfo.GetComponent<InfoHolder>().Name.gameObject.SetActive(false);
            RankInfo.GetComponent<InfoHolder>().Class.gameObject.SetActive(false);
            RankInfo.GetComponent<InfoHolder>().Level.gameObject.SetActive(false);
            RankInfo.GetComponent<InfoHolder>().Time.gameObject.SetActive(false);
            RankInfo.GetComponent<InfoHolder>().Alert.gameObject.SetActive(true);
        }
    }
}
