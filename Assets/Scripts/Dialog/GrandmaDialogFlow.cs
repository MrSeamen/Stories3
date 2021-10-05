using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaDialogFlow : DialogBase
{
    [SerializeField] int currentPrompt = 0;
    [SerializeField] float dialogSpeed = 5.0f;
    Coroutine activeRoutine = null;
    public void NextDialog()
    {
        if (currentPrompt < dialogLines.Count)
        {
            dialogPanel.UpdateView(headImg, dialogLines[currentPrompt]);
            currentPrompt++;
        }
    }

    IEnumerator showNextDialog()
    {
        while (currentPrompt < dialogLines.Count)
        {
            yield return new WaitForSeconds(dialogSpeed);
            NextDialog();
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            NextDialog();
            dialogPanel.gameObject.SetActive(true);
            activeRoutine = StartCoroutine(showNextDialog());
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            dialogPanel.gameObject.SetActive(false);
            if (activeRoutine != null)
            {
                StopCoroutine(activeRoutine);
            }
        }
    }
}
