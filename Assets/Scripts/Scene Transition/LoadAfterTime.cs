using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadAfterTime : MonoBehaviour
{
    [SerializeField] private float delay = 2f;
    [SerializeField] private string nextScene;
    private float timeElapsed;

    [SerializeField]
    private void Update()
    {
        timeElapsed += Time.deltaTime; 
        if(timeElapsed > delay)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
