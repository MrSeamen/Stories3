using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryDialog : MonoBehaviour {
    public int clicked = 0;
    public bool isClicked = false;
    public float distanceApart = 80.0f;
    private Dictionary<Sprite, Image> displayedKeys = new Dictionary<Sprite, Image>();
    public Image spriteTemplate;

    public Image ShowKey(Sprite key)
    {
        Image keyImage = Instantiate(spriteTemplate.gameObject, transform).GetComponent<Image>();
        keyImage.sprite = key;
        displayedKeys.Add(key, keyImage);
        UpdatePositions();
        return keyImage;
    }

    public void RemoveKey(Sprite key)
    {
        Image image;
        if (displayedKeys.TryGetValue(key, out image))
        {
            Destroy(image.gameObject);
            displayedKeys.Remove(key);
            UpdatePositions();
        }
    }

    private void UpdatePositions()
    {
        if(displayedKeys.Count == 0)
        {
            return;
        }

        float totalStretch = distanceApart * (displayedKeys.Count - 1);
        float startPos = 0 - (totalStretch / 2);
        int idx = 0;
        foreach (Image image in displayedKeys.Values)
        {
            float pos = startPos + (distanceApart * idx);
            image.gameObject.transform.localPosition = new Vector3(pos, 0, 0);
            idx++;
        }
    }

    public void HideInventory(InputAction.CallbackContext context)
    {
        isClicked = true;
        if(isClicked == true)
        {
            transform.Translate(Vector3.right * ((clicked%2==0)?10000:-10000));
            isClicked = !isClicked;
            clicked++;
        }
    }
}
