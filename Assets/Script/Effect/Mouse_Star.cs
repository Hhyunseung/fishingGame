using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse_Star : MonoBehaviour
{
    public SpriteRenderer StarSprite;

    float size = 0.3f;
    float sizeSpeed = 1.0f;
    float colorSpeed = 5.0f;

    void Update()
    {
        transform.localScale = new Vector2(size, size);
        transform.localScale = Vector2.Lerp(transform.localScale, Vector2.zero, Time.deltaTime * sizeSpeed);

        Color color = StarSprite.color;
        color.a = Mathf.Lerp(StarSprite.color.a, 0, Time.deltaTime * colorSpeed);
        StarSprite.color = color;

        if (StarSprite.color.a <= 0.01f)
        {
            MouseEffect.Instance.ReturnObjectToPool(gameObject);
            color.a = 1.0f;
            StarSprite.color = color;
        }
    }
}
