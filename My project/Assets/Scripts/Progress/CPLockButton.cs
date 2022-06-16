using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPLockButton : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.onCheckpoint += OnCheckpoint;
    }

    public int NotesUnlock;
    public int SolvingUnlock;
    public Button Notes;
    public Button Solvings;

    private void OnCheckpoint(int progress)
    {
        if(progress == NotesUnlock)
        {
            Notes.interactable = true;
        }
        if (progress == SolvingUnlock)
        {
            Solvings.interactable = true;
            Debug.Log("Solution activated");
        }
        Debug.Log("Button state checked");
    }

}
