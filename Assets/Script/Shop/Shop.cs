using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // ���� ���԰����� ��ǰ id
    public int ShopRod { get { return _shopRod; } set { _shopRod = value; } }
    public int ShopBobber { get { return _shopBobber; } set { _shopBobber = value; } }
    public int ShopBait { get { return _shopBait; } set { _shopBait = value; } }

    private int _shopRod;
    private int _shopBobber;
    private int _shopBait;

    /// <summary> ���� �ʱ�ȭ </summary>
    public void SetShop()
    {
        _shopRod = 50001;
        _shopBobber = 51001;
        _shopBait = 52001;
    }
}
