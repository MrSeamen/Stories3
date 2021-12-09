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

    public UIInputWatcher uiInputWatcher;
    public GameObject defaultSelected;
    public GameObject defaultSelectedSettings;
    public GameObject defaultSelectedControls;
    public GameObject defaultSelectedCredits;

    void Start()
    {
        uiInputWatcher.UpdateShouldSelect(defaultSelected);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowMain()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        uiInputWatcher.UpdateShouldSelect(defaultSelected);
    }

    public void ShowSettings()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        uiInputWatcher.UpdateShouldSelect(defaultSelectedSettings);
    }

    public void ShowCredits()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        controlsPanel.SetActive(false);
        creditsPanel.SetActive(true);
        uiInputWatcher.UpdateShouldSelect(defaultSelectedCredits);
    }

    public void ShowControls()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(false);
        controlsPanel.SetActive(true);
        creditsPanel.SetActive(false);
        uiInputWatcher.UpdateShouldSelect(defaultSelectedControls);
    }
}
