using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrunScene : MonoBehaviour
{
    public static bool IsLoad; // true일 경우 Load, false일 경우 Start
                               // public Image loading;

    public CanvasGroup fadeImage;

    string _sceneName;
    private static TrunScene instance;
    public static TrunScene Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnSceneLoad; // 델리게이트 연결
    }

    /// <summary> LoadingScene 에서는 fadeImage 비활성화 </summary>
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "LoadingScene")
            fadeImage.gameObject.SetActive(false);
        else
            fadeImage.gameObject.SetActive(true);
    }

    /// <summary> Scene 변경 시 fadeImage 알파 변경 </summary>
    public void SceneChange(string sceneName)
    {
        _sceneName = sceneName;

        fadeImage.DOFade(1, 1.0f)
            .OnStart(() => { fadeImage.blocksRaycasts = true; } ) // Raycast를 막음
            .OnComplete(() => { LoadingSceneManager.LoadScene(sceneName); } );
    }

    /// <summary> SceneCange 완료 시 fadeImage 알파 변경 </summary>
    public void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if(scene.name.Equals(_sceneName))
        {
            fadeImage.DOFade(0, 1.0f)
            .OnStart(() => { })
            .OnComplete(() => { fadeImage.blocksRaycasts = false; });
        }
    }

    public void IsLoadGame(bool load)
    {
        IsLoad = load;
    }
}
