using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public int level;
    private static int door = 0;
    [SerializeField] private GameObject level1;
    [SerializeField] private GameObject level2;
    [SerializeField] private GameObject level3;

    private Camera mainCamera;
    private float zoom;
    private bool zoomActivate = false;

    [SerializeField] private GameObject fade;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        level1.SetActive(true);
        level2.SetActive(false);
        level3.SetActive(false);

        mainCamera = GetComponent<Camera>();
        zoom = mainCamera.orthographicSize;

        color = Color.black;
        color.a = 1.0f;
        fade.GetComponent<Renderer>().material.color = color;
        fade.SetActive(true);
    }

    void Update()
    {
        if(zoomActivate)
        {
            zoom -= 0.05f;
            zoom = Mathf.Clamp(zoom, 0.1f, zoom);
            mainCamera.orthographicSize = Mathf.Lerp(mainCamera.orthographicSize, zoom, Time.deltaTime * 10);
            color.a += Time.deltaTime * 3;
            fade.GetComponent<Renderer>().material.color = color;
        }

        if (color.a > 0)
        {
            color.a -= Time.deltaTime;
            fade.GetComponent<Renderer>().material.color = color;
        }
    }

    public void Select1(InputAction.CallbackContext context)
    {
        level = 1;
        level1.SetActive(true);
        level2.SetActive(false);
        level3.SetActive(false);
    }

    public void Select2(InputAction.CallbackContext context)
    {
        level = 2;
        level1.SetActive(false);
        level2.SetActive(true);
        level3.SetActive(false);
    }

    public void Select3(InputAction.CallbackContext context)
    {
        level = 3;
        level1.SetActive(false);
        level2.SetActive(false);
        level3.SetActive(true);
    }

    public void Enter(InputAction.CallbackContext context)
    {
        StartCoroutine(Transition());
    }

    public IEnumerator Transition()
    {
        zoomActivate = true;
        yield return new WaitForSeconds(0.5f);

        if (level == 1)
        {
            SceneManager.LoadScene("Level 1");
        }
        else if (level == 2)
        {
            SceneManager.LoadScene("Oliver");
        }
        else
        {
            SceneManager.LoadScene("Oliver 2");
        }
    }

    public static int getDoor()
    {
        return door;
    }

    public static void setDoor(int num)
    {
        door = num;
    }

}