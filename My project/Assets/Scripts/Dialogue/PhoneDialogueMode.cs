using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneDialogueMode : MonoBehaviour
{
    private bool state = false;

    void Start()
    {
        GameEvents.current.onStartDialogue += OnStartDialogue;
        GameEvents.current.onDialogueEnd += OnDialogueEnd;
        GameEvents.current.onCloseCafe += OnCloseCafe;

    }

    private void OnStartDialogue()
    {
        GetComponent<Button>().interactable = false;
       // Debug.Log(state);
    }
    private void OnDialogueEnd()
    {
        GetComponent<Button>().interactable = true;
    }
        private void OnCloseCafe()
    {
        GetComponent<Button>().interactable = state;
        //Debug.Log(state);
        state = !state;
    }

    private void OnDestroy()
    {
        GameEvents.current.onStartDialogue -= OnStartDialogue;
        GameEvents.current.onDialogueEnd -= OnDialogueEnd;
        GameEvents.current.onCloseCafe -= OnCloseCafe;
    }
}
