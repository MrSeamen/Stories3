using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudFall : MonoBehaviour
{
    public float speed = 0.5f;
  //  public GameObject sky;

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, -(Time.time * speed));

        this.transform.position = offset;
    }
}
