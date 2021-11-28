using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintToggle : MonoBehaviour
{
    public GameObject hint;

    // Start is called before the first frame update
    void Start()
    {
        hint.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<PressurePlate>().pressed)
        {
            hint.SetActive(false);
        } else
        {
            hint.SetActive(true);
        }
    }
}
