using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// GameManager 의 스크립트 실행을 다른 스크립트보다 일찍 실행시킴
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private static Player _player;
    public static Player Player
    {
        get
        {
            if (_player == null && SceneManager.GetActiveScene().name == "Main")
            {
                GameObject obj = GameObject.FindWithTag("Player");
                _player = obj.GetComponent<Player>();
                if (TrunScene.IsLoad)
                {
                    SaveData.instance.LoadPlayer();
                    SaveData.instance.LoadCatchFish();
                }
                else
                    _player.SetPlayerStat();
            }
            return _player;
        }
    }

    private static Shop _shop;
    public static Shop Shop
    {
        get
        {
            if (_shop == null && SceneManager.GetActiveScene().name == "Main")
            {
                GameObject obj = GameObject.FindWithTag("Shop");
                _shop = obj.GetComponent<Shop>();
                if (TrunScene.IsLoad)
                    SaveData.instance.LoadShop();
                else
                    _shop.SetShop();
            }
            return _shop;
        }
    }

    private static TimeChange _timeChange;
    public static TimeChange TimeChange
    {
        get
        {
            if (_timeChange == null && SceneManager.GetActiveScene().name == "Main")
            {
                GameObject obj = GameObject.FindWithTag("TimeChange");
                _timeChange = obj.GetComponent<TimeChange>();
                if (TrunScene.IsLoad)
                    SaveData.instance.LoadTimeChange();
                else
                    _timeChange.SetTimeChange();
            }
            return _timeChange;
        }
    }

    private static BookFish _bookFish;
    public static BookFish BookFish
    {
        get
        {
            if (_bookFish == null)
            {
                GameObject obj = GameObject.FindWithTag("BookFish");
                _bookFish = obj.GetComponent<BookFish>();
                if (TrunScene.IsLoad)
                    SaveData.instance.LoadTimeChange();
                else
                    _bookFish.SetBookFish();
            }
            return _bookFish;
        }
    }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void ResetSeason()
    {
        _player.SetPlayerStat();
        _shop.SetShop();
    }
}
