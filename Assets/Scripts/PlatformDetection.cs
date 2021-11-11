using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDetection : MonoBehaviour
{
    public Transform player;
    public bool isGrounded, check;
    public Move move;

    void Update()
    {
        isGrounded = move.OnGround();

        if (isGrounded != true)
        {
            check = false;
        }

        if (check != true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, .125f);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("MovingPlatform"))
                {
                    player.SetParent(hit.transform);
                }
                else 
                {
                    player.SetParent(null);
                    
                }
                check = true;
            }
        }

  
    }
}
