using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogPanel : MonoBehaviour
{
    [SerializeField] Text textBox;
    [SerializeField] Image image;

    public void UpdateView(Sprite headImg, string text)
    {
        textBox.text = text;
        image.sprite = headImg;
    }

    public bool isActive()
    {
        return gameObject.activeInHierarchy;
    }
}
