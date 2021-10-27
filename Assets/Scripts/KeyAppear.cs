using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAppear : MonoBehaviour
{
    //public GameObject suitor;
    private DialogueTrigger trig;
    public GameObject key;
    // Start is called before the first frame update
    void Start()
    {
        trig = this.GetComponent<DialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (trig.triggered)
        {
            key.SetActive(true);
        }
    }
}
