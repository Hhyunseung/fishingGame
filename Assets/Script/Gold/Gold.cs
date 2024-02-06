using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gold : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    private void Update()
    {
        goldText.text = GameManager.Player.Gold.ToString();
    }
}
