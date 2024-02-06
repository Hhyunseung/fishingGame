using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneManager : MonoBehaviour
{
    public static string nextScene;
    public static bool IsLoad; // true일 경우 Load, false일 경우 Strat
    [SerializeField] Slider sliderBar;

    public CanvasGroup fadeImage;

    private float loadingTimer; // 로딩 시간
    private float timer;

    private void Start()
    {
        loadingTimer = 2.0f; // 로딩 시간
        timer = 0.0f;

        StartCoroutine(LoadScene());
    }

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;

        SceneManager.LoadScene("LoadingScene");
    }

    IEnumerator LoadScene()
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        while (!op.isDone)
        {
            timer += Time.deltaTime;
            sliderBar.value = timer / loadingTimer;
            if (timer > loadingTimer)
            {
                op.allowSceneActivation = true; // 씬 전환 준비 완료 
            }

            yield return null;
        }
    }

}
