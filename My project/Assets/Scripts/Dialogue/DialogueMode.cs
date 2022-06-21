using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMode : MonoBehaviour
{
    private bool curr_state;
    void Start()
    {
        GameEvents.current.onStartDialogue += OnStartDialogue;
        GameEvents.current.onDialogueEnd += OnDialogueEnd;

    }

    private void OnStartDialogue()
    {
        curr_state = GetComponent<Button>().interactable;
        GetComponent<Button>().interactable = false;
       // Debug.Log(state);
    }
    private void OnDialogueEnd()
    {
        GetComponent<Button>().interactable = curr_state;
    }

    private void OnDestroy()
    {
        GameEvents.current.onStartDialogue -= OnStartDialogue;
        GameEvents.current.onDialogueEnd -= OnDialogueEnd;
    }
    
}
