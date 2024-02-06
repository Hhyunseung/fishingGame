using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// 낚싯대 업그레이드에 따른 물고기 확률
public class TableBobber
{
    public class Bobber
    {
        public int randomId;
        public float commonValue;
        public float epicValue;
        public float bossValue;
    }

    public static Dictionary<int, Bobber> BobberData = new Dictionary<int, Bobber>();
    public static List<Bobber> DataList = new List<Bobber>();
}
public class Table_Bobber : TableBase
{
    public override void DataLoad()
    {
        StreamReader reader = new StreamReader(Application.dataPath + "/Table/Table_Bobber.csv");
        TableBobber.BobberData.Clear();
        TableBobber.DataList.Clear();

        reader.ReadLine();
        string lineData;

        while (!reader.EndOfStream)
        {
            TableBobber.Bobber data = new TableBobber.Bobber();
            lineData = reader.ReadLine();
            string[] datas = lineData.Split(",");

            data.randomId = int.Parse(datas[0]);
            data.commonValue = float.Parse(datas[1]);
            data.epicValue = float.Parse(datas[2]);
            data.bossValue = float.Parse(datas[3]);

            TableBobber.BobberData.Add(data.randomId, data);
            TableBobber.DataList.Add(data);
        }
        reader.Close();
    }
}
