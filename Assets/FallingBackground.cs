using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBackground : MonoBehaviour
{
    public float speed = 0.5f;
    public Material sky;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, -(Time.time * speed));

        sky.mainTextureOffset = offset;
    }
}
