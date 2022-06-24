using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop_up_dialogue_control : MonoBehaviour
{
    public int[] threshold_checkpoint;
    public GameObject[] pop_up_dialogue;
    public GameObject dialogueBox;
    private bool is_ready = false;
    private int ready_id;
    void Start()
    {
        GameEvents.current.onCheckpoint += OnCheckpoint;
        GameEvents.current.onDialogueEnd += OnDialogueEnd;
    }
    private void OnCheckpoint(int progress)
    {
        for (int i = 0; i < threshold_checkpoint.Length; i ++)
        {
            if (threshold_checkpoint[i] == progress)
            {
                if (dialogueBox.activeSelf == true)
                {
                    is_ready = true;
                    ready_id = i;
                }
                else
                {
                    pop_up_dialogue[i].SetActive(false);
                    pop_up_dialogue[i].SetActive(true);
                }
            } 
            else
            {
                pop_up_dialogue[i].SetActive(false);
            }
        }

    }
    public void OnDialogueEnd()
    {
        if (is_ready)
        {
            Invoke("ActivateDialogue", 0.01f);
        }
    }
    private void ActivateDialogue()
    {
        pop_up_dialogue[ready_id].SetActive(false);
        pop_up_dialogue[ready_id].SetActive(true);
        is_ready = false;
    }
    private void OnDestroy()
    {
        GameEvents.current.onCheckpoint -= OnCheckpoint;
        GameEvents.current.onDialogueEnd -= OnDialogueEnd;
    }
}
