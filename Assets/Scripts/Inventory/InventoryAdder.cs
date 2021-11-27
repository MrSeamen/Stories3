using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAdder : MonoBehaviour
{
    public void Add(Sprite img)
    {
        InventoryDialog inventoryDialog = GameObject.Find("UI/Inventory").GetComponent<InventoryDialog>();
        inventoryDialog.ShowKey(img);
    }

    public void Remove(Sprite img)
    {
        InventoryDialog inventoryDialog = GameObject.Find("UI/Inventory").GetComponent<InventoryDialog>();
        inventoryDialog.RemoveKey(img);
    }
}
