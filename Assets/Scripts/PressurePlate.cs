using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    Vector3 starting_pos;
    Vector3 ending_pos;
    Vector3 pos;
    public float speed = 1.0f;
    public bool pressed = false;

    public Transform door;
    Vector3 door_pos;
    Vector3 door_start;
    Vector3 door_end;

    public AudioSource audioSource;
    public AudioClip down;
    public AudioClip up;

    void Start()
    {
        starting_pos = transform.position;
        pos = starting_pos;
        ending_pos = starting_pos - new Vector3(0f, 0.06f, 0f);

        door_start = door.position;
        door_pos = door_start;
        door_end = door_start - new Vector3(0f, 4f, 0f);
    }

    void Update()
    {
        pos = transform.position;
        if ((pressed == false) && (pos.y < starting_pos.y))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            if(!audioSource.isPlaying || audioSource.clip == down)
            {
                audioSource.clip = up;
                audioSource.Play();
            }
        }
        door_pos = door.position;
        if ((pressed == false) && (door_pos.y <= door_start.y))
        {
            door.Translate(Vector3.up * Time.deltaTime * speed);
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        pressed = true;
        if (pos.y >= ending_pos.y)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
            if (!audioSource.isPlaying || audioSource.clip == up)
            {
                audioSource.clip = down;
                audioSource.Play();
            }
        }
        if (door_pos.y >= door_end.y)
        {
            door.Translate(Vector3.down * Time.deltaTime * speed);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        pressed = false;
    }

}
