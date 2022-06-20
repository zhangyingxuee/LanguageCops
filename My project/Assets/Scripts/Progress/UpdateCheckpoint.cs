using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCheckpoint : MonoBehaviour
{

    private bool is_ready = false;
    public int ready_id;
    void Start()
    {
        GameEvents.current.onGetReady += OnGetReady;
        GameEvents.current.onDialogueEnd += OnDialogueEnd;
    }

    public void UpdateProgress(int checkpt)
    {
        GameEvents.current.Checkpoint(checkpt);
        Debug.Log(checkpt);
    }

    public void OnDialogueEnd()
    {
        if (is_ready) 
        {
            GameEvents.current.Checkpoint(ready_id);
        }
        
    }

    private void OnGetReady(int id)
    {
        if ( id == ready_id)
        {
            is_ready = true;
        } else
        {
            is_ready = false;
        }
    }
}
