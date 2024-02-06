using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public enum FishRare
{
    Trash,
    Common,
    Epic,
    Boss
}
public enum FishSeason
{
    Spring,
    Summer,
    Fall,
    Winter
}
public class TableFish
{
    public class Fish
    {
        public int fishId;
        public string fishName;
        public string fishImage;
        public FishRare fishRare;
        public int fishGold;
        public FishSeason fishSeason;
        public int fishDay;
        public string fishExplain;
        public bool fishCatchBook;
    }

    public static Dictionary<int, Fish> FishData = new Dictionary<int, Fish>();
    public static List<Fish> DataList = new List<Fish>();
}

public class Table_Fish : TableBase
{
    public override void DataLoad()
    {
        StreamReader reader = new StreamReader(Application.dataPath + "/Table/Table_Fish_UTF33.txt");
        TableFish.FishData.Clear();
        TableFish.DataList.Clear();

        reader.ReadLine();
        string lineData;

        while (!reader.EndOfStream)
        {
            TableFish.Fish data = new TableFish.Fish();
            lineData = reader.ReadLine();
            string[] datas = lineData.Split(",");

            data.fishId = int.Parse(datas[0]);
            data.fishName = datas[1];
            data.fishImage = datas[2];
            data.fishRare = (FishRare)System.Enum.Parse(typeof(FishRare), datas[3]);
            data.fishGold = int.Parse(datas[4]);
            data.fishSeason = (FishSeason)System.Enum.Parse(typeof(FishSeason), datas[5]);
            data.fishDay = int.Parse(datas[6]);
            data.fishExplain = datas[7];
            data.fishCatchBook = false;

            TableFish.FishData.Add(data.fishId, data);
            TableFish.DataList.Add(data);
        }
        reader.Close();
    }
}
