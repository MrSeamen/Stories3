using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //camera 
    [SerializeField] private Camera camera;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(GameObject.Find("Player"));
        SceneManager.LoadScene("TransitionScene");
    }
}
