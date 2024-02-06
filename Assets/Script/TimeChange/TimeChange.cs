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

            // �ܿ￡�� ���� ��ȯ �� 
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

            // 150 ���� ������ �ð� ����
            if (_fishCount == 150)
            {
                Hour = !Hour;
                //_fishCount = 0;
            }
        }
    }

    private int _year; // ���� �⵵
    private bool _hour; // ���� �ð� (true ��ħ false ����)
    private Seasons _season; // ���� ����
    private int _fishCount; // ���� ����� �� // �ð� ���濡 ���

    // TimeChange ������ �ʱ�ȭ
    public void SetTimeChange()
    {
        _year = 1;
        _hour = true;
        _season = Seasons.Spring;
        _fishCount = 0;
    }
}
