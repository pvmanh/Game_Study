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
    public void LoadLevel (int sceneIndex)
    {
        StartCoroutine(Menu.LoadAsynchronously(sceneIndex, loadinggScreen, slider, progressText));
        Time.timeScale=1;
    }
    public void ButtonSaveRankOK(int sceneIndex)
    {
        Debug.Log("Save Rank.");
        StartCoroutine(Menu.LoadAsynchronously(sceneIndex, loadinggScreen, slider, progressText));
    }
}
