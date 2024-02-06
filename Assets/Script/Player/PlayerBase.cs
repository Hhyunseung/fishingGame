using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private int _playerRod; // ³¬´Â ¼Óµµ (Âø¿ë ÁßÀÎ ³¬½Ë´ë)
    private int _playerBobber; // ³¬´Â È®·ü (Âø¿ë ÁßÀÎ Âî)
    private int _playerBait; // º¸½º ¹°°í±â (Âø¿ë ÁßÀÎ ¹Ì³¢)

    private int _gold; // ¼ÒÁöÇÑ °ñµå
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

            // maxGold¸¦ ³ÑÁö ¸øÇÏ°Ô ¹ÝÈ¯
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
