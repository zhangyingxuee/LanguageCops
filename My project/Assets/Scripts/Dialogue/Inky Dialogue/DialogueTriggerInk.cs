using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerInk : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    [SerializeField] private int threshold;


   public void StartDialogue() 
   {
        FindObjectOfType<DialogueManagerInk>().EnterDialogueMode(inkJSON, threshold);
        Debug.Log("I am working.");
        GameEvents.current.StartDialogue();
    }

    public void GettingReady(int id)
    {
        GameEvents.current.GetReady(id);
    }
}
