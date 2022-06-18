using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCheckpoint : MonoBehaviour
{
    public GameObject textbox;
    public void UpdateProgress(int checkpt)
    {
        GameEvents.current.Checkpoint(checkpt);
        Debug.Log(checkpt);
    }

    public void PostDialogueUpdate( int checkpt)
    {
        while(textbox.activeSelf == true)
        {
            //wait
        }
        GameEvents.current.Checkpoint(checkpt);
    }
}
