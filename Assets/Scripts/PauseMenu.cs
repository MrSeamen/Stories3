using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    private bool active;

    void Start()
    {
        active = false;
    }

    public void LoadMenu(){
        SceneManager.LoadScene("TitleScreen");
    }

    public void Menu()
    {
        active = !active;
        menu.SetActive(active);
        GameObject.Find("Player").GetComponent<Move>().LockMovement(active);
    }

}
