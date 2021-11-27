using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PressurePlate : MonoBehaviour
{
    Vector3 starting_pos;
    Vector3 ending_pos;
    Vector3 pos;
    public float speed = 1.0f;
    public bool pressed;

    public Transform door;
    private GameObject doorObj;
    Vector3 door_pos;
    Vector3 door_start;
    Vector3 door_end;

    public AudioSource audioSource;
    public AudioClip down;
    public AudioClip up;

    public AudioSource doorAudio;
    private Light2D doorLight;

    void Start()
    {
        doorLight = door.Find("Point Light 2D").GetComponent<Light2D>();
        doorLight.enabled = true;
        this.starting_pos = transform.position;
        this.pos = starting_pos;
        this.ending_pos = starting_pos - new Vector3(0f, 0.06f, 0f);

        this.door_start = door.position;
        this.door_pos = door_start;
        this.door_end = door_start - new Vector3(0f, 3.5f, 0f);
        this.pressed = false;
    }

    void Update()
    {
        if (this.pressed == false)
            doorLight.enabled = true;
        else
            doorLight.enabled = false;

        this.pos = transform.position;
        if ((this.pressed == false) && (this.pos.y < this.starting_pos.y))
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
            if(!audioSource.isPlaying || audioSource.clip == down)
            {
                audioSource.clip = up;
                audioSource.Play();
            }
        }
        this.door_pos = door.position;
        if ((this.pressed == false) && (this.door_pos.y <= this.door_start.y))
        {
            this.door.Translate(Vector3.up * Time.deltaTime * speed);
            if(!this.doorAudio.isPlaying)
            {
                this.doorAudio.Play();
            }
        } else if(this.pressed == false)
        {
            this.doorAudio.Stop();
        }

    }

    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "Rock")
        {
            this.pressed = true;
            if (this.pos.y >= this.ending_pos.y)
            {
                transform.Translate(Vector3.down * Time.deltaTime * speed);
                if (!audioSource.isPlaying || audioSource.clip == up)
                {
                    audioSource.clip = down;
                    audioSource.Play();
                }
            }
            if (this.door_pos.y >= this.door_end.y)
            {
                this.door.Translate(Vector3.down * Time.deltaTime * speed);
                if (!this.doorAudio.isPlaying)
                {
                    this.doorAudio.Play();
                }
            }  else
            {
                this.doorAudio.Stop();
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        pressed = false;
    }

}
