using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPinocchio : MonoBehaviour
{
    public Animator playerAnimator;
    public bool hasPinocchio;

    // Start is called before the first frame update
    void Start()
    {
        SetAnim(hasPinocchio);
    }

    public void SetAnim(bool hasPinocchio_in)
    {
        hasPinocchio = hasPinocchio_in;
        playerAnimator.SetBool("HasPinocchio", hasPinocchio);
    }
}
