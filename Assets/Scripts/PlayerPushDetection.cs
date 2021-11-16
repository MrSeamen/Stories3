using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushDetection : MonoBehaviour
{
    public Transform player;
    private Collider col;
    private bool isHitting = false;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(player.transform.position, player.transform.TransformDirection(Vector3.up) * 4, Color.green);
        if (Physics.Raycast(player.transform.position - Vector3.down, player.transform.TransformDirection(Vector3.up), out hit, 4))
        {
            if (hit.collider.GetComponent<MovingPlatforms>() != null)
            {
                Debug.Log("Bonk");
                isHitting = true;
                col = hit.collider;
                Physics.IgnoreCollision(player.GetComponent<Collider>(), hit.collider, true);
            }

        }
        else if (isHitting)
        {
            if (!(col == null))
            {
                isHitting = false;
                Physics.IgnoreCollision(player.GetComponent<Collider>(), col, false);
            }
        }

    }
}
