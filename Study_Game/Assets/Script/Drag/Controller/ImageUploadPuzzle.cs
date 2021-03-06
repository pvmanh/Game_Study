﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.EventSystems;
using SFB;
public class ImageUploadPuzzle : MonoBehaviour
{
    string[] path;
    public Texture2D uploadTexture;
    public GameObject App_Click;
    //Chon hinh
    public void OpenExplorer()
    {
        //lay duong dan >< lay dinh dang png, jpg cua texture
        //path = EditorUtility.OpenFilePanel("Overwrite with texture", "","png; *.jpg"); 
        path = StandaloneFileBrowser.OpenFilePanel("Chọn ảnh", "", "png; *.jpg, *.jpeg", false);

        GetImage();
    }
    //Lay hinh
    void GetImage()
    {
        if(path != null)
        {
            StartCoroutine(UpdateImage());
        }
    }
    //cat nhap hinh
    IEnumerator UpdateImage()
    {
        //truy cap duong dan lay texture
        //UnityWebRequest www = UnityWebRequestTexture.GetTexture("file://" + path);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(new System.Uri(path[0]).AbsoluteUri);
        //doi phan hoi ket qua
        yield return www.SendWebRequest();
        if(www.isNetworkError || www.isHttpError) 
        {
            Debug.Log(www.error);
            //EditorUtility.DisplayDialog("Lấyhình ảnh", " lỗi: " + www.error, "OK");
        }
        else 
        {
            //lay hinh da phan hoi thanh cong
            uploadTexture = DownloadHandlerTexture.GetContent(www);
            //Xu ly gan hinh va bat dau man choi
            App_Click.GetComponent<LoadPuzzle>().imgpuzzle = uploadTexture;
            App_Click.GetComponent<LoadPuzzle>().OnPlayLevelSelect();
        }
    }
}
