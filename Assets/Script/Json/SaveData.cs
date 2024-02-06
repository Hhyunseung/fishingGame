using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class JsonData
{
    // 현재 스탯(착용중인 장비)
    public int JsonRod;
    public int JsonBobber;
    public int JsonBait;

    // 골드, 잡은 물고기 수
    public int JsonGold;
    public int JsonFishCount;

    // 상점 
    public int JsonShopRod;
    public int JsonShopBobber;
    public int JsonShopBait;

    // 도감
    public bool[] JsonFishCatch;

    // 시간
    public int JsonYear;
    public bool JsonHour;
    public TimeChange.Seasons JsonSeason;
    public int FishCount;

    // 퀘스트
    public int[] JsonQuestId;
    public int[] JsonQuestStep;
}

public class SaveData : MonoBehaviour
{
    public static SaveData instance;

    public JsonData jsonData = new JsonData();

    public string path;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        path = Application.dataPath + "/";

        LoadJsonFile();
    }

    public void SaveJsonData()
    {
        // 현재 스탯(착용중인 장비)
        jsonData.JsonRod = GameManager.Player.PlayerRod;
        jsonData.JsonBobber = GameManager.Player.PlayerBobber;
        jsonData.JsonBait = GameManager.Player.PlayerBait;

        // 골드
        jsonData.JsonGold = GameManager.Player.Gold;

        // 상점
        jsonData.JsonShopRod = GameManager.Shop.ShopRod;
        jsonData.JsonShopBobber = GameManager.Shop.ShopBobber;
        jsonData.JsonShopBait = GameManager.Shop.ShopBait;

        // 도감
        jsonData.JsonFishCatch = new bool[TableFish.DataList.Count];
        for (int i = 0; i < TableFish.DataList.Count; i++)
        {
            jsonData.JsonFishCatch[i] = GameManager.BookFish.PlayerCatchFish[i];
        }

        // 시간
        jsonData.JsonYear = GameManager.TimeChange.Year;
        jsonData.JsonHour = GameManager.TimeChange.Hour;
        jsonData.JsonSeason = GameManager.TimeChange.Season;
        jsonData.JsonFishCount = GameManager.TimeChange.FishCount;

        // 퀘스트
        jsonData.JsonQuestId = new int[Quest_Update.QuestArray.Length];
        jsonData.JsonQuestStep = new int[Quest_Update.QuestArray.Length];
        for (int i = 0; i < Quest_Update.QuestArray.Length; i++)
        {
            jsonData.JsonQuestId[i] = Quest_Update.QuestArray[i].QuestId;
            jsonData.JsonQuestStep[i] = Quest_Update.QuestArray[i].QuestStep;
        }

        string data = JsonUtility.ToJson(jsonData, true);
        File.WriteAllText(path + "JsonData" + ".json", data);
    }

    public void LoadJsonFile()
    {
        string data = File.ReadAllText(path + "JsonData" + ".json");
        jsonData = JsonUtility.FromJson<JsonData>(data);
    }

    public void LoadPlayer()
    {
        GameManager.Player.PlayerRod = jsonData.JsonRod;
        GameManager.Player.PlayerBobber = jsonData.JsonBobber;
        GameManager.Player.PlayerBait = jsonData.JsonBait;

        GameManager.Player.Gold = jsonData.JsonGold;
    }

    public void LoadShop()
    {
        GameManager.Shop.ShopRod = jsonData.JsonShopRod;
        GameManager.Shop.ShopBobber = jsonData.JsonShopBobber;
        GameManager.Shop.ShopBait = jsonData.JsonShopBait;
    }

    public void LoadCatchFish()
    {
        GameManager.BookFish.PlayerCatchFish = new bool[TableFish.DataList.Count];
        for (int i = 0; i < TableFish.DataList.Count; i++)
        {
            GameManager.BookFish.PlayerCatchFish[i] = jsonData.JsonFishCatch[i];
        }
    }
    public void LoadTimeChange()
    {
        GameManager.TimeChange.Year = jsonData.JsonYear;
        GameManager.TimeChange.Hour = jsonData.JsonHour;
        GameManager.TimeChange.Season = jsonData.JsonSeason;
        GameManager.TimeChange.FishCount = jsonData.JsonFishCount;
    }

    public void LoadQuest()
    {
        for (int i = 0; i < Quest_Update.QuestArray.Length; i++)
        {
            Quest_Update.QuestArray[i].QuestId = jsonData.JsonQuestId[i];
        }
    }


    /// <summary> 저장된 파일이 있는지 확인 </summary>
    public bool CheckJsonFile()
    {
        bool jsonFile = File.Exists(SaveData.instance.path + "JsonData" + ".json");
        return jsonFile;
    }
}
