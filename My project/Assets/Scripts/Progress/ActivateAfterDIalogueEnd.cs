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
        } 

    }

        public void OnDialogueEnd()
    {
        if (ready_to_activate)
        {
            GetComponent<Button>().interactable = true;
            ready_to_activate = false;
        }
    }
   
    private void OnDestroy()
    {
        GameEvents.current.onCheckpoint -= OnCheckpoint;
         GameEvents.current.onDialogueEnd -= OnDialogueEnd;
    }
}
