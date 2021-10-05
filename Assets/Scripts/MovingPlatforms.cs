using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public Transform transformY;
    
    [SerializeField] private float lengthPerSecond = 1f;
    [SerializeField] private float destinationY = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transformY.position = new Vector3(transformY.position.x, Mathf.PingPong(Time.time * lengthPerSecond, destinationY), transformY.position.z);
    }
}
