using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDIalogueWhenActive : MonoBehaviour
{
    public Texture heads;
    public RawImage profilePic;
    public Dialogue dialogue;
    public int progress_update;
    public bool AddItemAfterFinish;
    public int items_id;
    private bool is_ready = false;
    void Start()
    {
        GameEvents.current.onDialogueEnd += OnDialogueEnd;
    }
    private void OnEnable()
    {
        TriggerDialogue();
        profilePic.texture = heads;
        is_ready = true;
        //Debug.Log("Now a pop-up appears");
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        GameEvents.current.StartDialogue();
    }
    public void OnDialogueEnd()
    {
        if (is_ready)
        {
            GameEvents.current.Checkpoint(progress_update);
            is_ready = false;
        } 
        if (AddItemAfterFinish)
        {
            GameEvents.current.AddingItem(items_id);
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.onDialogueEnd -= OnDialogueEnd;
    }
}
