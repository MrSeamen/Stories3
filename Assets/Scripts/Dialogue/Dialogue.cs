using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public Sprite headImg;
    public string name;

    [TextArea(3,5)]
    public string[] sentences;
}
