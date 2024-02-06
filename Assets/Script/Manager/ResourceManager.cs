using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;


    [HideInInspector] public Sprite[] fishSprite;
    [HideInInspector] public Sprite[] seasonSprite;

    public Sprite[] shopRodSprite;
    public Sprite[] shopBobberSprite;
    public Sprite[] shopBaitSprite;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

        fishSprite = Resources.LoadAll<Sprite>("Fish");
        seasonSprite = Resources.LoadAll<Sprite>("SeasonsImage");
    }
}
