using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerInk : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
   public void StartDialogue() 
   {
        FindObjectOfType<DialogueManagerInk>().EnterDialogueMode(inkJSON);
   }
}
