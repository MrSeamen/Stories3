using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTowardPoint : MonoBehaviour
{
    public float speed;
    public Vector3 destination = new Vector3(0f, 3f, 0f);
    private Vector3 currentPosition;
    private bool activate = false;

    public void moveTowards()
    {
        //transform.localPosition += destination;
        destination += transform.position;
        activate = true;
    }

    private void Update()
    {
        if (activate)
        {
            float step = speed * Time.deltaTime;
            //transform.position = Vector3.Lerp(currentPosition, destination, Time.deltaTime*speed);
            transform.position = Vector3.MoveTowards(transform.position, destination, step);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.contacts.Length > 0)
        {
            collision.gameObject.transform.parent = transform;
            GameObject.Find("TrackManager").GetComponent<TrackTransition>().Disable(true);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
            GameObject.Find("TrackManager").GetComponent<TrackTransition>().Disable(false);
        }
    }
}
