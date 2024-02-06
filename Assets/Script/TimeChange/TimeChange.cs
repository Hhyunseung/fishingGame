using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeChange : MonoBehaviour
{
    public enum Seasons
    {
        Spring,
        Summer,
        Falling,
        Winter
    }

    public int Year { get { return _year; } set { _year = value; } }
    public bool Hour { get { return _hour; } set { _hour = value; } }

    public Seasons Season
    {
        get { return _season; }
        set
        {
            _season = value;

            // 겨울에서 계절 변환 시 
            if ((int)_season == 4)
            {
                _season = Seasons.Spring;
                _year++;
            }
        }
    }

    public int FishCount
    {
        get { return _fishCount; }
        set
        {
            _fishCount = value;

            // 150 마리 잡으면 시간 변경
            if (_fishCount == 150)
            {
                Hour = !Hour;
                //_fishCount = 0;
            }
        }
    }

    private int _year; // 현재 년도
    private bool _hour; // 현재 시간 (true 아침 false 저녁)
    private Seasons _season; // 현재 계절
    private int _fishCount; // 잡은 물고기 수 // 시간 변경에 사용

    // TimeChange 변수들 초기화
    public void SetTimeChange()
    {
        _year = 1;
        _hour = true;
        _season = Seasons.Spring;
        _fishCount = 0;
    }
}
