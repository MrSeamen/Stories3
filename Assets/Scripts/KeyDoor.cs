using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;
    private AudioSource door;

    void Start()
    {
        door = GetComponent<AudioSource>();
    }

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        door.Play();
        StartCoroutine(OpenDoor2());
    }

    public IEnumerator OpenDoor2()
    {
        yield return new WaitForSeconds(0.25f);
        gameObject.SetActive(false);
    }


}
