using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] private GameObject fade;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        color = Color.black;
        color.a = 0;
    }

    public void Trigger(string nextScene)
    {
        StartCoroutine(FadeOutRoutine(nextScene));
    }

    IEnumerator FadeOutRoutine(string nextScene)
    {
        fade.SetActive(true);
        while (color.a < 1)
        {
            color.a += Time.deltaTime / time;
            fade.GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadScene(nextScene);
    }
}
