using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu
{
    //set true 2 menu
    public static void SetActiveMenuTrue(GameObject background, GameObject main_object)
    {
        background.SetActive(true);
        main_object.SetActive(true);
        Time.timeScale = 0;
    }
    //set false 2 menu
    public static void SetActiveMenuFalse(GameObject background, GameObject main_object)
    {
        main_object.SetActive(false);
        background.SetActive(false);
        Time.timeScale = 1;
    }
    //load man moi theo string
    public static void LoadScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
        Time.timeScale = 1;
    }
    //doi animation menu
    public static IEnumerator WaitAnimation(Animator Ani_1, GameObject g_1, string Aname, float tDelay, int alpha_value, bool isCanvasGroup)
    {
        Ani_1.SetTrigger(Aname);
        yield return new WaitForSecondsRealtime(tDelay);
        g_1.GetComponent<CanvasGroup>().alpha = alpha_value;
        g_1.GetComponent<CanvasGroup>().blocksRaycasts = isCanvasGroup;
        g_1.GetComponent<CanvasGroup>().interactable = isCanvasGroup;
    }
    //them anh vao list
    public static List<Image> AddMenuTitle(GameObject ParentMenuTitle)
    {
        List<Image> ListImg = new List<Image>{};
        foreach (Transform Child in ParentMenuTitle.transform)
        {
            ListImg.Add(Child.gameObject.GetComponent<Image>());
        }
        return ListImg;
    }
    //them menu con vao list
    public static List<GameObject> AddMenuSubSelect(GameObject ParentMenuTitle)
    {
        List<GameObject> ListSub = new List<GameObject>{};
        foreach (Transform Child in ParentMenuTitle.transform)
        {
            ListSub.Add(Child.gameObject);
        }
        return ListSub;
    }
    //load % khi load man moi
    public static IEnumerator LoadAsynchronously(int sceneIndex, GameObject loadingScreen, Slider slider, TextMeshProUGUI progressText)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progressText.text = (progress * 100f).ToString("0") + "%";

            yield return null;
        }
    }
}
