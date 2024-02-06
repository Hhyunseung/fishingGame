using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fish_Ui : MonoBehaviour
{
    public static bool FishUICatchFish;

    public Image _fishUI;
    Sprite[] _spriteRenderer;
    Color color;

    private void Awake()
    {
        _spriteRenderer = ResourceManager.Instance.fishSprite;
        FishUICatchFish = false;
    }

    private void Start()
    {

    }

    /// <summary>
    /// 낚시 성공 시 물고기 이미지 변경
    /// </summary>
    public void ImageFish(string fishImage)
    {
        for (int i = 0; i < _spriteRenderer.Length; i++)
        {
            if (fishImage == _spriteRenderer[i].name)
                _fishUI.sprite = _spriteRenderer[i];
        }
    }

    public void AlphaImage()
    {
        color = _fishUI.color;

        color.a += Time.deltaTime;
        _fishUI.color = color;
        if (color.a >= 1f)
        {
            color.a = 0f;
            _fishUI.color = color;
            _fishUI.sprite = null;
            FishUICatchFish = false;
        }
    }

    void Update()
    {
        if (FishUICatchFish)
        {
            ImageFish(Fish_Fishing.fish.FishImage);
            AlphaImage();
        }
    }
}
