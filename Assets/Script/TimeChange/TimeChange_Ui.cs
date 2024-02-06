using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeChange_Ui : MonoBehaviour
{
    public static bool TimeBool;
    public static bool SeasonBool;

    public Image changeFill;
    public Transform changeTime;
    public Image seasonImage;
    public TextMeshProUGUI text;

    private void Awake()
    {
        ChangeCount();

        float vecX = 0.0f;
        float vecY = 0.0f;

        if (GameManager.TimeChange.Hour)
            vecY = 0.0f;
        else
            vecY = -10.0f;

        if (GameManager.TimeChange.Season == TimeChange.Seasons.Spring)
        {
            seasonImage.sprite = ResourceManager.Instance.seasonSprite[0];
            vecX = 0.0f;
        }
        else if (GameManager.TimeChange.Season == TimeChange.Seasons.Summer)
        {
            seasonImage.sprite = ResourceManager.Instance.seasonSprite[1];
            vecX = -17.8f;
        }
        else if (GameManager.TimeChange.Season == TimeChange.Seasons.Falling)
        {
            seasonImage.sprite = ResourceManager.Instance.seasonSprite[2];
            vecX = -35.6f;
        }
        else if (GameManager.TimeChange.Season == TimeChange.Seasons.Winter)
        {
            seasonImage.sprite = ResourceManager.Instance.seasonSprite[3];
            vecX = -53.4f;
        }

        changeTime.localPosition = new Vector2(vecX, vecY);
    }

    void ChangeCount()
    {
        changeFill.fillAmount = (float)GameManager.TimeChange.FishCount / 150;

        text.text = GameManager.TimeChange.FishCount.ToString() + " / 150";
    }

    void ChangeTime()
    {
        if (GameManager.TimeChange.FishCount == 150)
        {
            Fish_Fishing.StopFishing = true;

            if (GameManager.TimeChange.Hour)
            {
                changeTime.DOLocalMoveY(0f, 1.0f).SetEase(Ease.OutQuad)
                .OnComplete(() => { Fish_Fishing.StopFishing = false; GameManager.TimeChange.FishCount = 0; });
                DialogManager.Instance.TimeDialog("아침");
            }
            else
            {
                changeTime.DOLocalMoveY(-10f, 1.0f).SetEase(Ease.OutQuad)
                .OnComplete(() => { Fish_Fishing.StopFishing = false; GameManager.TimeChange.FishCount = 0; });
                DialogManager.Instance.TimeDialog("밤");
            }
        }
    }

    void ChangeSeason()
    {
        if (SeasonBool)
        {
            TimeChange.Seasons season = GameManager.TimeChange.Season;
            int seasonNumber = (int)season;
            ++seasonNumber;

            GameManager.TimeChange.Season = (TimeChange.Seasons)seasonNumber;

            if (GameManager.TimeChange.Season == TimeChange.Seasons.Summer)
            {
                changeTime.DOLocalMoveX(-17.8f, 1.0f).SetEase(Ease.OutQuad)
                          .OnComplete(() => { Fish_Fishing.StopFishing = false; GameManager.TimeChange.FishCount = 0; });
                DialogManager.Instance.TimeDialog("여름");
                seasonImage.sprite = ResourceManager.Instance.seasonSprite[1];
            }
            else if (GameManager.TimeChange.Season == TimeChange.Seasons.Falling)
            {
                changeTime.DOLocalMoveX(-35.6f, 1.0f).SetEase(Ease.OutQuad)
                          .OnComplete(() => { Fish_Fishing.StopFishing = false; GameManager.TimeChange.FishCount = 0; });
                DialogManager.Instance.TimeDialog("가을");
                seasonImage.sprite = ResourceManager.Instance.seasonSprite[2];
            }
            else if (GameManager.TimeChange.Season == TimeChange.Seasons.Winter)
            {
                changeTime.DOLocalMoveX(-53.4f, 1.0f).SetEase(Ease.OutQuad)
                          .OnComplete(() => { Fish_Fishing.StopFishing = false; GameManager.TimeChange.FishCount = 0; });
                DialogManager.Instance.TimeDialog("겨울");
                seasonImage.sprite = ResourceManager.Instance.seasonSprite[3];
            }

            SeasonBool = false;
        }
    }

    void Update()
    {
        if (TimeBool)
        {
            GameManager.TimeChange.FishCount++;
            ChangeCount();
            ChangeTime();
            TimeBool = false;
        }

        ChangeSeason();
    }
}
