using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Wolf : MonoBehaviour
{
    public GameObject wolf;
    public Color shadeColor;
    public GameObject vfx;
    public GameObject hint;

    private bool flip = false;
    private bool set = false;
    private bool e1 = false;
    private float time1 = 0f;
    private bool triggered1 = false;
    private bool e2 = false;
    private float time2 = 0f;
    private bool triggered2 = false;
    private bool e3 = false;
    private float time3 = 0f;
    private bool triggered3 = false;

    private AudioSource audio;
    public AudioClip prep;
    public AudioClip attack;

    void Start()
    {
        wolf.SetActive(false);
        audio = GetComponent<AudioSource>();
        vfx.SetActive(false);
        hint.SetActive(false);
    }

    void Update()
    {
        //Event 1
        if (time1 > 5f)
        {
            flip = false;
            transform.position += new Vector3(Time.deltaTime * 6.0f, 0f, 0f);
            time1 -= Time.deltaTime;
        }
        else if (time1 > 4)
        {
            time1 -= Time.deltaTime;
        }
        else if (time1 > 1 && !set)
        {
            set = true;
            e1 = true;
            time1 -= Time.deltaTime;
        }
        else if (time1 > 1)
        {
            time1 -= Time.deltaTime;
        }
        else if (time1 > 0)
        {
            e1 = false;
            set = false;
            flip = true;
            transform.position -= new Vector3(Time.deltaTime * 6.0f, 0f, 0f);
            time1 -= Time.deltaTime;
            vfx.SetActive(false);
        }

        //Event 2
        if (time2 > 5f)
        {
            flip = true;
            transform.position -= new Vector3(Time.deltaTime * 6.0f, 0f, 0f);
            time2 -= Time.deltaTime;
        }
        else if (time2 > 4)
        {
            time2 -= Time.deltaTime;
        }
        else if (time2 > 1 && !set)
        {
            set = true;
            e2 = true;
            time2 -= Time.deltaTime;
        }
        else if (time2 > 1)
        {
            time2 -= Time.deltaTime;
        }
        else if (time2 > 0)
        {
            e2 = false;
            set = false;
            flip = false;
            transform.position += new Vector3(Time.deltaTime * 6.0f, 0f, 0f);
            time2 -= Time.deltaTime;
            vfx.SetActive(false);
        }

        //Event 3
        if (time3 > 5f)
        {
            flip = false;
            transform.position += new Vector3(Time.deltaTime * 6.0f, 0f, 0f);
            time3 -= Time.deltaTime;
        }
        else if (time3 > 4)
        {
            time3 -= Time.deltaTime;
        }
        else if (time3 > 1 && !set)
        {
            set = true;
            e3 = true;
            time3 -= Time.deltaTime;
        }
        else if (time3 > 1)
        {
            time3 -= Time.deltaTime;
        }
        else if (time3 > 0)
        {
            e3 = false;
            set = false;
            flip = true;
            transform.position -= new Vector3(Time.deltaTime * 6.0f, 0f, 0f);
            time3 -= Time.deltaTime;
            vfx.SetActive(false);
        }

        //Flip
        if (flip)
        {
            wolf.GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            wolf.GetComponent<SpriteRenderer>().flipX = false;
        }

        //Check for Movement
        if(GameObject.Find("Player").GetComponent<Move>().isMoving())
        {
            KillPlayer();
        }

        if(time1 <= 0 && time2 <= 0 && time3 <= 0)
        {
            wolf.SetActive(false);
        }
    }

    public void Wolf1()
    {
        if (!triggered1)
        {
            vfx.SetActive(true);
            set = false;
            triggered1 = true;
            audio.clip = prep;
            audio.Play();
            transform.position = new Vector3(40.75f, 0.81f, 0f);
            wolf.SetActive(true);
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = shadeColor;
            time1 = 6.0f;
        }
    }

    public void Wolf2()
    {
        if (!triggered2)
        {
            vfx.SetActive(true);
            set = false;
            triggered2 = true;
            audio.clip = prep;
            audio.Play();
            transform.position = new Vector3(74.25f, 0.81f, 0f);
            wolf.SetActive(true);
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = shadeColor;
            time2 = 6.0f;
        }
    }

    public void Wolf3()
    {
        if (!triggered3)
        {
            vfx.SetActive(true);
            set = false;
            triggered3 = true;
            audio.clip = prep;
            audio.Play();
            transform.position = new Vector3(60.5f, 0.81f, 0f);
            wolf.SetActive(true);
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = shadeColor;
            time3 = 6.0f;
        }
    }

    public void KillPlayer()
    {
        if(e1 || e2 || e3)
        {
            if (!CameraShift.getScroller())
            {
                GameObject.Find("Main Camera").GetComponent<CameraShift>().ForcedShift();
            }
            e1 = false;
            e2 = false;
            e3 = false;
            audio.Stop();
            audio.clip = attack;
            audio.Play();
            GameObject.Find("Main Camera").GetComponent<FadeOut>().DeathFade();
            GameObject.Find("Forest Audio Activator").GetComponent<ForestSound>().TurnOff();
        }
    }

    public void Goondalf()
    {
        hint.SetActive(true);
    }

    public void WolfReset()
    {
        triggered1 = false;
        triggered2 = false;
        triggered3 = false;
    }
}
