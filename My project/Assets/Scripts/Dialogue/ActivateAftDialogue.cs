using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ActivateAftDialogue : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.onDialogueEnd += OnDialogueEnd;

    }
        private void OnDialogueEnd()
    {
        GetComponent<Button>().interactable = true;
    }

        private void OnDestroy()
    {
        GameEvents.current.onDialogueEnd -= OnDialogueEnd;
    }
}
