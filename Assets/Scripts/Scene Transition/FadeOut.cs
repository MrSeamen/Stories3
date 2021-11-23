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

    public void DeathFade()
    {
        StartCoroutine(DeathFadeOut());
    }

    IEnumerator DeathFadeOut()
    {
        fade.SetActive(true);
        while (color.a < 1)
        {
            color.a += Time.deltaTime / (time/2);
            fade.GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(DeathFadeIn());
    }

    IEnumerator DeathFadeIn()
    {
        GameObject.Find("Player").GetComponent<Move>().WolfAttack();
        yield return new WaitForSeconds(1.0f);
        while (color.a > 0)
        {
            color.a -= Time.deltaTime / time;
            fade.GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForEndOfFrame();
        }
        fade.SetActive(false);
    }
}
