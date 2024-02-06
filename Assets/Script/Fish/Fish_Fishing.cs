using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish_Fishing : Fish_Event
{
    FishRare fishRare;
    TimeChange.Seasons fishSeason;

    public static bool StopFishing; // 낚시를 멈출 때 true 
    public static Fish fish;

    int fishCount; // 잡은 물고기 수
    float delay;

    void Start()
    {
        CatchFish = false;
        delay = 0.0f;
        fish = new Fish();

        //nowFish = false;
    }

    /// <summary> 레어도와 계절에 따라 랜덤 물고기 반환 </summary>
    public int SpawnFish(FishRare fishRare, TimeChange.Seasons fishSeason)
    {
        int randomValue;

        switch (fishRare)
        {
            case FishRare.Common:
                switch (fishSeason)
                {
                    case TimeChange.Seasons.Spring:  randomValue = Random.Range(10001, 10006); break;
                    case TimeChange.Seasons.Summer:  randomValue = Random.Range(10101, 10106); break;
                    case TimeChange.Seasons.Falling: randomValue = Random.Range(10201, 10206); break;
                    case TimeChange.Seasons.Winter:  randomValue = Random.Range(10301, 10306); break;
                    default: randomValue = 0; break;
                }
                break;

            case FishRare.Epic:
                if (GameManager.TimeChange.Hour) // 낮
                    switch (fishSeason)
                    {
                        case TimeChange.Seasons.Spring:  randomValue = Random.Range(20001, 20004); break;
                        case TimeChange.Seasons.Summer:  randomValue = Random.Range(20101, 20104); break;
                        case TimeChange.Seasons.Falling: randomValue = Random.Range(20201, 20204); break;
                        case TimeChange.Seasons.Winter:  randomValue = Random.Range(20301, 20304); break;
                        default: randomValue = 0; break;
                    }
                else // 밤
                    switch (fishSeason) 
                    {
                        case TimeChange.Seasons.Spring:  randomValue = Random.Range(21001, 21004); break;
                        case TimeChange.Seasons.Summer:  randomValue = Random.Range(21101, 21104); break;
                        case TimeChange.Seasons.Falling: randomValue = Random.Range(21201, 21204); break;
                        case TimeChange.Seasons.Winter:  randomValue = Random.Range(21301, 21304); break;
                        default: randomValue = 0; break;
                    }
                break;

            case FishRare.Boss:
                switch (fishSeason)
                {
                    case TimeChange.Seasons.Spring:  randomValue = 30001; break;
                    case TimeChange.Seasons.Summer:  randomValue = 30101; break;
                    case TimeChange.Seasons.Falling: randomValue = 30201; break;
                    case TimeChange.Seasons.Winter:  randomValue = 30301; break;
                    default: randomValue = 0; break;
                }
                break;

            default:
                randomValue = 0; // 쓰레기
                break;
        }

        return randomValue;
    }

    /// <summary>
    /// 장비 업그레이드에 따라 레어도 확률 조절 후 물고기 반환
    /// </summary>
    /// 
    public Fish RandomFish(int _fPercent)
    {
        float commonValue = TableBobber.BobberData[_fPercent].commonValue;
        float epicValue = TableBobber.BobberData[_fPercent].epicValue;
        float bossValue = TableBobber.BobberData[_fPercent].bossValue;

        // 보스물고기 확률 추가
        if (TableBait.BaitData[GameManager.Player.PlayerBait].bossBool)
            bossValue += 30;

        float[] FishArray = new float[] { commonValue, epicValue, bossValue };

        FishRare RandomFunc(float[] fishArray)
        {
            float total = 0;

            foreach (float elem in fishArray)
            {
                total += elem;
            }
            float randomPoint = Random.value * total;

            for (int i = 0; i < fishArray.Length; i++)
            {
                if (randomPoint < fishArray[i])
                {
                    switch (i)
                    {
                        case 0:
                            fishRare = FishRare.Common;
                            return fishRare;
                        case 1:
                            fishRare = FishRare.Epic;
                            return fishRare;
                        case 2:
                            fishRare = FishRare.Boss;
                            return fishRare;
                    }
                }
                else
                {
                    randomPoint -= fishArray[i];
                }
            }

            return FishRare.Common;
        }

        fishRare = RandomFunc(FishArray);
        fishSeason = GameManager.TimeChange.Season;

        int randomValue = SpawnFish(fishRare, fishSeason);

        return fish.CreatedFish(randomValue);
    }


    /// <summary> 낚는 속도를 조절하여 낚시 </summary>
    public void SpeedFish(int _fSpeed)
    {
        float fishingTime = TableRod.RodData[_fSpeed].rodSpeed;

        delay += Time.deltaTime;
        if (delay >= fishingTime)
        {
            delay -= fishingTime;
            fish = RandomFish(GameManager.Player.PlayerBobber);
            ani.Play("PlayerFishing");
            
            // 이벤트
            if (fish.FishRare == FishRare.Epic || fish.FishRare == FishRare.Boss)
            {
                AudioManager.Instance.PlayEFSound("Event");
                SetEvent();

                EventFishing = true;
            }
            else
            {
                CatchFish = true;
            }
        }
    }

    /// <summary> PlayerCatchBook 도감 리스트 갱신 </summary>
    public void RenewCatchBook(Fish fish)
    {
        for (int i = 0; i < TableFish.DataList.Count; i++)
        {
            if (fish.FishId == TableFish.DataList[i].fishId && !GameManager.BookFish.PlayerCatchFish[i])
            {
                GameManager.BookFish.PlayerCatchFish[i] = true;
            }
        }
    }



    void Update()
    {
        if (!StopFishing)
        {
            if (!EventFishing)
                SpeedFish(GameManager.Player.PlayerRod);
            else
                StartCoroutine("EventCoroutine");
        }


        if (CatchFish)
        {
            GameManager.Player.Gold += fish.FishGold;
            RenewCatchBook(fish);
            AudioManager.Instance.PlayEFSound("Fishing");

            Fish_Ui.FishUICatchFish = true; // 물고기 잡힘
            TimeChange_Ui.TimeBool = true;
            Quest_Update.CatchQuestFish = true;

            CatchFish = false;
        }
    }
}
