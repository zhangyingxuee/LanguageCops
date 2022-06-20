using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMode : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onStartDialogue += OnStartDialogue;
        GameEvents.current.onDialogueEnd += OnDialogueEnd;
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

    private void OnDestroy()
    {
        GameEvents.current.onStartDialogue -= OnStartDialogue;
        GameEvents.current.onDialogueEnd -= OnDialogueEnd;
    }
    
}
