using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPLockButton : MonoBehaviour
{
    public int SolvingUnlock;
    public int NextSceneUnlock;

    private bool ItemsLocked;
    public Button Notes;
    public Button Solvings;
    public Button NextScene;

    void Start()
    {
        GameEvents.current.onCheckpoint += OnCheckpoint;
        GameEvents.current.onAddingItem += OnAddingItem;
        ItemsLocked = true;
    }


    private void OnCheckpoint(int progress)
    {
        if (progress >= SolvingUnlock)
        {
            Solvings.interactable = true;
            //Debug.Log("Solution activated");
        }
        else
        {
            Solvings.interactable = false;
        }
        if (progress >= NextSceneUnlock)
        {
            NextScene.interactable = true;
        }
        else
        {
            NextScene.interactable = false;
        }
        //Debug.Log("Button state checked");
    }
    private void OnAddingItem(int id)
    {
        if (ItemsLocked)
        {
            Notes.interactable = true;
            ItemsLocked = false;
        }
        
    }
    private void OnDestroy()
    {
        GameEvents.current.onCheckpoint -= OnCheckpoint;
        GameEvents.current.onAddingItem -= OnAddingItem;
    }
}
