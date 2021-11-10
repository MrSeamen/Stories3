using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public Transform player;
    private Collider col;
    private bool isHitting = false;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

       

        if (Physics.Raycast(player.transform.position, player.transform.TransformDirection(Vector3.up), out hit, 2))
        {
            Debug.Log("Ray Hit OverHead");
           // Debug.DrawRay(player.transform.position, player.transform.TransformDirection(Vector3.up)*2, Color.green);
            if (hit.collider.GetComponent<MovingPlatforms>() != null)
            {
                isHitting = true;
                col = hit.collider;
                Physics.IgnoreCollision(player.GetComponent<Collider>(), hit.collider, true);
               // hit.collider.enabled = false;
            }

        }
        else if (isHitting)
        {
            if (!(col == null))
            {
                isHitting = false;
               // col.enabled = true;
                Physics.IgnoreCollision(player.GetComponent<Collider>(), col, false);
            }
        }

    }
}
