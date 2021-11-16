using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapActivate : MonoBehaviour
{
    public GameObject minimap;
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        minimap.SetActive(true);
        active = true;
    }

    // Update is called once per frame
    public void ActivateMap()
    {
        if(active)
        {
            minimap.SetActive(false);
            active = false;
        } else
        {
            minimap.SetActive(true);
            active = true;
        }
    }
}
