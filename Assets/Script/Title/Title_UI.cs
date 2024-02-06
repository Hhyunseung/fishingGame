using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Title_UI : MonoBehaviour
{
    public Button loadBtn;
    public Button startBtn;

    public Image logo;
    public Image fadeImage;
    public Image fadeImageLogo;

    void Awake()
    {
        if (!SaveData.instance.CheckJsonFile())
        {
            loadBtn.interactable = false;
            loadBtn.animator.SetBool("BtnPressed", true);
        }

        SetActiveObject(false);
        FadeTitleImage();
    }

    void FadeTitleImage()
    {
        fadeImage.DOFade(1.0f, 2.0f)
            .OnComplete(() => fadeImageLogo.DOFade(1.0f, 3.0f)
            .OnComplete(() => fadeImageLogo.DOFade(0, 2.0f)
            .OnComplete(() => fadeImage.DOFade(0, 4.0f).OnStart(()=> AudioManager.Instance.PlayBGSound("Title"))
            .OnComplete(() => { fadeImage.gameObject.SetActive(false); SetActiveObject(true); }))));
    }

    void SetActiveObject(bool type)
    {
        loadBtn.gameObject.SetActive(type);
        startBtn.gameObject.SetActive(type);
        logo.gameObject.SetActive(type);
    }
}
