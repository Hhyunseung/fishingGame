using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest_Update : Quest_Ui
{
    public static Quest[] QuestArray;
    public static bool CatchQuestFish;

    Quest quest;

    // ����Ʈ �ʱ�ȭ
    public void SetQuest()
    {
        for (int i = 0; i < 3; i++)
        {
            Quest quest = new Quest();
            QuestArray[i] = quest;
        }
    }

    private void Awake()
    {
        quest = new Quest();
        QuestArray = new Quest[3];

        SetQuest();

        // Load �� ���
        if (TrunScene.IsLoad)
        {
            SaveData.instance.LoadQuest();

            for (int i = 0; i < QuestArray.Length; i++)
            {
                if (QuestArray[i].QuestId != 0)
                {
                    QuestArray[i] = quest.CreatedQuest(QuestArray[i].QuestId);
                    QuestArray[i].QuestStep = SaveData.instance.jsonData.JsonQuestStep[i];

                    NewQuestPanel(i);
                }
            }
        }
    }

    public void OnClickQuestButton(int index)
    {
        GameManager.Player.Gold += QuestArray[index].QuestGold;

        AudioManager.Instance.PlayEFSound("Quest");
        QuestButton[index].interactable = false;
        NewQuestId(index);
    }

    /// <summary> ���̵��� ���� ���� ����Ʈ ��ȯ </summary>
    public void NewQuestId(int index)
    {
        // ���� ����� ����Ʈ �Ϸ� ��
        if (index == 2)
            if (QuestArray[2].QuestStep == 1)
            {
                TimeChange_Ui.SeasonBool = true;
                CatchBossFish();
                return;
            }

        switch (GameManager.TimeChange.Season)
        {
            case TimeChange.Seasons.Spring:
                if      (index == 0) QuestArray[index] = quest.CreatedQuest(Random.Range(70001, 70004));
                else if (index == 1) QuestArray[index] = quest.CreatedQuest(Random.Range(70004, 70006));
                else if (index == 2) QuestArray[index] = quest.CreatedQuest(70006);
                break;
            case TimeChange.Seasons.Summer:
                if      (index == 0) QuestArray[index] = quest.CreatedQuest(Random.Range(70101, 70104));
                else if (index == 1) QuestArray[index] = quest.CreatedQuest(Random.Range(70104, 70106));
                else if (index == 2) QuestArray[index] = quest.CreatedQuest(70106);
                break;
            case TimeChange.Seasons.Falling:
                if (index == 0) QuestArray[index] = quest.CreatedQuest(Random.Range(70201, 70204));
                else if (index == 1) QuestArray[index] = quest.CreatedQuest(Random.Range(70204, 70206));
                else if (index == 2) QuestArray[index] = quest.CreatedQuest(70206);
                break;
            case TimeChange.Seasons.Winter:
                if (index == 0) QuestArray[index] = quest.CreatedQuest(Random.Range(70301, 70304));
                else if (index == 1) QuestArray[index] = quest.CreatedQuest(Random.Range(70304, 70306));
                else if (index == 2) QuestArray[index] = quest.CreatedQuest(70306);
                break;
        }

        NewQuestPanel(index);
    }

    /// <summary> ����Ʈ ����⸦ ����� ��, QuestStep ���� �� ��ư Ȱ��ȭ </summary>
    public void QuestStepUp()
    {
        for (int i = 0; i < QuestArray.Length; i++)
        {
            if (Fish_Fishing.fish.FishId == QuestArray[i].QuestFish)
            {
                QuestArray[i].QuestStep++;
                QuestSteps[i].text = QuestArray[i].QuestStep + " / " + QuestArray[i].QuestCount;

                if (QuestArray[i].QuestStep == QuestArray[i].QuestCount
                    && !QuestButton[i].interactable)
                {
                    QuestButton[i].interactable = true;
                }
            }
        }
    }

    public void CatchBossFish()
    {
        SetQuest();
        ResetPanel();

        GameManager.Instance.ResetSeason();
        Shop_Shopping.Instance.ResetShop();
    }

    /// <summary> ��ư ��Ȱ��ȭ </summary>
    public void InteractableQuest(Button btn)
    {
        btn.interactable = false;
    }

    void Update()
    {
        if (CatchQuestFish)
        {
            QuestStepUp();
            CatchQuestFish = false;
        }
    }
}
