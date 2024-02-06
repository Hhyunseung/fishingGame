using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public bool QuestOpen { get { return _questOpen; } set { _questOpen = value; } }
    public int QuestId { get { return _questId; } set { _questId = value; } }
    public int QuestFish { get { return _questFish; } set { _questFish = value; } }
    public int QuestCount { get { return _questCount; } set { _questCount = value; } }
    public int QuestStep 
    { 
        get { return _questStep; } 
        set 
        {
            _questStep = value;

            if (_questStep > _questCount)
            {
                _questStep = _questCount;
            }
        } 
    }
    public int QuestGold { get { return _questGold; } set { _questGold = value; } }

    private bool _questOpen;
    private int _questId;
    private int _questFish;
    private int _questCount;
    private int _questStep;
    private int _questGold;

    public Quest CreatedQuest(int key)
    {
        TableQuest.Quest data = TableQuest.QuestData[key];

        Quest quest = new Quest();
        quest._questId = data.qusetId;
        quest._questFish = data.questFish;
        quest._questCount = data.questCount;
        quest._questStep = 0;
        quest._questGold = data.questGold;

        return quest;
    }
}
