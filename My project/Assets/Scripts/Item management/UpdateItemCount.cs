using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateItemCount : MonoBehaviour
{
    private bool is_ready;
    private int id_to_update;
    void Start()
    {
        GameEvents.current.onDialogueEnd += OnDialogueEnd;
    }
    public void UpdateCount(int id_num)
    {
        GameEvents.current.AddingItem(id_num);
    }

    public void UpdateAfterConversation(int id_num)
    {
        is_ready = true;
        id_to_update = id_num;
    }
    public void OnDialogueEnd()
    {
        if (is_ready)
        {
            GameEvents.current.AddingItem(id_to_update);
            is_ready = false;
        }
    }

    private void OnDestroy()
    {
        GameEvents.current.onDialogueEnd -= OnDialogueEnd;
    }
}
