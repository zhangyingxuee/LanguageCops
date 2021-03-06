using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    // Using the class we created in the Dialogue script
    public Dialogue dialogue;
    public void TriggerDialogue() 
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        GameEvents.current.StartDialogue();
    }

    public void GettingReady(int id)
    {
        GameEvents.current.GetReady(id);
    }

}
