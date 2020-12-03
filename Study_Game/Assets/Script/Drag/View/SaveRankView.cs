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
    //Ham lay du lieu
    public static void AddRankData(PuzzleModel puzzleData, TimeModel timeData)
    {
        PlayerName = puzzleData.str_name; 
        ClassName = puzzleData.str_class;
        LevelGame = puzzleData.level;
        TimePlayed = timeData.txt_time.text;
    }
    //them du lieu vai mysql.
    public static IEnumerator AddRankDrag(string URL, string rank_id, string rank_name, string rank_class, string rank_level, string rank_time)
    {
        //data dung de post tuong ung mysql trong php
        WWWForm form = new WWWForm();
        form.AddField ("addIDrank", rank_id);
        form.AddField("addnamerank",rank_name);
        form.AddField("addclasrank",rank_class);
        form.AddField("addlevelrank",rank_level);
        form.AddField("addtimerank",rank_time);

        //Post form len php => insert into
        UnityWebRequest www = UnityWebRequest.Post(URL, form);
        yield return www.SendWebRequest();
        if(www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
        }
        else {
            Debug.Log("Form upload complete!");
        }
    }
    //Cat du lieu string lay dc
    public static string GetValueData(string data, string index)
    {
        //Tim vi tri index trong data can cat => cat chuoi tu vi tri do den het
        string value = data.Substring (data.IndexOf(index) + index.Length);
        if(value.Contains("|"))
        {
            //Cat chuoi sau |
            value = value.Remove (value.IndexOf("|"));
        }
        return value;
    }
}
