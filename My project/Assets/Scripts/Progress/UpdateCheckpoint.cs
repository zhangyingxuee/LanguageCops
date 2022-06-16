using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCheckpoint : MonoBehaviour
{

    public void UpdateProgress(int checkpt)
    {
        GameEvents.current.Checkpoint(checkpt);
        Debug.Log(checkpt);
    }
}
