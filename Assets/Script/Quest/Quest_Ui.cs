using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Quest_Ui : MonoBehaviour
{
    public GameObject ShopPanel;

    public Button[] QuestButton;
    public Image[] QuestImage;
    public TextMeshProUGUI[] QuestSteps;

    public void NewQuestPanel(int index)
    {
        for (int j = 0; j < ResourceManager.Instance.fishSprite.Length; j++)
        {
            if (TableFish.FishData[Quest_Update.QuestArray[index].QuestFish].fishImage
                == ResourceManager.Instance.fishSprite[j].name)

                QuestImage[index].sprite = ResourceManager.Instance.fishSprite[j];
        }

        QuestSteps[index].text = Quest_Update.QuestArray[index].QuestStep + " / " + Quest_Update.QuestArray[index].QuestCount;
        
        if (Quest_Update.QuestArray[index].QuestStep == 0 ||
            Quest_Update.QuestArray[index].QuestStep < Quest_Update.QuestArray[index].QuestCount)
            QuestButton[index].interactable = false;

    }

    public void ResetPanel()
    {
        for (int i = 0; i < QuestImage.Length; i++)
        {
            QuestButton[i].interactable = true;
            QuestImage[i].sprite = Resources.Load<Sprite>("UISystem/question mark");
            QuestSteps[i].text = "Click !";
        }
    }
}
