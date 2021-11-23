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

    public void ReloadScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMenu(){
        KeyHolder[] objs = FindObjectsOfType<KeyHolder>();

        foreach(KeyHolder holder in objs)
        {
            Destroy(holder.gameObject);
        }
        SceneManager.LoadScene("TitleScreen");
    }

    public void LoadLevel1(){
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLevel2(){
        SceneManager.LoadScene("Level 2");
    }

    public void Menu()
    {
        active = !active;
        menu.SetActive(active);
        try
        {
            GameObject.Find("Player").GetComponent<Move>().LockMovement(active);
        } catch
        {

        }
    }

}
