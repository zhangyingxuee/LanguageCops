using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDIalogueWhenActive : MonoBehaviour
{
    public Texture heads;
    public RawImage profilePic;
    public Dialogue dialogue;

    public SaveDataSO InfoSO;
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
            InfoSO.Progress = progress_update;
            GameEvents.current.Checkpoint(progress_update);
            if (AddItemAfterFinish)
            {
                GameEvents.current.AddingItem(items_id);
            }
            is_ready = false;
        } 

    }

    private void OnDisable()
    { 
        is_ready = false;
    }

    private void OnDestroy()
    {
        GameEvents.current.onDialogueEnd -= OnDialogueEnd;
    }
}
