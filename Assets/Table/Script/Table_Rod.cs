using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TableRod
{
    public class Rod
    {
        public int rodId;
        public float rodSpeed;
    }

    public static Dictionary<int, Rod> RodData = new Dictionary<int, Rod>();
    public static List<Rod> DataList = new List<Rod>();
}

public class Table_Rod : TableBase
{
    public override void DataLoad()
    {
        StreamReader reader = new StreamReader(Application.dataPath + "/Table/Table_Rod.csv");
        TableRod.RodData.Clear();
        TableRod.DataList.Clear();

        reader.ReadLine();
        string lineData;

        while(!reader.EndOfStream)
        {
            TableRod.Rod data = new TableRod.Rod();
            lineData = reader.ReadLine();
            string[] datas = lineData.Split(",");

            data.rodId = int.Parse(datas[0]);
            data.rodSpeed = float.Parse(datas[1]);

            TableRod.RodData.Add(data.rodId, data);
            TableRod.DataList.Add(data);
        }
        reader.Close();
    }
}
