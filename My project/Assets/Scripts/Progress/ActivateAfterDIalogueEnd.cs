using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateAfterDIalogueEnd : MonoBehaviour
{  
    public int activate;

    private bool ready_to_activate = false;
    void Start()
    {
        GameEvents.current.onCheckpoint += OnCheckpoint;
         GameEvents.current.onDialogueEnd += OnDialogueEnd;
    }
    private void OnCheckpoint(int progress)
    {
         if (progress == activate)
        {
            ready_to_activate = true;
            Debug.Log("Getting ready");
        } 

    }

        public void OnDialogueEnd()
    {
        if (ready_to_activate)
        {
            Invoke("Activating", 0.2f);
        }
    }

    private void Activating()
    {
        gameObject.GetComponent<Button>().interactable = true;
        Debug.Log("Activating");
        ready_to_activate = false;
    }
   
    private void OnDestroy()
    {
        GameEvents.current.onCheckpoint -= OnCheckpoint;
         GameEvents.current.onDialogueEnd -= OnDialogueEnd;
    }
}
