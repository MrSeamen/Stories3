using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButtons : MonoBehaviour
{
    public string newLevel;
    public string instructions;
    public string credits;
    public string titlescreen;

    private void Start()
    {

        Button btn = GameObject.Find("Button").GetComponent<Button>();
        btn.onClick.AddListener(() => Play());
    }

    public void Play()
    {
        Debug.Log("You have clicked the button!");
        SceneManager.LoadScene("SandboxScene");
    }

    public void Instructions()
    {
        SceneManager.LoadScene(instructions);
    }

    public void Credits()
    {
        SceneManager.LoadScene(credits);
    }
    
    public void Title()
    {
        SceneManager.LoadScene(titlescreen);
    }

    public void Exit()
    {
        Application.Quit();
    }

}