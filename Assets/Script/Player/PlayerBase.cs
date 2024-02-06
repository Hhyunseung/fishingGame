using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private int _playerRod; // ���� �ӵ� (���� ���� ���˴�)
    private int _playerBobber; // ���� Ȯ�� (���� ���� ��)
    private int _playerBait; // ���� ����� (���� ���� �̳�)

    private int _gold; // ������ ���
    const int _maxGold = 9999999;
    
    public int PlayerRod
    {
        get { return _playerRod; }
        set { _playerRod = value; }
    }

    public int PlayerBobber
    {
        get { return _playerBobber; }
        set { _playerBobber = value; }
    }

    public int PlayerBait
    {
        get { return _playerBait; }
        set { _playerBait = value; }
    }

    public int Gold
    {
        get { return _gold; }
        set
        {
            _gold = value;

            // maxGold�� ���� ���ϰ� ��ȯ
            if (_gold > _maxGold)
            {
                _gold = _maxGold;
            }
            else
            {
                _gold = value;
            }
        }
    }
}
