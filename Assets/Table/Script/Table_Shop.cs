using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TableShop
{
    public class Shop
    {
        public int shopId;
        public int price;
        public int itemId;
        public int itemImage; // 상점 이미지 추가
    }

    public static Dictionary<int, Shop> ShopData = new Dictionary<int, Shop>();
    public static List<Shop> DataList = new List<Shop>();
}
public class Table_Shop : TableBase
{
    public override void DataLoad()
    {
        StreamReader reader = new StreamReader(Application.dataPath + "/Table/Table_Shop.csv");
        TableShop.DataList.Clear();

        reader.ReadLine();
        string lineData;

        while (!reader.EndOfStream)
        {
            TableShop.Shop data = new TableShop.Shop();
            lineData = reader.ReadLine();
            string[] datas = lineData.Split(",");

            data.shopId = int.Parse(datas[0]);
            data.price = int.Parse(datas[1]);
            data.itemId = int.Parse(datas[2]);
            data.itemImage = int.Parse(datas[3]);
            TableShop.ShopData.Add(data.shopId, data);
            TableShop.DataList.Add(data);
        }
        reader.Close();
    }
}
