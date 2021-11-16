using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoondalfEvents : MonoBehaviour
{
    public GameObject goondalf;
    private float time;
    private float time2;
    private float time3;
    private float time4;
    private bool e1 = false;
    private bool e2 = false;
    private bool e3 = false;
    private bool e4 = false;
    public Color shadeColor;

    void Start()
    {
        goondalf.SetActive(false);
    }

    void Update()
    {
        //Event 1
        if(e1 && time > 0)
        {
            goondalf.transform.position += new Vector3(0f, Time.deltaTime * 1.0f, 0f);
            time -= Time.deltaTime;
        } else if (!e1 && time > 0)
        {
            goondalf.transform.position -= new Vector3(0f, Time.deltaTime * 1.0f, 0f);
            time -= Time.deltaTime;
        }

        //Event 2
        if (e2 && time2 > 0)
        {
            goondalf.transform.position += new Vector3(Time.deltaTime * 0.5f, Time.deltaTime * 0.5f, 0f);
            time2 -= Time.deltaTime;
        }
        else if (!e2 && time2 > 0)
        {
            goondalf.transform.position -= new Vector3(Time.deltaTime * 0.5f, Time.deltaTime * 0.5f, 0f);
            time2 -= Time.deltaTime;
        }

        //Event 3
        if (e3 && time3 > 0)
        {
            goondalf.transform.position += new Vector3(0f, Time.deltaTime * 0.75f, 0f);
            time3 -= Time.deltaTime;
        }
        else if (!e3 && time3 > 0)
        {
            goondalf.transform.position -= new Vector3(0f, Time.deltaTime * 0.75f, 0f);
            time3 -= Time.deltaTime;
        }

        //Event 4
        if (e4 && time4 > 0)
        {
            goondalf.transform.position += new Vector3(0f, Time.deltaTime * 0.75f, 0f);
            time4 -= Time.deltaTime;
        }
        else if (!e4 && time4 > 0)
        {
            goondalf.transform.position -= new Vector3(0f, Time.deltaTime * 0.75f, 0f);
            time4 -= Time.deltaTime;
        }

        //Turn off Goondalf
        if (!e1 && !e2 && !e3 && !e4 && time <= 0 && time2 <= 0 && time3 <= 0 && time4 <= 0)
        {
            goondalf.SetActive(false);
        }

    }

    public void Event1()
    {
        if (e1)
        {
            e1 = false;
            time = 1.0f;
        } else
        {
            goondalf.SetActive(true);
            e1 = true;
            goondalf.transform.position = new Vector3(-23.463f, 1.13f, 0f);
            goondalf.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            time = 1.0f;
            goondalf.transform.GetChild(0).GetComponent<SpriteRenderer>().color = shadeColor;
        }

    }

    public void Event2()
    {
        if (e2)
        {
            e2 = false;
            time2 = 1.0f;
        }
        else
        {
            goondalf.SetActive(true);
            e2 = true;
            goondalf.transform.position = new Vector3(1.3f, -0.154f, 0f);
            goondalf.transform.rotation = Quaternion.Euler(0f, 0f, -45f);
            time2 = 1.0f;
            goondalf.transform.GetChild(0).GetComponent<SpriteRenderer>().color = shadeColor;
        }

    }

    public void Event3()
    {
        if (e3)
        {
            e3 = false;
            time3 = 1.0f;
        }
        else
        {
            goondalf.SetActive(true);
            e3 = true;
            goondalf.transform.position = new Vector3(54.72f, -0.59f, 0f);
            goondalf.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            time3 = 1.0f;
            goondalf.transform.GetChild(0).GetComponent<SpriteRenderer>().color = shadeColor;
        }

    }

    public void Event4()
    {
        if (e4)
        {
            e4 = false;
            time4 = 1.0f;
        }
        else
        {
            goondalf.SetActive(true);
            e4 = true;
            goondalf.transform.position = new Vector3(87.362f, 0.433f, 0f);
            goondalf.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            time4 = 1.0f;
            goondalf.transform.GetChild(0).GetComponent<SpriteRenderer>().color = shadeColor;
        }

    }
}
