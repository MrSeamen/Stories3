using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menu;
    public string uiActionMap = "UI";
    private string lastUsedActionMap = "Player";
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

    public void Menu(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            MenuInner();
        }
    }

    public void MenuInner()
    {
        active = !active;
        menu.SetActive(active);
        try
        {
            GameObject.Find("Player").GetComponent<Move>().LockMovement(active);
            PlayerInput playerInput = FindObjectOfType<PlayerInput>();
            if (active)
            {
                lastUsedActionMap = playerInput.currentActionMap.name;
                playerInput.SwitchCurrentActionMap(uiActionMap);
            } else
            {
                playerInput.SwitchCurrentActionMap(lastUsedActionMap);
            }
        } catch
        {

        }
    }

}
