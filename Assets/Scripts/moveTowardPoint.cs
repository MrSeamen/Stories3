using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowardPoint : MonoBehaviour
{
    public GameObject gameObject;
    public Vector3 destination;
    private Vector3 direction;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        direction = destination - gameObject.transform.position;
        if (gameObject.transform.position != destination)
        {

            gameObject.transform.position += direction * Time.deltaTime * speed;
        }
    }
}
