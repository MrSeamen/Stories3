using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RealItems : MonoBehaviour
{
    public GameObject image;
    public Text text;

    private static int items = 0;


    void Start()
    {
        image.SetActive(false);
        text.text = "";
    }

    void Update()
    {
        if (items > 0)
        {
            image.SetActive(true);
            text.text = "x" + items;
        }
        if (items <= 0)
        {
            image.SetActive(false);
            text.text = "";
        }
    }

    public static void ItemSwap()
    {
        items += 1;
    }

    public static void GiveToKaguya()
    {
        if(items == 6)
        {
            items = 0;
            Debug.Log("All 6 items were given to Kaguya. Good job!");
        } else
        {
            Debug.Log("All 6 items are needed");
        }
    }
}
