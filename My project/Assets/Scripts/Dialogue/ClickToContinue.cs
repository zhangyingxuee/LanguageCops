using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToContinue : MonoBehaviour
{   
    [SerializeField] private GameObject choiceButton0;
    [SerializeField] private GameObject choiceButton1;
    
    private bool dialogueMode;
    private bool ifInk;

    void Start()
    { 
        ifInk = DialogueManagerInk.GetInstance().dialogueIsPlaying;
        dialogueMode = false;
        GameEvents.current.onStartDialogue += CheckDialogueStart;
        GameEvents.current.onDialogueEnd += CheckDialogueEnd;
    }
    // Update is called once per frame
    void Update()
    {   
        ifInk = DialogueManagerInk.GetInstance().dialogueIsPlaying;
        if(dialogueMode)
        { 
            if (ifInk)
            { 
                if (Input.GetMouseButtonDown(0) && choiceButton1.activeSelf == false && choiceButton0.activeSelf == false)
                {
                    //Debug.Log("Continue button for ink is working");
                    FindObjectOfType<DialogueManagerInk>().ContinueStory();
                }

            }

            else
            {   
                
                if (Input.GetMouseButtonDown(0))
                {   
                    //Debug.Log("the click to continue is working");
                    FindObjectOfType<DialogueManager>().DisplayNextSentence();
                }
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
