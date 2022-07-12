using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    private void Awake()
    {
        current = this;
    }
    public event Action onCloseCafe;

    public void CloseCafe()
    {
        if (onCloseCafe != null)
        {
            onCloseCafe();
        }
    }
    public event Action onDialogueEnd;

    public void DialogueEnd()
    {
        if (onDialogueEnd != null)
        {
            onDialogueEnd();
        }
    }

    public event Action onStartDialogue;

    public void StartDialogue()
    {
        if (onStartDialogue != null)
        {
            onStartDialogue();
        }
    }

    public event Action<int> onAllSelect;

    public void AllSelect(int state)
    {
        if (onAllSelect != null)
        {
            onAllSelect(state);
        }
    }

    public event Action onAllReset;

    public void AllReset()
    {
        if (onAllReset != null)
        {
            onAllReset();
        }
    }

    public event Action<int> onSelectButton;

    public void Selectbutton(int correct)
    {
        if (onSelectButton != null)
        {
            onSelectButton(correct);
        }
    }

    public event Action<int> onDeselectButton;
    public void Deselectbutton(int correct)
    {
        if (onDeselectButton != null)
        {
            onDeselectButton(correct);
        }
    }

    public event Action<int> onAddingItem;
    public void AddingItem(int count)
    {
        if (onAddingItem != null)
        {
            onAddingItem(count);
        }
    }
    public event Action<int> onCheckpoint;
    public void Checkpoint(int progress)
    {
        if (onCheckpoint != null)
        {
            onCheckpoint(progress);
        }
    }

    public event Action<int> onGetReady;
    public void GetReady(int id)
    {
        if (onGetReady != null)
        {
            onGetReady(id);
        }
    }

    public event Action<int> onSubmit;
    public void Submit(int id)
    {
        if (onSubmit != null)
        {
            onSubmit(id);
        }
    }

}
