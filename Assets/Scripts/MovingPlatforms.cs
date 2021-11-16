using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    [SerializeField] private float hitFromBelowDelay = 2.0f;
    [SerializeField] private float speed = 0.5f;
    public Vector3 posDiff = new Vector3(0f, -5f, 0f);
    private Vector3 pos1;
    private Vector3 pos2;
    // Start is called before the first frame update
    void Start()
    {
        pos1 = transform.position;
        pos2 = transform.position + posDiff;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(pos1, pos2, Mathf.PingPong(Time.time * speed, 1.0f));
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.contacts.Length > 0)
        {
            ContactPoint contact = collision.contacts[0];
            Debug.Log(Vector3.Dot(contact.normal, Vector3.down));
            if (Vector3.Dot(contact.normal, Vector3.down) > 0.5)
            {
                collision.gameObject.transform.parent = transform;
            } else if (Vector3.Dot(contact.normal, Vector3.up) > 0.5)
            {
                Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>(), true);
                StartCoroutine(TurnOnCollision(collision.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>()));
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.parent = null;
        }
    }

    IEnumerator TurnOnCollision(Collider collider1, Collider collider2)
    {
        yield return new WaitForSeconds(hitFromBelowDelay);
        Physics.IgnoreCollision(collider1, collider2, false);
    }
}
