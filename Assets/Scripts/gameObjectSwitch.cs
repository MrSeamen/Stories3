using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 
    gameObjectSwitch : MonoBehaviour
{
    public GameObject gameObject;

    public void disableGameObject()
    {
        gameObject.SetActive(false);
    }

    public void enableGameObject()
    {
        gameObject.SetActive(true);
    }

    public void disableGameObjectChildren()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void enableGameObjectChildren()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
