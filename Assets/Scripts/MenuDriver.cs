using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDriver : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject controlsPanel;
    public GameObject creditsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowMain()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void ShowSettings()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void ShowCredits()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void ShowControls()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        controlsPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }
}
