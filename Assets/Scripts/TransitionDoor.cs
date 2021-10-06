using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Cinemachine;

public class TransitionDoor : MonoBehaviour
{
    private bool trigger = false;

    [SerializeField] private GameObject fade;
    private Color color;
    private bool fadeActivate = false;

    void Start()
    {
        color = Color.black;
        color.a = 0.0f;
        fade.GetComponent<Renderer>().material.color = color;
        fade.SetActive(true);
    }

    void Update()
    {
        if (fadeActivate)
        {
            color.a += Time.deltaTime * 3;
            fade.GetComponent<Renderer>().material.color = color;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            trigger = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            trigger = false;
        }
    }

    public void UseDoor(InputAction.CallbackContext context)
    {
        StartCoroutine(Transition());
    }

    public IEnumerator Transition()
    {
        fadeActivate = true;
        yield return new WaitForSeconds(0.5f);

        if (trigger && gameObject.CompareTag("Door1"))
        {
            LevelSelection.setDoor(1);
            SceneManager.LoadScene("Transition");
        }
        else if (trigger && gameObject.CompareTag("Door2"))
        {
            LevelSelection.setDoor(2);
            SceneManager.LoadScene("Transition");
        }
        else if (trigger && gameObject.CompareTag("Door3"))
        {
            LevelSelection.setDoor(3);
            SceneManager.LoadScene("Transition");
        }
    }

}
