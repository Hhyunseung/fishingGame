using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookFish : MonoBehaviour
{
    private static BookFish s_Instance;
    
    [HideInInspector]
    public bool[] PlayerCatchFish; // 잡은 물고기들

    public void SetBookFish()
    {
        PlayerCatchFish = new bool[TableFish.DataList.Count];

        for (int i = 0; i < TableFish.DataList.Count; i++)
        {
            PlayerCatchFish[i] = false;
        }
    }

    private void Awake()
    {
        if (s_Instance)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        s_Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
}
