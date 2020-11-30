using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;

public class SaveRankView
{
    public static string PlayerName; //thong tin STT
    public static string ClassName; //thong tin STT
    public static int LevelGame; //thong tin STT
    public static string TimePlayed; //thong tin STT
    public static void AddRankData(PuzzleModel puzzleData, TimeModel timeData)
    {
        PlayerName = puzzleData.str_name; 
        ClassName = puzzleData.str_class;
        LevelGame = puzzleData.level;
        TimePlayed = timeData.txt_time.text;
    }
    public static IEnumerator AddRankDrag(string URL, string rank_id, string rank_name, string rank_class, string rank_level, string rank_time)
    {
        WWWForm form = new WWWForm();
        form.AddField ("addIDrank", rank_id);
        form.AddField("addnamerank",rank_name);
        form.AddField("addclasrank",rank_class);
        form.AddField("addlevelrank",rank_level);
        form.AddField("addtimerank",rank_time);

        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Form upload complete!");
        }
    }
    public static string GetValueData(string data, string index)
    {
        string value = data.Substring (data.IndexOf(index) + index.Length);
        if(value.Contains("|"))
        {
            value = value.Remove (value.IndexOf("|"));
        }
        return value;
    }
}
