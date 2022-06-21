using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPLockButton : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.onCheckpoint += OnCheckpoint;
        GameEvents.current.onAddingItem += OnAddingItem;
    }

    public int SolvingUnlock;
    public int NextSceneUnlock;
    public Button Notes;
    public Button Solvings;
    public Button NextScene;

    private void OnCheckpoint(int progress)
    {
        if (progress == SolvingUnlock)
        {
            Solvings.interactable = true;
            //Debug.Log("Solution activated");
        }
        if (progress == NextSceneUnlock)
        {
            NextScene.interactable = true;
        }
        //Debug.Log("Button state checked");
    }
    private void OnAddingItem(int id)
    {
        Notes.interactable = true;
    }
 }
