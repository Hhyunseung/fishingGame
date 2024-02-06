using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : PlayerBase
{
    /// <summary> Ω∫≈» √ ±‚»≠ </summary>
    public void SetPlayerStat()
    {
        PlayerRod = TableRod.DataList[0].rodId;
        PlayerBobber = TableBobber.DataList[0].randomId;
        PlayerBait = TableBait.DataList[0].baitId;

        Gold = 9999999;
    }
}
