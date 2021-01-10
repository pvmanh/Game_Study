using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadingScene : MonoBehaviour
{
    public GameObject loadinggScreen;
    public Slider slider;
    public TextMeshProUGUI progressText;
    //Load man theo so index scene
    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine(Menu.LoadAsynchronously(sceneIndex, loadinggScreen, slider, progressText));
        Time.timeScale=1;
    }
    //save rank thoat ve manu chinh => hien ko can
    public void ButtonSaveRankOK(int sceneIndex)
    {
        Debug.Log("Save Rank.");
        StartCoroutine(Menu.LoadAsynchronously(sceneIndex, loadinggScreen, slider, progressText));
    }
    public void Disable_Gameobject(GameObject gobj)
    {
        gobj.SetActive(false);
    }
    public void Enable_Gameobject(GameObject gobj)
    {
        gobj.SetActive(true);
    }
}
