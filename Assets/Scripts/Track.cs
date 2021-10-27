using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track : MonoBehaviour
{
    public Color shadeColor;
    public int startLayer;
    private Dictionary<SpriteRenderer, Color> children;

    private void Awake()
    {
        children = new Dictionary<SpriteRenderer, Color>();
        foreach (SpriteRenderer r in GetComponentsInChildren<SpriteRenderer>())
        {
            children.Add(r, r.color);
        }
    }

    public void AddShade()
    {
        foreach (SpriteRenderer r in children.Keys)
        {
            r.color = shadeColor;
        }
    }

    public void RemoveShade()
    {
        foreach (SpriteRenderer r in children.Keys)
        {
            Color originalColor;
            if (children.TryGetValue(r, out originalColor))
            {
                r.color = originalColor;
            }
        }
    }

    public void LerpAddShade(float t)
    {
        foreach (SpriteRenderer r in children.Keys)
        {
            try
            {
                Color originalColor;
                if (children.TryGetValue(r, out originalColor))
                {
                    r.color = Color.Lerp(shadeColor, originalColor, t);
                }
            }
            catch
            {

            }
        }
    }

    public void LerpRemoveShade(float t)
    {
        foreach (SpriteRenderer r in children.Keys)
        {
            try
            {
                Color originalColor;
                if (children.TryGetValue(r, out originalColor))
                {
                    r.color = Color.Lerp(originalColor, shadeColor, t);
                }
            } catch
            {

            }
        }
    }
}
