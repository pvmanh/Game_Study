using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class LoadClassName : MonoBehaviour
{
    private static readonly string FirstPlay_Name_Box = "FirstPlay_Name_Box";
    private static readonly string Student_Name = "Student_Name";
    private static readonly string Student_Class = "Student_Class";
    [System.Serializable]
    public struct SaveClassData
    {
        public string id_class;
        public string class_name;
    }
    public bool isLoaded = false;
    string URL_class = "http://localhost/xampp/select_class.php";
    public List<SaveClassData> data_class;
    public List<string> data_Class_name;
    public TMP_Dropdown dropdown_class_;
    public TMP_InputField dropdown_name_;
    public GameObject Main_Menu;
    public string class_id_select;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelectClassAndAddToList(URL_class, data_class));
    }

    private void Update() {
        if(isLoaded == true)
        {
            AddOptionsDropdown(data_class, data_Class_name, dropdown_class_);
            isLoaded = false;
        }
    }

    IEnumerator SelectClassAndAddToList(string link, List<SaveClassData> list_class)
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
    void AddOptionsDropdown(List<SaveClassData> list_class, List<string> list_class_name, TMP_Dropdown classDropdown_)
    {
        list_class_name.Clear();
        for(int i = 0; i < list_class.Count; i++)
        {
            list_class_name.Add(list_class[i].class_name);
        }

        classDropdown_.AddOptions(list_class_name); //them class name vao

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

    public void Id_get_Changed()
    {
        class_id_select = GetClassIDFromDropdown(class_id_select, dropdown_class_, data_class);
        Debug.Log(class_id_select);
    }
    //Luu ten va lop hoc sinh
    public void SetNamePlayerPrefs()
    {
        PlayerPrefs.SetString(Student_Name, dropdown_name_.text);
        PlayerPrefs.SetString(Student_Class, class_id_select);
        PlayerPrefs.SetInt(FirstPlay_Name_Box, -1);
    }
}
