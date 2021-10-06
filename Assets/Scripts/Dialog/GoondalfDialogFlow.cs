using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoondalfDialogFlow : DialogBase
{
    [SerializeField] int currentPrompt = 0;
    [SerializeField] float dialogSpeed = 5.0f;
    [SerializeField] List<string> dialogSetOne;
    [SerializeField] List<string> dialogSetTwo;
    Coroutine activeRoutine = null;
    public void NextDialog()
    {
        if(currentPrompt < dialogLines.Count)
        {
            dialogPanel.UpdateView(headImg, dialogLines[currentPrompt]);
            currentPrompt++;
        }
    }

    private void Start()
    {
        dialogLines = dialogSetOne;
    }

    public void switchDialogSet()
    {
        currentPrompt = 0;
        dialogLines = dialogSetTwo;
    }

    IEnumerator showNextDialog()
    {
        while(currentPrompt < dialogLines.Count)
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
            if(activeRoutine != null)
            {
                StopCoroutine(activeRoutine);
            }
        }
    }
}
