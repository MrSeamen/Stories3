using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FadeIn : MonoBehaviour
{
    [SerializeField] float time = 1.0f;
    [SerializeField] private GameObject fade;
    private Color color;

    [SerializeField] private CinemachineVirtualCamera cam;
    private float correctZoom;
    private float zoom;

    // Start is called before the first frame update
    void Start()
    {
        color = Color.black;
        color.a = 1.0f;
        fade.GetComponent<SpriteRenderer>().color = color;
        fade.SetActive(true);

        correctZoom = 10;
        zoom = correctZoom + 10;
        if(cam)
        {
            cam.m_Lens.OrthographicSize = zoom;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(color.a > 0)
        {
            color.a -= Time.deltaTime / time;
            fade.GetComponent<SpriteRenderer>().color = color;
        }
        
        if(cam)
        {
            zoom -= 0.15f;
            zoom = Mathf.Clamp(zoom, correctZoom, zoom);
            cam.m_Lens.OrthographicSize = Mathf.Lerp(cam.m_Lens.OrthographicSize, zoom, Time.deltaTime * 10);
        }

    }
}
