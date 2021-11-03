using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FakeItems : MonoBehaviour
{
    public GameObject image;
    //public Text text;

    private static bool retrieved = false;
    private static int items = 6;


    void Start()
    {
        image.SetActive(false);
        Debug.Log("");
        //text.text = "";
    }

    void Update()
    {
        if(retrieved)
        {
            image.SetActive(true);
            Debug.Log("x" + items);
            //text.text = "x" + items;
        }
        if(items <= 0)
        {
            Debug.Log("");
            image.SetActive(false);
            //text.text = "";
        }
    }

    public static void setRetrieved()
    {
        retrieved = true;
    }

    public static int getItems()
    {
        return items;
    }

    public static void ItemSwap()
    {
        items -= 1;
    }

}
