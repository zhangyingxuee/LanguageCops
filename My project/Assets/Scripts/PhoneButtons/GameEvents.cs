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

        public event Action onStartDialogue;

    public void StartDialogue()
    {
        if (onStartDialogue != null)
        {
            onStartDialogue();
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
}
