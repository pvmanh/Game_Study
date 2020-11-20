using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu
{
    public static void SetActiveMenuTrue(GameObject background, GameObject main_object)
    {
        background.SetActive(true);
        main_object.SetActive(true);
        Time.timeScale = 0;
    }
    public static void SetActiveMenuFalse(GameObject background, GameObject main_object)
    {
        main_object.SetActive(false);
        background.SetActive(false);
        Time.timeScale = 1;
    }
    public static void LoadScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
        Time.timeScale = 1;
    }
    public static IEnumerator WaitAnimation(Animator Ani_1, GameObject g_1, string Aname, float tDelay, int alpha_value, bool isCanvasGroup)
    {
        Ani_1.SetTrigger(Aname);
        yield return new WaitForSecondsRealtime(tDelay);
        g_1.GetComponent<CanvasGroup>().alpha = alpha_value;
        g_1.GetComponent<CanvasGroup>().blocksRaycasts = isCanvasGroup;
        g_1.GetComponent<CanvasGroup>().interactable = isCanvasGroup;
    }

    public static IEnumerator LoadAsynchronously(int sceneIndex, GameObject loadingScreen, Slider slider, TextMeshProUGUI progressText)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}
