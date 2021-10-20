using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTransition : MonoBehaviour
{
    public GameObject player;
    public int startTrackIdx = 1;
    public GameObject[] tracks;

    private int currentTrackIdx = 0;
    private bool moving = false;

    void Start()
    {
        currentTrackIdx = startTrackIdx;
    }

    public bool IsTransitioning()
    {
        return moving;
    }

    public void AttemptTransition(bool isAwayFromCamera, Animator animator)
    {
        int nextIdx = (isAwayFromCamera ? currentTrackIdx + 1 : currentTrackIdx - 1);
        if (tracks.Length <= nextIdx || nextIdx < 0)
        {
            // Can't go to a track that does not exist
            TransitionBlocked();
            return;
        }

        Debug.DrawRay(player.transform.position, player.transform.TransformDirection(isAwayFromCamera ? Vector3.forward : Vector3.back), Color.green);
        Debug.DrawRay(player.transform.position, player.transform.TransformDirection(isAwayFromCamera ? new Vector3(0, -1, 1) : new Vector3(0, -1, -1)), Color.red);

        float distance = Mathf.Abs(tracks[nextIdx].transform.position.z - tracks[currentTrackIdx].transform.position.z);
        bool blocked = Physics.Raycast(player.transform.position, player.transform.TransformDirection(isAwayFromCamera ? Vector3.forward : Vector3.back), distance);
        bool floorExists = Physics.Raycast(player.transform.position, player.transform.TransformDirection(isAwayFromCamera ? new Vector3(0, -1, 1) : new Vector3(0, -1, -1)), distance);

        if (blocked || !floorExists)
        {
            TransitionBlocked();
        } else
        {
            if(!moving)
            {
                currentTrackIdx = nextIdx;
                StartCoroutine(MoveToPosition(player.transform, tracks[nextIdx].transform.position.z, 1.0f, animator));
            }
        }
    }

    private void TransitionBlocked()
    {
        Debug.Log("Transition is blocked");
    }

    public IEnumerator MoveToPosition(Transform transform, float z, float timeToMove, Animator animator)
    {
        animator.SetBool("IsWalking", true);
        moving = true;
        var currentPos = transform.position;
        var targetPos = currentPos;
        targetPos.z = z;
        var t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / timeToMove;
            transform.position = Vector3.Lerp(currentPos, targetPos, t);
            yield return null;
        }
        transform.position = targetPos;
        moving = false;
        animator.SetBool("IsWalking", false);
    }
}
