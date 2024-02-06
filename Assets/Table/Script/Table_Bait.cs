using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System; // Convert

public class TableBait
{
    public class Bait
    {
        public int baitId;
        public bool bossBool;
    }

    public static Dictionary<int, Bait> BaitData = new Dictionary<int, Bait>();
    public static List<Bait> DataList = new List<Bait>();
}
public class Table_Bait : TableBase
{
    public override void DataLoad()
    {
        StreamReader reader = new StreamReader(Application.dataPath + "/Table/Table_Bait.csv");
        TableShop.DataList.Clear();

        reader.ReadLine();
        string lineData;

        while (!reader.EndOfStream)
        {
            TableBait.Bait data = new TableBait.Bait();
            lineData = reader.ReadLine();
            string[] datas = lineData.Split(",");

            data.baitId = int.Parse(datas[0]);
            int bBoss = int.Parse(datas[1]);
            data.bossBool = Convert.ToBoolean(bBoss);
            TableBait.BaitData.Add(data.baitId, data);
            TableBait.DataList.Add(data);
        }
        reader.Close();
    }
}
