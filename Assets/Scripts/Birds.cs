using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds : MonoBehaviour
{
    private bool play = false;
    public AudioSource audio;
    private GameObject player;

    void Update()
    {
        if(play && player.GetComponent<Move>().DirectionX() > 0)
        {
            audio.volume += 0.0001f;
        }
        if(play && player.GetComponent<Move>().DirectionX() < 0)
        {
            audio.volume -= 0.0001f;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if(collider.gameObject.GetComponent<Move>().DirectionX() < 0)
            {
                play = false;
                audio.Stop();
            } 
            else
            {
                player = collider.gameObject;
                play = true;
                audio.Play();
            }
        }
    }
}
