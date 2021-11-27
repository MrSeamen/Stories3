using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWakeUp : MonoBehaviour
{
    public GameObject defaultSelected;
    public UIInputWatcher uiInputWatcher;

    void OnEnable()
    {
        uiInputWatcher.UpdateShouldSelect(defaultSelected);
    }
}