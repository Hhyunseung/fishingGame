using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TableQuest
{
    public class Quest
    {
        public int qusetId;
        public int questFish;
        public int questCount;
        public int questGold;
    }

    public static Dictionary<int, Quest> QuestData = new Dictionary<int, Quest>();
    public static List<Quest> DataList = new List<Quest>();
}

public class Table_Quest : TableBase
{
    public override void DataLoad()
    {
        StreamReader reader = new StreamReader(Application.dataPath + "/Table/Table_Quest.csv");
        TableQuest.DataList.Clear();

        reader.ReadLine();
        string lineData;

        while (!reader.EndOfStream)
        {
            TableQuest.Quest data = new TableQuest.Quest();
            lineData = reader.ReadLine();
            string[] datas = lineData.Split(",");

            data.qusetId = int.Parse(datas[0]);
            data.questFish = int.Parse(datas[1]);
            data.questCount = int.Parse(datas[2]);
            data.questGold = int.Parse(datas[3]);
            TableQuest.QuestData.Add(data.qusetId, data);
            TableQuest.DataList.Add(data);
        }
        reader.Close();

    }
}
