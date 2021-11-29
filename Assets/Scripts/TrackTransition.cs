using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackTransition : MonoBehaviour
{
    public GameObject player;
    public int startTrackIdx = 1;
    public Track[] tracks;
    public Text trackIndicator;
    public bool continouslyTrackBlocks;

    private int currentTrackIdx = 0;

    private bool moving;
    private bool disabled = false;

    void Start()
    {
        currentTrackIdx = startTrackIdx;
        foreach (Track track in tracks)
        {
            track.AddShade();
        }
        tracks[currentTrackIdx].RemoveShade();
        trackIndicator.text = "Track " + (currentTrackIdx + 1) + "/" + tracks.Length;
        player.GetComponentInChildren<SpriteRenderer>().sortingOrder = tracks[currentTrackIdx].startLayer + 1;
    }

    public bool IsTransitioning()
    {
        return moving;
    }

    public void Disable(bool dis)
    {
        disabled = dis;
    }

    public void ContinouslyTrackBlocks(bool dis)
    {
        continouslyTrackBlocks = dis;
    }

    public void AttemptTransition(bool isAwayFromCamera, Animator animator, AudioSource audioSource, AudioClip walkingClip)
    {
        if(!disabled)
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



            if (CheckBlocked(tracks[nextIdx].transform.position.z, isAwayFromCamera))
            {
                TransitionBlocked();
            }
            else
            {
                if (!moving)
                {
                    StartCoroutine(MoveToPosition(player.transform, tracks[nextIdx].transform.position.z, 1.0f, animator, audioSource, walkingClip, tracks[currentTrackIdx], tracks[nextIdx], isAwayFromCamera, nextIdx));
                }
            }
        }
    }

    private bool CheckBlocked(float z, bool isAwayFromCamera, float modifier = 1)
    {
        float distance = Mathf.Abs(z - tracks[currentTrackIdx].transform.position.z);
        bool blocked = Physics.Raycast(player.transform.position, player.transform.TransformDirection(isAwayFromCamera ? Vector3.forward : Vector3.back), distance * modifier, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore);
        bool floorExists = Physics.Raycast(player.transform.position, player.transform.TransformDirection(isAwayFromCamera ? new Vector3(0, -1, 1) : new Vector3(0, -1, -1)), distance, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore);

        return (blocked || !floorExists);
    }

    private void TransitionBlocked()
    {
        Debug.Log("Transition is blocked");
    }

    public IEnumerator MoveToPosition(Transform transform, float z, float timeToMove, Animator animator, AudioSource audioSource, AudioClip walkingClip, Track currentTrack, Track nextTrack, bool isAwayFromCamera, int nextIdx)
    {
        audioSource.loop = true;
        audioSource.clip = walkingClip;
        audioSource.Play();

        animator.SetBool("IsWalking", true);
        moving = true;
        var currentPos = transform.position;
        var startPos = transform.position;
        var targetPos = currentPos;
        targetPos.z = z;
        var t = 0f;
        var endTVal = 1;
        float distanceModifier = 1;
        bool goingBack = false;
        while (t < endTVal)
        {
            currentPos.y = transform.position.y;
            targetPos.y = transform.position.y;
            if (continouslyTrackBlocks && CheckBlocked(z, isAwayFromCamera, distanceModifier))
            {
                goingBack = !goingBack;
            }
            if(goingBack)
            {
                if(endTVal == 1)
                {
                    t = -t;
                    endTVal = 0;
                    isAwayFromCamera = !isAwayFromCamera;
                    goingBack = true;
                }
                transform.position = Vector3.Lerp(targetPos, currentPos, 1 + t);
                nextTrack.LerpRemoveShade(1 + t);
                currentTrack.LerpAddShade(1 + t);
                t += Time.deltaTime / timeToMove;
                distanceModifier = 1 - (1 + t);
            } else
            {
                if (endTVal == 0)
                {
                    t = -t;
                    endTVal = 1;
                    isAwayFromCamera = !isAwayFromCamera;
                }
                transform.position = Vector3.Lerp(currentPos, targetPos, t);
                currentTrack.LerpRemoveShade(t);
                nextTrack.LerpAddShade(t);
                t += Time.deltaTime / timeToMove;
                distanceModifier = 1 - t;
            }
            if (distanceModifier < 0.01)
            {
                distanceModifier = 0.01f;
            }
            yield return new WaitForEndOfFrame();
        }
        if (GameObject.Find("Player").GetComponent<Move>().DirectionX() == 0) 
        {
            animator.SetBool("IsWalking", false);
        }
        moving = false;

        if(endTVal == 1)
        {
            currentTrackIdx = nextIdx;
            trackIndicator.text = "Track " + (currentTrackIdx + 1) + "/" + tracks.Length;
            player.GetComponentInChildren<SpriteRenderer>().sortingOrder = tracks[currentTrackIdx].startLayer + 1;

            currentTrack.AddShade();
            nextTrack.RemoveShade();
            transform.position = targetPos;
        } else
        {
            currentTrack.RemoveShade();
            nextTrack.AddShade();
            transform.position = startPos;
        }

        audioSource.Stop();
    }
}
