using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToContinueTutorial : MonoBehaviour
{
    private bool dialogueMode;

    void Start()
    {
        dialogueMode = false;
        GameEvents.current.onStartDialogue += CheckDialogueStart;
        GameEvents.current.onDialogueEnd += CheckDialogueEnd;
    }

    void Update()
    {
        if (dialogueMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("the click to continue is working");
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
        }

    }
    private void CheckDialogueStart()
    {
        dialogueMode = true;
    }

    private void CheckDialogueEnd()
    {
        dialogueMode = false;
    }


}
