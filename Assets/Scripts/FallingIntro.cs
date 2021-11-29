using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingIntro: MonoBehaviour
{
    public float speed = 0.5f;
    public Material sky;
    public bool isVertical;

    void Update()
    {
        if (isVertical)
        {
            Vector2 offset = new Vector2(0, -(Time.time * speed));

            sky.mainTextureOffset = offset;
        }
        else
        {
            Vector2 offset = new Vector2((Time.time * speed), 0);

            sky.mainTextureOffset = offset;
        }
    }
}
