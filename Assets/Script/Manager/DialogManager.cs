using System.Collections;
using System.Collections.Generic;
using TMPro;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;

    public TextMeshProUGUI TimeText;
    public TextMeshProUGUI ShopText;
    public TextMeshProUGUI SaveText;
    
    Color colors;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance.gameObject);

        colors.a = 0f;
        TimeText.color = colors;
        ShopText.color = colors;
    }

    public void TimeDialog(string text)
    {
        TimeText.text = "<color=#FFFAF0>" + text + "<color=#FFFAF0>";

        TimeText.transform.DOLocalMoveY(220.0f, 1.5f).SetEase(Ease.Unset)
            .OnStart(() => TimeText.DOFade(1.0f, 1.5f))
            .OnComplete(() => TimeText.DOFade(0.0f, 1.0f)
            .OnComplete(() => TimeText.transform.DOLocalMoveY(0.0f, 0f)));
    }

    public void ShopDialog(string text)
    {
        ShopText.text = "<color=#FFFAF0>" + text + "<color=#FFFAF0>";

        ShopText.DOFade(1.0f, 1.0f)
            .OnComplete(() => ShopText.DOFade(0.0f, 1.0f));
    }

    public void SaveDialog(string text)
    {
        SaveText.text = "<color=#FFFAF0>" + text + "<color=#FFFAF0>";

        SaveText.DOFade(1.0f, 1.0f)
            .OnComplete(() => SaveText.DOFade(0.0f, 1.0f));
    }
}
